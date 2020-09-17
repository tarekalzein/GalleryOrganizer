using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GalleryBL
{
    public class Album
    {
        public string AlbumTitle { get; set; }
        public ObservableCollection<MediaFile> MediaFiles { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumImage { get; set; }

        public Album(string albumTitle, string albumDescription)
        {
            AlbumTitle = albumTitle;
            MediaFiles = new ObservableCollection<MediaFile>();
            AlbumDescription = albumDescription;
            AlbumImage = "Assets/photo-gallery.png";   //Default image          
        }

        public Album()
        {

        }
    }
    
}
