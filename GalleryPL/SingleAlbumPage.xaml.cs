using GalleryBL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GalleryPL.Properties
{
    /// <summary>
    /// Interaction logic for SingleAlbumPage.xaml
    /// </summary>
    public partial class SingleAlbumPage : Page
    {
        public SingleAlbumPage(int index, AlbumManager albumManager)
        {
            InitializeComponent();

            albumManager.GetAlbumFilesByAlbumIndex(index);
            AlbumNameTextBlock.Text = albumManager.GetAlbumAtIndex(index).AlbumTitle;

            if (albumManager.GetAlbumAtIndex(index).MediaFiles.Count > 0)
            {
                ListViewImages.ItemsSource = albumManager.GetAlbumAtIndex(index).MediaFiles;
            }
            else
            {                

            }

        }
        private void BackBtn_onClick(object sender, RoutedEventArgs e)
        {
            AlbumsPage albumsPage = new AlbumsPage();
            NavigationService.Navigate(albumsPage);
        }
    }
}
