using DataAccessLayer;
using GalleryBL;
using System.Diagnostics;
using System.IO;
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
            importWindow.Show();

            importWindow.FilesImported += OnFilesImported;
        }
        public void OnFilesImported(object source, ImportEventInfo e)
        {

            this.album = e.Album;
            foreach(var file in e.MediaFiles)
            {
                string extension = Path.GetExtension(file.FilePath);
                switch (extension)
                {
                    case ".jpg":
                    case ".png":
                        this.album.MediaFiles.Add(new ImageFile(file.FileName, file.Description, file.FilePath));
                        break;
                    case ".wmv":
                    case ".mp4":
                        this.album.MediaFiles.Add(new VideoFile(file.FileName, file.Description, file.FilePath)); 
                        break;
                }
            }
            SerializationHelper.Serialize(albumManager);
        }

        private void btnDelete_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            int index = ListViewImages.Items.IndexOf(menuItem.DataContext);
            this.album.MediaFiles.RemoveAt(index);
            SerializationHelper.Serialize(albumManager);
        }

        private void btnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Process.Start(this.album.MediaFiles[ListViewImages.Items.IndexOf(menuItem.DataContext)].FilePath);
        }

        private void album_btn_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            Process.Start(this.album.MediaFiles[ListViewImages.Items.IndexOf(button.DataContext)].FilePath);
        }
    }
}
