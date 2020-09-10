using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GalleryBL
{
    public class TestClass
    {
        ObservableCollection<Album> list = new ObservableCollection<Album>();
        public TestClass()
        {           
            list.Add(new Album("Album 1", "Description of Album 1", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 2", "Description of Album 2", "Assets/test_image.jpg"));
            list.Add(new Album("Album 3", "Description of Album 3", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 4", "Description of Album 4", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 5", "Description of Album 5", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 6", "Description of Album 6", "Assets/test_image.jpg"));
            list.Add(new Album("Album 7", "Description of Album 7", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 8", "Description of Album 8", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 9", "Description of Album 9", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 10", "Description of Album 10", "Assets/test_image.jpg"));
            list.Add(new Album("Album 11", "Description of Album 11", "Assets/test_image.jpg"));
            list.Add(new Album("Album 12", "Description of Album 12", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 13", "Description of Album 13", "Assets/117433341_639124320118894_2954627081193273423_n.jpg"));
            list.Add(new Album("Album 14", "Description of Album 14", "Assets/test_image.jpg"));
            list.Add(new Album("Album 15", "Description of Album 15", "Assets/GalleryIcon.png"));
            list.Add(new Album("Album 16", "Description of Album 16", "Assets/test_image.jpg"));
            list.Add(new Album("Album 17", "Description of Album 17", "Assets/GalleryIcon.png"));
            list.Add(new Album("Album 18", "Description of Album 18", "Assets/test_image.jpg"));
        }

        public ObservableCollection<Album> GetAlbums()
        {
            return list;
        }
    }
}
