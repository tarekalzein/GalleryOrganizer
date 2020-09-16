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

        public MainWindow()
        {
            InitializeComponent();

            //Main is the name of the main Frame to host pages.
            Main.Content = new AlbumsPage();            
        }       
    }
}
