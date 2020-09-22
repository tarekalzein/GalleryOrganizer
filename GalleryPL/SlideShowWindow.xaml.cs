using GalleryBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        
        public SlideShowWindow(Album a)
        {                        
            InitializeComponent();

            album = a;
            if (album.MediaFiles.Count >0)
            {                
                currentIndex = 0;
                ShowMediaFileAtIndex(currentIndex);
            }            
        }

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
                currentIndex++;
            ShowMediaFileAtIndex(currentIndex);
        }
    }
}

