using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    public class Album
    {
        public string AlbumTitle { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumImage { get; set; }

        public Album(string albumTitle, string albumDescription, string albumImage )
        {
            AlbumTitle = albumTitle;
            MediaFiles = new List<MediaFile>();
            AlbumDescription = albumDescription;
            AlbumImage = albumImage;            
        }
    }
    
}
