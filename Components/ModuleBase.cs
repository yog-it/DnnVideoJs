
using DotNetNuke.Services.Localization;
using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Security;
using DotNetNuke.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using DotNetNuke.Common.Utilities;

namespace YogIt.Modules.VideoJs.Components
{
    public abstract class VideoJsModuleBase : PortalModuleBase
    {
        protected INavigationManager NavManager { get; }

        #region Localization
        protected string GetLocalizedString(string LocalizationKey)
        {
            if (!string.IsNullOrEmpty(LocalizationKey))
            {
                return Localization.GetString(LocalizationKey, this.LocalResourceFile);
            }
            else
            {
                return string.Empty;
            }
        }

        protected string GetLocalizedString(string LocalizationKey, string LocalResourceFilePath)
        {
            if (!string.IsNullOrEmpty(LocalizationKey))
            {
                return Localization.GetString(LocalizationKey, LocalResourceFilePath);
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Event Handlers
        protected VideoJsModuleBase()
        {
            NavManager = DependencyProvider.GetService<INavigationManager>();
            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            // request that the DNN framework load the jQuery script into the markup
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);

        }
        #endregion

        #region Security

        protected bool InEditMode
        {
            get
            {
                return (IsEditable && PortalSettings.UserMode == DotNetNuke.Entities.Portals.PortalSettings.Mode.Edit);
            }
        }

        protected bool CurrentUserCanEdit
        {
            get
            {
                return DotNetNuke.Security.Permissions.ModulePermissionController.CanEditModuleContent(this.ModuleConfiguration);
            }
        }
        /// <summary>
        /// Use DNN security to remove anything melicious from user inputs
        /// </summary>
        /// <param name="userInput">The text value entered</param>
        /// <returns>Filtered inputs</returns>
        public string FilterInputValue(string userInput)
        {
            var objSecurity = PortalSecurity.Instance;
            return objSecurity.InputFilter(userInput, PortalSecurity.FilterFlag.NoScripting | PortalSecurity.FilterFlag.NoAngleBrackets | PortalSecurity.FilterFlag.NoMarkup).Trim();
        }

        #endregion

        #region Caching

        public static bool CacheExists(string key, int ModuleID)
        {
            return DataCache.GetCache(key + ModuleID.ToString()) is object;
        }

        public static void SetCache<T>(T toSet, string key, int ModuleID)
        {
            DataCache.SetCache(key + ModuleID.ToString(), toSet);
        }

        public static T GetItemFromCache<T>(string key, int ModuleID)
        {
            return (T)DataCache.GetCache(key + ModuleID.ToString());
        }

        #endregion
    }
}