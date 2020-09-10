using GalleryBL;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AlbumManager albumManager = new AlbumManager();

        public MainWindow()
        {
            InitializeComponent();            
            if(albumManager.GetAlbums().Count> 0)
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
            MessageBox.Show("Album title from Album Manager "+albumManager.GetAlbumAtIndex(index).AlbumTitle);//replace this with actual functionality
        }

        
    }
}
