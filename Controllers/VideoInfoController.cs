
using System;
using System.Collections.Generic;
using System.Linq;
using YogIt.Modules.VideoJs.Entities;
using YogIt.Modules.VideoJs.Data;

namespace YogIt.Modules.VideoJs.Controllers
{
    public class VideoInfoController
    {        
        public void CreateItem(VideoInfo i)
        {
            VideoInfoRepository.Instance.CreateItem(i);
        }

        public void DeleteItem(Guid videoId, int moduleId)
        {
            VideoInfoRepository.Instance.DeleteItem(videoId, moduleId);
        }

        public void DeleteItem(VideoInfo i)
        {
            VideoInfoRepository.Instance.DeleteItem(i);
        }

        public IEnumerable<VideoInfo> GetItems(int moduleId)
        {
            var items = VideoInfoRepository.Instance.GetItems(moduleId);
            return items;
        }

        public VideoInfo GetItem(Guid videoId, int moduleId)
        {
            var item = VideoInfoRepository.Instance.GetItem(videoId, moduleId);
            return item;
        }

        public void UpdateItem(VideoInfo i)
        {
            VideoInfoRepository.Instance.UpdateItem(i);
        }

        public VideoInfo GetVideoByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items?.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}