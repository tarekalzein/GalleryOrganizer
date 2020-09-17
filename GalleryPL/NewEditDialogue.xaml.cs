using GalleryBL;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for NewEditDialogue.xaml
    /// </summary>
    public partial class NewEditDialogue : Window
    {
        private Album album;
        public NewEditDialogue()
        {
            InitializeComponent();
            if (album == null)
                album = new Album();
            
        }
        public Album Album
        {
            get { return album; }
            set { album = value; }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(title_txtbox.Text))
            {
                album.AlbumTitle = title_txtbox.Text;
                album.AlbumDescription = description_txtbox.Text;                

                this.DialogResult = true;
            }
            
        }
    }
}
