﻿using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GalleryPL
{
    /// <summary>
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class ImagePage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();

        //Delegate without data to consume.
        public delegate void ImageEventHandler(object source, EventArgs args);
        public event ImageEventHandler ImagePlayFinished;

        public ImagePage(string imagePath)
        {
            InitializeComponent();
            {
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            if (!string.IsNullOrEmpty(imagePath))
                image.Source = ImagePathToSourceConverter(imagePath);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            OnImagePlayFinished();
        }

        private BitmapImage ImagePathToSourceConverter(string imagePath)
        {
            return new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

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