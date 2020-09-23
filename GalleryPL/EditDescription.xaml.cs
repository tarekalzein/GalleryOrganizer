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
    /// Interaction logic for EditDescription.xaml
    /// </summary>
    public partial class EditDescription : Window
    {
        public EditDescription(string oldDescription)
        {
            InitializeComponent();
            description_txtbox.Text = oldDescription;
        }

        public string GetNewDescription()
        {
           if (description_txtbox.Text!=null)
                return description_txtbox.Text;
            else
                return "";
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            if (description_txtbox.Text != null)
            {               
                this.DialogResult = true;
            }
        }
        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
