using GalleryBL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GalleryPL.Properties
{
    /// <summary>
    /// Interaction logic for SingleAlbumPage.xaml
    /// </summary>
    public partial class SingleAlbumPage : Page
    {
        Album album = new Album();
        AlbumManager albumManager;

        public SingleAlbumPage(int index, AlbumManager manager)
        {
            InitializeComponent();
            albumManager = manager;

            album = albumManager.GetAlbumAtIndex(index);

            albumManager.GetAlbumFilesByAlbumIndex(index);
            AlbumNameTextBlock.Text =album.AlbumTitle;

            ListViewImages.ItemsSource = albumManager.GetAlbumAtIndex(index).MediaFiles;


        }
        private void BackBtn_onClick(object sender, RoutedEventArgs e)
        {
            AlbumsPage albumsPage = new AlbumsPage(albumManager);           
            NavigationService.Navigate(albumsPage);
        }

        private void add_btn_OnClick(object sender, RoutedEventArgs e)
        {
            ImportWindow importWindow = new ImportWindow(album);
            //TODO: Change constructor to include the album to add files to.
            //Add delegates to add files directly.
            importWindow.Show();

            importWindow.FilesImported += OnFilesImported;
        }
        public void OnFilesImported(object source, ImportEventInfo e)
        {
            this.album = e.Album;
            foreach(var file in e.MediaFiles)
            {
                this.album.MediaFiles.Add(new MediaFile(file.FileName, file.Description,file.FilePath));
            }
        }
    }
}
