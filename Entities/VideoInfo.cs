
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace YogIt.Modules.VideoJs.Entities
{
    [TableName("yogit_Videos")]
    [PrimaryKey("VideoId")]
    [Cacheable("VideoJsInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class VideoInfo : IVideoInfo
    {
        public Guid VideoId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }
        
        public string PosterImage { get; set; }

        public string VideoPath { get; set; }
        
        public string CaptionFilePath { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastModifiedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }
    }
}