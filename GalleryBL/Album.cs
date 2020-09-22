﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GalleryBL
{
    /// <summary>
    /// Album Model class.
    /// </summary>
    [Serializable]
    public class Album
    {
        public string AlbumTitle { get; set; }
        public ObservableCollection<MediaFile> MediaFiles { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumImage { get; set; }

        /// <summary>
        /// Constructor that takes two strings as parameters.
        /// </summary>
        /// <param name="albumTitle">Album title</param>
        /// <param name="albumDescription">Album description</param>
        public Album(string albumTitle, string albumDescription)
        {
            AlbumTitle = albumTitle;
            MediaFiles = new ObservableCollection<MediaFile>();
            AlbumDescription = albumDescription;
            AlbumImage = "Assets/photo-gallery.png";   //Default image          
        }
        /// <summary>
        /// Empty constructor for serialization.
        /// </summary>
        public Album()
        {

        }
    }
    
}
