using GalleryBL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

        Album album = new Album();

        public delegate void ImportEventHandler(object source, ImportEventInfo eventInfo);

        public event ImportEventHandler FilesImported;

        
        AppSettings appSettings = new AppSettings();
        public ImportWindow(Album album)
        {
            InitializeComponent();
            this.album = album;

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

            ObservableCollection<FileHelper> files = new ObservableCollection<FileHelper>();
            Thumbnails.ItemsSource = files;

            TreeViewItem item = e.Source as TreeViewItem;
            if(item.Tag is DirectoryInfo)
            {
                DirectoryInfo folder = item.Tag as DirectoryInfo;                
                string path= GetFolderPath(folder);
                try
                {
                    foreach (var fi in GetFilesWithSettings(folder))
                    {
                        //files.Add(new FileHelper(false, new MediaFile(fi.Name, "", fi.FullName)));
                        switch (fi.Extension)
                        {
                            case ".jpg":
                            case ".png":
                                files.Add(new FileHelper(false, new ImageFile(fi.Name,"", fi.FullName)));
                                break;
                            case ".wmv":
                            case ".mp4":
                                files.Add(new FileHelper(false, new VideoFile(fi.Name, "", fi.FullName)));
                                break;
                        }
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
            //TODO: add check if file already exists.
            ObservableCollection<MediaFile> mediaFiles = new ObservableCollection<MediaFile>();
            if(Thumbnails.ItemsSource!=null)
            {
                foreach (FileHelper file in Thumbnails.ItemsSource)
                {
                    if (file.IsSelected)
                    {
                        if(album.MediaFiles.Any(o => o.FilePath==file.MediaFile.FilePath))
                        {
                            //MessageBox.Show($"{file.MediaFile.FileName} already exists in this album");
                            MessageBoxResult result = MessageBox.Show($"{file.MediaFile.FileName} already exists in this album, would you like to add it anyway?",
                                "File already exists",
                                MessageBoxButton.YesNo);
                            switch(result)
                            {
                                case MessageBoxResult.Yes:
                                    mediaFiles.Add(new MediaFile(file.MediaFile.FileName, file.MediaFile.Description, file.MediaFile.FilePath));
                                    break;
                                case MessageBoxResult.No:
                                    //Do Nothing
                                    break;
                            }
                        }
                    }
                }
                if (mediaFiles.Count > 0)
                {
                    OnFilesImported(album, mediaFiles);
                    this.Close();
                }
            }            
        }

        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(appSettings);
            settings.Show();
            settings.AppSettingsChanged += OnAppSettingsChange;
        }

        private void OnAppSettingsChange(object source, AppSettingsInfo appSettingsInfo)
        {
            this.appSettings = appSettingsInfo.AppSettings;            
        }

        private List<FileInfo> GetFilesWithSettings(DirectoryInfo folder)
        {
            var extensions = appSettings.GetEnabledExtensions();

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

        protected virtual void OnFilesImported(Album album, ObservableCollection<MediaFile> mediaFiles)
        {
            if(FilesImported!=null)
            {
                FilesImported(this, new ImportEventInfo() { Album = album, MediaFiles = mediaFiles });
            }
        }

         
    }
}

