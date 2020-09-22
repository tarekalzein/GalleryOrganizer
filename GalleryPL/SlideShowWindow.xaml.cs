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
        ImagePage imagePage = new ImagePage();        
        VideoPage videoPage = new VideoPage();

        public SlideShowWindow(Album a)
        {
            album = a;

            InitializeComponent();

            //Todo: uncomment and implement this later for auto file play
            imagePage.ImagePlayFinished += OnImagePlayFinished;

            if (album.MediaFiles.Count >0)
            {                
                currentIndex = 0;
                ShowMediaFileAtIndex(currentIndex);
            }            
        }

        /// <summary>
        /// NOT IMPLEMENTED YET! 
        /// This method raises even ImagePlayFinished that is added (but yet not implemented) in the ImagePage to auto play the file for specific time then notify the SlideShow class about that.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void OnImagePlayFinished(object source, EventArgs args)
        {
            PlayNext();
        }

        private void ShowMediaFileAtIndex(int index)
        {

            if(currentIndex >= 0 && currentIndex < album.MediaFiles.Count)
            {
                if (album.MediaFiles[index] is ImageFile)
                {
                    imagePage.ChangeImageSource(album.MediaFiles[index].FilePath);
                    SlideShowMainFrame.Content = imagePage;
                }
                else if (album.MediaFiles[index] is VideoFile)
                {
                    MessageBox.Show("Playing video file: " + album.MediaFiles[index].FileName);
                }
            }            
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

