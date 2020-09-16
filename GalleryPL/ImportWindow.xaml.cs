using GalleryBL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GalleryPL
{

    //TODO: Add video thumbnails converter or something.

    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        
        AppSettings appSettings = new AppSettings();
        public ImportWindow()
        {
            InitializeComponent();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach(DriveInfo drive in drives)
            {
                FileTreeView.Items.Add(CreateTreeItem(drive));
            }                       
        }

        /// <summary>
        /// Method to replace the dummy content of the subfolder by its real content.
        /// Lazy loading TreeView items with dummy content. Source: https://www.wpf-tutorial.com/treeview-control/lazy-loading-treeview-items/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {           
            TreeViewItem item = e.Source as TreeViewItem;
            if((item.Items.Count==1) && (item.Items[0] is string))
            {
                item.Items.Clear();

                DirectoryInfo expandedDir = null;
                if(item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);
                try
                {
                    foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                        item.Items.Add(CreateTreeItem(subDir));
                }
                catch
                {
                    MessageBox.Show("Access Denied.");
                }
            }
        }

        public void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {

            //ObservableCollection<MediaFile> files = new ObservableCollection<MediaFile>();
            //Thumbnails.ItemsSource = files;

            ObservableCollection<FileHelper> files = new ObservableCollection<FileHelper>();
            Thumbnails.ItemsSource = files;

            TreeViewItem item = e.Source as TreeViewItem;
            if(item.Tag is DirectoryInfo)
            {
                DirectoryInfo folder = item.Tag as DirectoryInfo;                
                string path= GetFolderPath(folder);

                try
                {
                    foreach(var fi in GetFilesWithSettings(folder))
                    {
                        files.Add(new FileHelper(false, new MediaFile(fi.Name, "", fi.FullName)));
                    }
                }
                catch
                {
                    MessageBox.Show("Access Denied.");
                }                           
            }    
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
           ToggleButton toggleButton= sender as ToggleButton;
            FileHelper file = toggleButton.DataContext as FileHelper;

            if ((bool)toggleButton.IsChecked)
                file.IsSelected = true;
            else
                file.IsSelected = false;
        }

        private TreeViewItem CreateTreeItem(object o)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = o.ToString();

            //using dummy sub items for folder, then populate them when they are open.
            item.Tag = o;
            item.Items.Add("...");
            return item;
        }

        private string GetFolderPath(DirectoryInfo directoryInfo)
        {
            return directoryInfo.FullName;
        }

        private void import_btn_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach(FileHelper file in Thumbnails.ItemsSource)
            {
                if (file.IsSelected)
                    count++;
            }
            MessageBox.Show("Count of selected files:" + count);
            
        }

        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(appSettings);
            settings.Show();
        }

        private List<FileInfo> GetFilesWithSettings(DirectoryInfo folder)
        {

            string[] extensions= {"*.jpg","*.png","*.mp4","*.wmv"};
            List<FileInfo> fileInfos = new List<FileInfo>();

            foreach (string ext in extensions)
            {
                foreach(var file in folder.GetFiles(ext))
                {
                    fileInfos.Add(file);
                }                
            }
            return fileInfos;
        }
    }
}

