using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    public class Album
    {
        public string AlbumTitle { get; set; }
        public List<MediaFile> AlbumFiles { get; set; }
        public string AlbumDescription { get; set; }
    }
}
