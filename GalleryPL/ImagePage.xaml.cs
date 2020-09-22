using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for ImagePage.xaml. Handles showing an image in a frame inside the SlideShowWindow.
    /// Uses Dispatcher timer to notify parent window that image has been showed for a specific time.
    /// Delegate event handler is used for the autoscroll function.
    /// </summary>
    public partial class ImagePage : Page
    {
        //Dispatcher timer to tick with interval.
        private DispatcherTimer timer = new DispatcherTimer();

        //Delegate without data to consume.
        public delegate void ImageEventHandler(object source, EventArgs args);
        public event ImageEventHandler ImagePlayFinished;

        /// <summary>
        /// Constructor that takes the file path as parameter
        /// </summary>
        /// <param name="imagePath">File Path as string</param>
        public ImagePage(string imagePath)
        {
            InitializeComponent();
            {
                timer.Interval = TimeSpan.FromSeconds(4);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            if (!string.IsNullOrEmpty(imagePath))
                image.Source = ImagePathToSourceConverter(imagePath);
        }
        /// <summary>
        /// Method to be performed with every dispatcher timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            OnImagePlayFinished();
        }
        /// <summary>
        /// Method that does one thing: convert string of file path to BitmapImage.
        /// </summary>
        /// <param name="imagePath">string: File path</param>
        /// <returns>BitmapImage</returns>
        private BitmapImage ImagePathToSourceConverter(string imagePath)
        {
            return new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        /// <summary>
        /// Event notifier.
        /// </summary>
        protected virtual void OnImagePlayFinished()
        {
            if (ImagePlayFinished != null)
            {
                ImagePlayFinished(this, EventArgs.Empty);
                timer.Stop();
            }
        }
    }
}
