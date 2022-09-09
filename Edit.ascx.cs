
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.FileSystem;
using System;
using YogIt.Modules.VideoJs.Components;
using YogIt.Modules.VideoJs.Controllers;
using YogIt.Modules.VideoJs.Entities;

namespace YogIt.Modules.VideoJs
{
    public partial class Edit : VideoJsModuleBase
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var videoController = new VideoInfoController();
                var videoInfo = videoController.GetVideoByModuleId(ModuleId);

                if (videoInfo != null)
                {
                    videoInfo.ModuleId = ModuleId;
                    videoInfo.Title = FilterInputValue(txtTitle.Text);
                    videoInfo.VideoPath = ctlVideo.FilePath;
                    videoInfo.PosterImage = ctlImage.FilePath;
                    videoInfo.CaptionFilePath = ctlCaption.FilePath;
                    videoInfo.LastModifiedOnDate = DateTime.Now;
                    videoInfo.LastModifiedByUserId = UserId;
                    videoController.UpdateItem(videoInfo);

                    ModuleController.SynchronizeModule(ModuleId);
                    Response.Redirect(Globals.NavigateURL());
                }
                else
                {
                    videoInfo = new VideoInfo();
                    videoInfo.ModuleId = ModuleId;
                    videoInfo.Title = FilterInputValue(txtTitle.Text);
                    videoInfo.VideoPath = ctlVideo.FilePath;
                    videoInfo.PosterImage = ctlImage.FilePath;
                    videoInfo.CaptionFilePath = ctlCaption.FilePath;
                    videoInfo.CreatedOnDate = DateTime.Now;
                    videoInfo.CreatedByUserId = UserId;
                    videoInfo.LastModifiedOnDate = DateTime.Now;
                    videoInfo.LastModifiedByUserId = UserId;
                    videoController.CreateItem(videoInfo);

                    ModuleController.SynchronizeModule(ModuleId);
                    Response.Redirect(Globals.NavigateURL());
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var videoController = new VideoInfoController();
                var videoInfo = videoController.GetVideoByModuleId(ModuleId);

                if (videoInfo != null)
                    videoController.DeleteItem(videoInfo);

                Response.Redirect(Globals.NavigateURL());
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Helper Methods

        private void BindData()
        {
            LocalizeModule();
            var videoController = new VideoInfoController();
            var videoInfo = videoController.GetVideoByModuleId(ModuleId);

            if (videoInfo != null)
            {
                txtTitle.Text = videoInfo.Title;
                ctlVideo.FilePath = videoInfo.VideoPath;
                ctlImage.FilePath = videoInfo.PosterImage;
                ctlCaption.FilePath = videoInfo.CaptionFilePath;
            }

        }

        private void LocalizeModule()
        {
            cmdCancel.NavigateUrl = Globals.NavigateURL();
        }

        #endregion

    }
}