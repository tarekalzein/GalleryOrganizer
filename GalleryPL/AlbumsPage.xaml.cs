using GalleryBL;
using GalleryPL.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for AlbumsPage.xaml
    /// </summary>
    public partial class AlbumsPage : Page
    {
        AlbumManager albumManager = new AlbumManager();
        public AlbumsPage()
        {
            InitializeComponent();
            if (albumManager.GetAlbums().Count > 0)
            {
                ListViewAlbums.ItemsSource = albumManager.GetAlbums();
            }
        }
        private void Album_btn_Click(object sender, RoutedEventArgs e)
        {

            //var item = (sender as FrameworkElement).DataContext;
            //int index = ListViewAlbums.Items.IndexOf(item);
            //MessageBox.Show(index.ToString());

            //or retrieve as Album object
            //Button button = sender as Button;
            //Album album = button.DataContext as Album;
            //MessageBox.Show(album.AlbumTitle);

            //or
            Button button = sender as Button;
            int index = ListViewAlbums.Items.IndexOf(button.DataContext);
            //This would work too.
            //index = _myListBoxName.ItemContainerGenerator.IndexFromContainer(button.DataContext);

            MessageBox.Show(index.ToString());//replace this with actual functionality
            MessageBox.Show("Album title from Album Manager " + albumManager.GetAlbumAtIndex(index).AlbumTitle);//replace this with actual functionality
        }

        private void btnOpen_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                ContextMenu parentContextMenu = menuItem.CommandParameter as ContextMenu;
                if (parentContextMenu != null)
                {
                    int index = ListViewAlbums.Items.IndexOf(parentContextMenu.DataContext);
                    //MessageBox.Show("Album title from Album Manager " + albumManager.GetAlbumAtIndex(index).AlbumTitle);//replace this with actual functionality
                    SingleAlbumPage singleAlbum = new SingleAlbumPage(index, albumManager);
                    NavigationService.Navigate(singleAlbum);
                }
            }

        }

        private void btnDelete_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                ContextMenu parentContextMenu = menuItem.CommandParameter as ContextMenu;
                if (parentContextMenu != null)
                {
                    int index = ListViewAlbums.Items.IndexOf(parentContextMenu.DataContext);
                    albumManager.RemoveAlbum(index);
                }
            }
        }

        private void new_btn_Click(object sender, RoutedEventArgs e)
        {
            Album album = new Album("New Album", "new Album from add button", "Assets/test_image.jpg");
            albumManager.AddNewAlbum(album);
            MessageBox.Show("New Album added, title: " + album.AlbumTitle);

        }
    }
}
