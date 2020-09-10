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
        public MainWindow()
        {
            InitializeComponent();

            var albums = GetAlbums();
            if(albums.Count > 0)
            {
                ListViewAlbums.ItemsSource = albums;
            }

        }

        private List<Album> GetAlbums()
        {          
            return new TestClass().GetAlbums()   ;
        }

        private void Album_btn_Click(object sender, RoutedEventArgs e)
        {

            //var item = (sender as FrameworkElement).DataContext;

            //int index = ListViewAlbums.Items.IndexOf(item);
            //MessageBox.Show(index.ToString());

            //or
            //Button button = sender as Button;
            //Album album = button.DataContext as Album;
            //MessageBox.Show(album.AlbumTitle);

            //or
            Button button = sender as Button;
            int index = ListViewAlbums.Items.IndexOf(button.DataContext);
            //This would work too.
            //index = _myListBoxName.ItemContainerGenerator.IndexFromContainer(button.DataContext);

            MessageBox.Show(index.ToString());//replace this with actual functionality
        }

        private void AddNewAlbum() { }
        private void RemoveAlbum(int index)
        {
            
        }
    }
}
