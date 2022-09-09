
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using YogIt.Modules.VideoJs.Data;
using YogIt.Modules.VideoJs.Entities;

namespace YogIt.Modules.VideoJs.Components
{
    public sealed class FeatureController : IPortable
    {
        public string ExportModule(int ModuleID)
        {
            IEnumerable arrVideos = VideoInfoRepository.Instance.GetItems(ModuleID);
            var videos = new XElement("videos", from VideoInfo video in arrVideos
                                                  select new XElement("video",
                                                           new XElement("title", new XCData(video.Title)),
                                                           new XElement("posterImage", new XCData(video.PosterImage)),
                                                           new XElement("videoPath", video.VideoPath),
                                                           new XElement("captionFilePath", video.CaptionFilePath),
                                                           new XElement("createdOnDate", video.CreatedOnDate)
                                                           ));

            XElement root = new XElement("Root");
            root.Add(videos);
            return root.ToString();
        }

        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            // import the Videos
            XElement xRoot = XElement.Parse(Content);
            List<VideoInfo> lstVideos = new List<VideoInfo>();
            XElement xVideos = xRoot.Element("videos");
            foreach (var xVideo in xVideos.Elements())
            {
                // Fill video code properties
                VideoInfo video = new VideoInfo();
                video.ModuleId = ModuleID;
                video.Title = xVideo.Element("title").Value;
                video.PosterImage = xVideo.Element("posterImage").Value;
                video.VideoPath = xVideo.Element("videoPath").Value;
                video.CaptionFilePath = xVideo.Element("captionFilePath").Value;
                video.CreatedByUserId = UserID;
                video.CreatedOnDate = DateTime.Parse(xVideo.Element("createdOnDate").Value);
                video.LastModifiedOnDate = DateTime.Now;
                video.LastModifiedByUserId = UserID;

                // Add video to database
                VideoInfoRepository.Instance.CreateItem(video);
            }
        }
    }
}