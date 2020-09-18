﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    [Serializable]
    /// <summary>
    /// Class to represent a media file and its attributes.
    /// </summary>
    public class MediaFile
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public MediaFile(string fileName, string description, string filePath)
        {
            FileName = fileName;
            Description = description;
            FilePath = filePath;
        }
    }

}
