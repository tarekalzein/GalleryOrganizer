using GalleryBL;
using System;
using System.Windows;
using System.Windows.Input;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for SlideShowWindow.xaml
    /// </summary>
    public partial class SlideShowWindow : Window
    {
        /**Todo: implement auto file play: logic is like this: 
        1- Get instance of album
        2- Loop through each media file element in it 
        3- if the element is image: send it to ImagePage to play it with a dispatcher timer coupled with notifying event. When tick is over  notify parent window (SlideShowImage).
           if the element is video: send it to VideoPage and play it, when media.ended event is called, it will notify parent Window.
        4- when ImagePlayFinished or VideoEnded events are raised: continue with loop and get next item.
        **/

        int currentIndex;
        private Album album;
        /// <summary>
        /// Default constructor that takes an instance of Album to show all its content in a slideshow.
        /// </summary>
        /// <param name="a"></param>
        public SlideShowWindow(Album a)
        {                        
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(EscButtonHandler); //listener to ESC button to skip the slideshow and close the window

            album = a;
            if (album.MediaFiles.Count >0)
            {                
                currentIndex = 0;
                ShowMediaFileAtIndex(currentIndex);
            }            
        }
        /// <summary>
        /// Method to send the media file to the appropriate page and subscribe to their events.
        /// </summary>
        /// <param name="index"></param>
        private void ShowMediaFileAtIndex(int index)
        {

            if(currentIndex >= 0 && currentIndex < album.MediaFiles.Count)
            {
                if (album.MediaFiles[index] is ImageFile)
                {
                    ImagePage imagePage = new ImagePage(album.MediaFiles[index].FilePath);
                    imagePage.ImagePlayFinished += OnImagePlayFinished;
                    SlideShowMainFrame.Content = imagePage;
                }
                else if (album.MediaFiles[index] is VideoFile)
                {
                    VideoPage videoPage = new VideoPage(album.MediaFiles[index].FilePath);
                    videoPage.VideoPlayFinished += OnVideoPlayFinished;
                    SlideShowMainFrame.Content = videoPage;
                }
            }            
        }
        private void OnImagePlayFinished(object source, EventArgs args)
        {
            //this condition is to fix a bug when pressing next button from image will fire this event even if the current file is a video -> it will skip it after remaining ticker time 
            if(album.MediaFiles[currentIndex] is ImageFile)
            PlayNext();
        }
        private void OnVideoPlayFinished(object source, EventArgs args)
        {
            PlayNext();
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            PlayNext();
        }

        private void previous_btn_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex != 0)
                currentIndex--;
            ShowMediaFileAtIndex(currentIndex);
        }
        private void PlayNext()
        {
            if (currentIndex + 1 != album.MediaFiles.Count)
            {
                currentIndex++;
                ShowMediaFileAtIndex(currentIndex);
            }

        }
        /// <summary>
        /// ESC button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EscButtonHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
    }
}

