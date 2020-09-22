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
        /// <summary>
        /// Constructor with an album manasger instance that was created from the Main Window.
        /// </summary>
        /// <param name="manager">AlbumManager instance</param>
        public AlbumsPage(AlbumManager manager)
        {
            albumManager = manager;
            InitializeComponent();

            //no need to check for index or whatever since the list in album manager is an observablecollection.
            ListViewAlbums.ItemsSource = albumManager.GetAlbums();

        }
        /// <summary>
        /// Method to run when clicking on an album.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Method to open a single album from the "open" option in the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            int index = ListViewAlbums.Items.IndexOf(menuItem.DataContext);
            SingleAlbumPage singleAlbum = new SingleAlbumPage(index, albumManager);

            NavigationService.Navigate(singleAlbum);
        }
        /// <summary>
        /// Method to delete a single album from the "open" option in the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            int index = ListViewAlbums.Items.IndexOf(menuItem.DataContext);
            albumManager.RemoveAlbum(index);
            SerializationHelper.Serialize(albumManager);
        }
        /// <summary>
        /// Method to edit the information of a single album from the "open" option in the context menu. It sends the chosen album to the edit window for editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_onClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            int index = ListViewAlbums.Items.IndexOf(menuItem.DataContext);
            NewEditDialogue newEditDialogue = new NewEditDialogue(albumManager.GetAlbumAtIndex(index));
            newEditDialogue.ShowDialog();
            if (newEditDialogue.DialogResult == true)
            {
                albumManager.GetAlbumAtIndex(index).AlbumTitle = newEditDialogue.Album.AlbumTitle;
                albumManager.GetAlbumAtIndex(index).AlbumDescription = newEditDialogue.Album.AlbumDescription;

                ListViewAlbums.Items.Refresh(); //refresh GUI

                SerializationHelper.Serialize(albumManager);
            }
        }
        /// <summary>
        /// Method to create a new album, opens the new album window and awaits dialogue result before saving the created album to the album manager instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Method to send the selected album to and show it in a slideshow (fullscreen with autoscroll).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlideShow_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            int index = ListViewAlbums.Items.IndexOf(menuItem.DataContext);

            SlideShowWindow slideShowWindow = new SlideShowWindow(albumManager.GetAlbumAtIndex(index));
            slideShowWindow.Show();
        }
    }
}
