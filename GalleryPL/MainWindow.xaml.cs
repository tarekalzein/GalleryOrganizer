using DataAccessLayer;
using GalleryBL;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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


            string errorMessage;
            albumManager = SerializationHelper.Deserialize(out errorMessage);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }

            //Main is the name of the main Frame to host pages.
            Main.Content = new AlbumsPage(albumManager);            
        }       
    }
}
