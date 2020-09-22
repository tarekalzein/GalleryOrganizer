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
        /// <summary>
        /// Constructor to be used when creating a new album
        /// </summary>
        public NewEditDialogue()
        {
            InitializeComponent();
            if (album == null)
                album = new Album();
            
        }
        /// <summary>
        /// Consturctor to be used when editing an existing album.
        /// </summary>
        /// <param name="album"></param>
        public NewEditDialogue(Album album)
        {
            InitializeComponent();
            if (album == null)
            {
                album = new Album();
            }
            else
            {
                this.album = album;
                title_txtbox.Text = album.AlbumTitle;
                description_txtbox.Text = album.AlbumDescription;
            }
        }
        /// <summary>
        /// Album to retrieve the modifications in a dialogue result.
        /// </summary>
        public Album Album
        {
            get { return album; }
            set { album = value; }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        /// <summary>
        /// Method to confirm returning the new/edited album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
