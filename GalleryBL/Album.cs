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

        public Album(string albumTitle, string albumDescription )
        {
            AlbumTitle = albumTitle;
            MediaFiles = new List<MediaFile>();
            AlbumDescription = albumDescription;
            AlbumImage = "Assets/117433341_639124320118894_2954627081193273423_n.jpg";
            
        }
    }
    
}
