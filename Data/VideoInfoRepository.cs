
using System;
using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using YogIt.Modules.VideoJs.Entities;

namespace YogIt.Modules.VideoJs.Data
{
    public class VideoInfoRepository : ServiceLocator<IVideoInfoRepository, VideoInfoRepository>, IVideoInfoRepository
    {
        public void CreateItem(VideoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<VideoInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(Guid videoId, int moduleId)
        {
            var i = GetItem(videoId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(VideoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<VideoInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<VideoInfo> GetItems(int moduleId)
        {
            IEnumerable<VideoInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<VideoInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public VideoInfo GetItem(Guid videoId, int moduleId)
        {
            VideoInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<VideoInfo>();
                i = rep.GetById(videoId, moduleId);
            }
            return i;
        }

        public void UpdateItem(VideoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<VideoInfo>();
                rep.Update(i);
            }
        }

        protected override Func<IVideoInfoRepository> GetFactory()
        {
            return () => new VideoInfoRepository();
        }
    }
}