using GalleryBL;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        AppSettings settings;

        public delegate void AppSettingsHandler(object source, AppSettingsInfo appSettingsInfo);
        public event AppSettingsHandler AppSettingsChanged;


        public SettingsWindow(AppSettings s)
        {
            settings = s;
            InitializeComponent();
            jpgChkbox.IsChecked = settings.GetFileExtensionStatus(ExtensionEnums.JPG);
            pngChkbox.IsChecked = settings.GetFileExtensionStatus(ExtensionEnums.PNG);
            wmvChkbox.IsChecked = settings.GetFileExtensionStatus(ExtensionEnums.WMV);
            mp4Chkbox.IsChecked = settings.GetFileExtensionStatus(ExtensionEnums.MP4);
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            
            switch((sender as System.Windows.Controls.CheckBox).Name)
            {
                case "jpgChkbox":
                    settings.ChangeFileExtensionStatus(ExtensionEnums.JPG, (bool)jpgChkbox.IsChecked);
                    break;
                case "pngChkbox":
                    settings.ChangeFileExtensionStatus(ExtensionEnums.PNG, (bool)pngChkbox.IsChecked);
                    break;
                case "wmvChkbox":
                    settings.ChangeFileExtensionStatus(ExtensionEnums.WMV, (bool)wmvChkbox.IsChecked);
                    break;
                case "mp4Chkbox":
                    settings.ChangeFileExtensionStatus(ExtensionEnums.MP4, (bool)mp4Chkbox.IsChecked);
                    break;
            }
        }

        protected virtual void OnAppSettingsChanged(AppSettings settings)
        {
            if(AppSettingsChanged!=null)
            {
                AppSettingsChanged(this, new AppSettingsInfo { AppSettings = settings });
            }
        }
    }

    public class AppSettingsInfo
    {
        public AppSettings AppSettings { get; set; }
    }
}
