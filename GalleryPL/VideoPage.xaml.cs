using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for VideoPage.xaml
    /// </summary>
    public partial class VideoPage : Page
    {
        MediaPlayer mediaPlayer;

        public delegate void VideoEventHandler(object source, EventArgs args);
        public event VideoEventHandler VideoPlayFinished;

        public VideoPage(string videoPath)
        {
            InitializeComponent();

            mediaPlayer = new MediaPlayer();
            if (!string.IsNullOrEmpty(videoPath))
                video.Source = new System.Uri(videoPath);
            
        }

        public void ChangeVideoSource(string videoPath)
        {
            if (!string.IsNullOrEmpty(videoPath))
                video.Source = new System.Uri(videoPath);
        }

        protected virtual void OnVideoPlayFinished()
        {
            if (VideoPlayFinished!=null)
            {
                VideoPlayFinished(this, EventArgs.Empty);
            }
        }

        private void video_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            OnVideoPlayFinished();
        }
    }
}
