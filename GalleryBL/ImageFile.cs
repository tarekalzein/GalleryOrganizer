using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    [Serializable]
    public class ImageFile : MediaFile
    {
        public ImageFile(string fileName, string description, string filePath) : base(fileName, description, filePath)
        {
            FileThumbnail = filePath;
        }
    }
}
