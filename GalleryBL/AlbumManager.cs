using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GalleryBL
{
    public class AlbumManager
    {
        //Changed to ObservableCollection to eliminate the need to update ListViews.
        ObservableCollection<Album> albumList = new ObservableCollection<Album>();

        public AlbumManager()
        {
            //Todo: remove this.
            //albumList = new TestClass().GetAlbums();
        }
        public ObservableCollection<Album> GetAlbums()
        {
            return albumList;
        }

        public void AddNewAlbum(Album album) 
        {
            albumList.Add(album);
        }
        public void RemoveAlbum(int index)
        {
            albumList.RemoveAt(index);
        }

        public Album GetAlbumAtIndex(int index)
        {
            return albumList[index];
        }

        public ObservableCollection<MediaFile> GetAlbumFilesByAlbumIndex(int index)
        {
            return GetAlbumAtIndex(0).MediaFiles;
        }
    }
}
