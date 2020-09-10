using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    public class AlbumManager
    {
        List<Album> albumList = new List<Album>();

        public AlbumManager()
        {
            albumList = new TestClass().GetAlbums();
        }
        public List<Album> GetAlbums()
        {
            return albumList;
        }

        public void AddNewAlbum() 
        {

        }
        public void RemoveAlbum(int index)
        {

        }

        public Album GetAlbumAtIndex(int index)
        {
            return albumList[index];
        }
    }
}
