using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogIt.Modules.VideoJs.Entities;

namespace YogIt.Modules.VideoJs.Data
{
    public interface IVideoInfoRepository
    {
        void CreateItem(VideoInfo i);
        void DeleteItem(Guid videoId, int moduleId);
        void DeleteItem(VideoInfo i);
        IEnumerable<VideoInfo> GetItems(int moduleId);
        VideoInfo GetItem(Guid videoId, int moduleId);
        void UpdateItem(VideoInfo i);
    }
}
