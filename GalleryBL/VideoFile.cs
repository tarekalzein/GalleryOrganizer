﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    [Serializable]
    public class VideoFile : MediaFile
    {
        public VideoFile(string fileName, string description, string filePath) : base(fileName, description, filePath)
        {
            FileThumbnail = "Assets/video_icon.png";
        }
    }
}
