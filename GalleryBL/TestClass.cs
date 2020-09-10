using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBL
{
    public class TestClass
    {
        List<Album> list = new List<Album>();
        public TestClass()
        {           
            list.Add(new Album("Album 1", "Description of Album 1"));
            list.Add(new Album("Album 2", "Description of Album 2"));
            list.Add(new Album("Album 3", "Description of Album 3"));
            list.Add(new Album("Album 4", "Description of Album 4"));
            list.Add(new Album("Album 5", "Description of Album 5"));
            list.Add(new Album("Album 6", "Description of Album 6"));
            list.Add(new Album("Album 7", "Description of Album 7"));
            list.Add(new Album("Album 8", "Description of Album 8"));
            list.Add(new Album("Album 9", "Description of Album 9"));
            list.Add(new Album("Album 10", "Description of Album 10"));
            list.Add(new Album("Album 11", "Description of Album 11"));
            list.Add(new Album("Album 12", "Description of Album 12"));
            list.Add(new Album("Album 13", "Description of Album 13"));
            list.Add(new Album("Album 14", "Description of Album 14"));
            list.Add(new Album("Album 15", "Description of Album 15"));
            list.Add(new Album("Album 16", "Description of Album 16"));
            list.Add(new Album("Album 17", "Description of Album 17"));
            list.Add(new Album("Album 18", "Description of Album 18"));
        }

        public List<Album> GetAlbums()
        {
            return list;
        }
    }
}
