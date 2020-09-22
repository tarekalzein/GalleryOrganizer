using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    /// <summary>
    /// Class that inherits from MediaFile and has an additional property (FileThumbnail) that is a hard-coded/fixed image to show as thumbnail for videos.
    /// </summary>
    [Serializable]
    public class VideoFile : MediaFile
    {
        public VideoFile(string fileName, string description, string filePath) : base(fileName, description, filePath)
        {
            FileThumbnail = "Assets/video_icon.png";
            //Todo: Create a method to extract a thumbnail to this video and make its as FileThumbnail.
        }
    }
}
