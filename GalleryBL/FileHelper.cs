using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    public class FileHelper
    {
        public bool IsSelected { get; set; }
        public MediaFile MediaFile { get; set; }

        public FileHelper(bool isSelected, MediaFile mediaFile)
        {
            IsSelected = IsSelected;
            MediaFile = mediaFile;
        }
    }
}
