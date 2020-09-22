using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    /// <summary>
    /// Simple method to temporarily hold an additional parameter (IsSelected) for each MediaFile in the import window before actually adding it to album manager.
    /// </summary>
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
