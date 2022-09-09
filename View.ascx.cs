
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Client.ClientResourceManagement;
using System;
using System.IO;
using System.Web.UI;
using YogIt.Modules.VideoJs.Components;
using YogIt.Modules.VideoJs.Controllers;
using YogIt.Modules.VideoJs.Entities;
using FileInfo = DotNetNuke.Services.FileSystem.FileInfo;

namespace YogIt.Modules.VideoJs
{
    public partial class View : VideoJsModuleBase, IActionable
    {
        #region Private Members

        private static string VIDEO_PATH_KEY = "VideoPath";
        private static string POSTER_PATH_KEY = "PosterPath";
        private static string CAPTION_PATH_KEY = "CaptionPath";

        #endregion

        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            if (Settings.Contains("FullScreen") && bool.Parse(Settings["FullScreen"].ToString()))
            {
                ClientResourceManager.RegisterScript(this.Page, "~/DesktopModules/VideoJs/FullScreen.js");
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindModule();
                }
            }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc, IsEditable);
            }
        }

        #endregion

        #region Private Helper Methods

        private void BindModule()
        {
            LocalizeModule();

            bool playFrom = (Settings["PlayFrom"] != null) && bool.Parse(Settings["PlayFrom"].ToString());
            string videoPath = string.Empty;
            string posterPath = string.Empty;
            string captionPath = string.Empty;

            // if we are playing from a folder, load the video
            if (playFrom)
            {
                if (!string.IsNullOrWhiteSpace(Request.Params["Play"]) && Settings.Contains("PlayFolder"))
                {
                    //display the video  
                    string folderPath = Settings["PlayFolder"].ToString();
                    FileInfo videoFile = (FileInfo)FileManager.Instance.GetFile(PortalId, string.Format("{0}{1}.mp4", folderPath, Request.Params["Play"]));

                    if (videoFile != null)
                    {
                        videoPath = FileManager.Instance.GetUrl(videoFile);
                        vSource.Src = videoPath;

                        string filename = videoFile.FileName;
                        filename = filename.Replace("mp4", "jpg");

                        //display the poster image if there is one
                        FileInfo posterFile = (FileInfo)FileManager.Instance.GetFile(PortalId, string.Format("{0}{1}", folderPath, filename));
                        if (posterFile != null)
                        {
                            vPlayer.Poster = FileManager.Instance.GetUrl(posterFile);
                        }
                    }
                }
                else
                {
                    pnlVideo.Visible = false;
                    if (CurrentUserCanEdit)
                        Skin.AddModuleMessage(this, GetLocalizedString("SetupModule", LocalResourceFile), ModuleMessage.ModuleMessageType.YellowWarning);
                }
            }
            else
            {

                // get the files for caching
                if (CacheExists(VIDEO_PATH_KEY, TabModuleId))
                {
                    videoPath = GetItemFromCache<string>(VIDEO_PATH_KEY, TabModuleId);
                    posterPath = CacheExists(POSTER_PATH_KEY, TabModuleId) ? GetItemFromCache<string>(POSTER_PATH_KEY, TabModuleId) : string.Empty;
                    captionPath = CacheExists(CAPTION_PATH_KEY, TabModuleId) ? GetItemFromCache<string>(CAPTION_PATH_KEY, TabModuleId) : string.Empty;
                }
                else
                {
                    VideoInfoController videoController = new VideoInfoController();
                    VideoInfo videoInfo = videoController.GetVideoByModuleId(ModuleId);

                    if (videoInfo != null)
                    {
                        FileInfo videoFile = (FileInfo)FileManager.Instance.GetFile(PortalId, videoInfo.VideoPath);
                        videoPath = FileManager.Instance.GetUrl(videoFile);
                        SetCache<string>(videoPath, VIDEO_PATH_KEY, TabModuleId);

                        if (!string.IsNullOrEmpty(videoInfo.PosterImage))
                        {
                            FileInfo posterFile = (FileInfo)FileManager.Instance.GetFile(PortalId, videoInfo.PosterImage);
                            posterPath = FileManager.Instance.GetUrl(posterFile);
                            SetCache<string>(posterPath, POSTER_PATH_KEY, TabModuleId);
                        }

                        if (!string.IsNullOrEmpty(videoInfo.CaptionFilePath))
                        {
                            FileInfo captionFile = (FileInfo)FileManager.Instance.GetFile(PortalId, videoInfo.CaptionFilePath);
                            captionPath = FileManager.Instance.GetUrl(captionFile);
                            SetCache<string>(captionPath, CAPTION_PATH_KEY, TabModuleId);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(videoPath))
                {
                    if (Settings.Contains("Background") && bool.Parse(Settings["Background"].ToString()))
                    {
                        pnlVideo.Visible = false;
                        pnlBackground.Visible = true;
                        bgSource.Src = videoPath;
                    }
                    else
                    {
                        vSource.Src = videoPath;
                        if (!string.IsNullOrEmpty(captionPath))
                            vTrack.Src = captionPath;
                        if (!string.IsNullOrEmpty(posterPath))
                            vPlayer.Poster = posterPath;
                    }
                }                
                else
                {
                    pnlVideo.Visible = false;
                    if (CurrentUserCanEdit)
                        Skin.AddModuleMessage(this, GetLocalizedString("SetupModule", LocalResourceFile), ModuleMessage.ModuleMessageType.YellowWarning);
                }
            }
        }
        
        private void LocalizeModule()
        {
            plNoJS.Text = GetLocalizedString("plNoJS", LocalResourceFile);
        }

        #endregion

        #region IActionable Implementation

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                {
                    {
                        GetNextActionID(), 
						GetLocalizedString("View.MenuItem.Title"), string.Empty,
                        string.Empty,
                        string.Empty, EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false
                    }
                };
                return actions;
            }
        }

        #endregion
    }
}