
using System;

namespace YogIt.Modules.VideoJs.Entities
{
    public interface IVideoInfo
    {
        Guid VideoId { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string PosterImage { get; set; }
        string VideoPath { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastModifiedByUserId { get; set; }
        DateTime LastModifiedOnDate { get; set; }
    }
}