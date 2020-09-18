using DataAccessLayer;
using GalleryBL;
using GalleryPL.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for AlbumsPage.xaml
    /// </summary>
    public partial class AlbumsPage : Page
    {
        private AlbumManager albumManager; //Maybe move this to main window.
        public AlbumsPage(AlbumManager manager)
        {
            albumManager = manager;
            InitializeComponent();

            ListViewAlbums.ItemsSource = albumManager.GetAlbums();

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

            SingleAlbumPage singleAlbum = new SingleAlbumPage(index, albumManager);
            NavigationService.Navigate(singleAlbum);
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
            SerializationHelper.Serialize(albumManager);
        }

        private void btnEdit_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if(menuItem != null)
            {
                ContextMenu parentContextMenu = menuItem.CommandParameter as ContextMenu;
                if(parentContextMenu != null)
                {
                    int index= ListViewAlbums.Items.IndexOf(parentContextMenu.DataContext);
                    NewEditDialogue newEditDialogue = new NewEditDialogue(albumManager.GetAlbumAtIndex(index));
                    newEditDialogue.ShowDialog();
                    if (newEditDialogue.DialogResult == true)
                    {
                        albumManager.GetAlbumAtIndex(index).AlbumTitle = newEditDialogue.Album.AlbumTitle;
                        albumManager.GetAlbumAtIndex(index).AlbumDescription = newEditDialogue.Album.AlbumDescription;

                        ListViewAlbums.Items.Refresh();
                    }

                }
            }
            SerializationHelper.Serialize(albumManager);
        }

        private void new_btn_Click(object sender, RoutedEventArgs e)
        {
            NewEditDialogue newEditDialogue = new NewEditDialogue();
            newEditDialogue.ShowDialog();
            if(newEditDialogue.DialogResult==true)
            {
                Album album= new Album(newEditDialogue.Album.AlbumTitle, newEditDialogue.Album.AlbumDescription);
                albumManager.AddNewAlbum(album);
                SerializationHelper.Serialize(albumManager);
            }
        } 
    }
}
