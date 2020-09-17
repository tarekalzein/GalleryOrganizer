using GalleryBL;
using System.Collections.ObjectModel;

namespace GalleryPL
{
    public class ImportEventInfo
    {
        public Album Album { get; set; }
        public ObservableCollection<MediaFile> MediaFiles { get; set; }
    }
}