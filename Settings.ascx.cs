
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using System;
using YogIt.Modules.VideoJs.Components;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.FileSystem;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Web.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Common;

namespace YogIt.Modules.VideoJs
{
    public partial class Settings : VideoJsModuleSettingsBase
    {
        private string _destinationFolder;

        #region Base Method Implementations

        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                LoadFolders();
                chkBackground.Checked = (Settings["Background"] != null) ? bool.Parse(Settings["Background"].ToString()) : false;
                chkFullScreen.Checked = (Settings["FullScreen"] != null) ? bool.Parse(Settings["FullScreen"].ToString()) : false;
                chkPlayFrom.Checked = (Settings["PlayFrom"] != null) ? bool.Parse(Settings["PlayFrom"].ToString()) : false;
                if (chkPlayFrom.Checked && Settings["PlayFolder"] != null)
                {
                    var folder = FolderManager.Instance.GetFolder(PortalId, Settings["PlayFolder"].ToString());
                    ddlFolders.SelectedFolder = folder;
                    pnlPlayFrom.Visible = true;
                }
            }
            catch (Exception exc) // module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
				var ctlModule = new ModuleController();
                var security = new PortalSecurity();
				
				ctlModule.UpdateTabModuleSetting(TabModuleId, "Background", chkBackground.Checked.ToString());
				ctlModule.UpdateTabModuleSetting(TabModuleId, "FullScreen", chkFullScreen.Checked.ToString());
				ctlModule.UpdateTabModuleSetting(TabModuleId, "PlayFrom", chkPlayFrom.Checked.ToString());
                ctlModule.UpdateModuleSetting(ModuleId, "PlayFolder", ddlFolders.SelectedFolder.FolderPath);

                // synchronize the module settings
                ModuleController.SynchronizeModule(ModuleId);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Event Methods

        protected void chkPlayFrom_CheckedChanged(object sender, EventArgs e)
        {
            pnlPlayFrom.Visible = chkPlayFrom.Checked;
        }

        #endregion

        #region Helper Methods

        public string DestinationFolder
        {
            get
            {
                if (_destinationFolder == null)
                {
                    _destinationFolder = string.Empty;
                    if (Request.QueryString["dest"] != null)
                    {
                        _destinationFolder = Globals.QueryStringDecode(Request.QueryString["dest"]);
                    }
                }

                return PathUtils.Instance.RemoveTrailingSlash(_destinationFolder.Replace("\\", "/"));
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This routine populates the Folder List Drop Down
        /// There is no reference to permissions here as all folders should be available to the admin.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        private void LoadFolders()
        {
            var user = UserController.Instance.GetCurrentUserInfo();

            var folders = FolderManager.Instance.GetFolders(PortalId, "ADD", user.UserID);
            ddlFolders.Services.Parameters.Add("permission", "ADD");
            if (!string.IsNullOrEmpty(DestinationFolder))
            {
                ddlFolders.SelectedFolder = folders.SingleOrDefault(f => f.FolderPath == DestinationFolder);
            }
            else
            {
                var rootFolder = folders.SingleOrDefault(f => f.FolderPath == string.Empty);
                if (rootFolder != null)
                {
                    this.ddlFolders.SelectedItem = new ListItem() { Text = DynamicSharedConstants.RootFolder, Value = rootFolder.FolderID.ToString() };
                }
            }
        }

        #endregion
    }
}