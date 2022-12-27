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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for MvView.xaml
    /// </summary>
    public partial class MvView : UserControl
    {
        public MvView()
        {
            InitializeComponent();


            TimeLBtn.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "clock.png"));
            TimeRBtn.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "clock1.png"));
            Anh.Source = ((MainWindow)System.Windows.Application.Current.MainWindow).Anh.Source;
            TenBH.Content = ((MainWindow)System.Windows.Application.Current.MainWindow).TenBH.Content;
            TenTG.Content = ((MainWindow)System.Windows.Application.Current.MainWindow).TenTG.Content;
            BtnPlay.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));

            myMediaElement.Source = new Uri(MainWindow.VidName);
            myMediaElement.LoadedBehavior = MediaState.Manual;
            myMediaElement.UnloadedBehavior = MediaState.Manual;
            myMediaElement.BufferingEnded += MyMediaElement_BufferingEnded;


            MainWindow.media = myMediaElement;
            isplay = true;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            myMediaElement.Play();


        }
        public static string VidName = "";
        private void MyMediaElement_BufferingEnded(object sender, RoutedEventArgs e)
        {
            //   myMediaElement.Play();
        }

        public static double oldPosition = 0;
        public static double Position = 0;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (Position - oldPosition != 0)
                myMediaElement.Position = new TimeSpan(0, 0, (int)Position);
            Position += 1;
            oldPosition = Position;
            timelineSlider.Value = Position;
        }

        public static DispatcherTimer Timer;
        bool isplay = false;
        public static bool stop = false;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (isplay)
            {
                BtnPlay.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                myMediaElement.Pause();
                Timer.Stop();
                isplay = false;
            }
            else
            {
                BtnPlay.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                myMediaElement.Play();
                Timer.Start();
                isplay = true;
            }

        }

        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            if (volumeSlider.Value == 0)
            {
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "volume.png"));
                volumeSlider.Value = OldvolumeSize;
                OldVolume = true;
            }
            else
            {
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "mute.png"));
                volumeSlider.Value = 0;
                OldVolume = true;
            }
        }
        public MvView(bool stop)
        {
            if (stop)
            {
                myMediaElement.Stop();
            }
        }
        bool OldVolume = true;
        double OldvolumeSize;
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
            if (OldVolume == true && (double)volumeSlider.Value != 0)
            {
                OldvolumeSize = (double)volumeSlider.Value;
                OldVolume = false;
            }
            if ((double)volumeSlider.Value == 0.0)
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "mute.png"));
            else
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "volume.png"));
        }

        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Position = timelineSlider.Value;
            txblPosition.Text = new TimeSpan(0, (int)(Position / 60), (int)(Position % 60)).ToString(@"mm\:ss");
        }

        private void myMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            double duration = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            timelineSlider.Maximum = duration;

            txblDuration.Text = new TimeSpan(0, (int)(duration / 60), (int)(duration % 60)).ToString(@"mm\:ss");
            Position = 0;
            oldPosition = 0;
            myMediaElement.Position = new TimeSpan(0, 0, 0);
            Timer.Start();
        }

        private void myMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
            Timer.Stop();
            BtnPlay.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
            isplay = false;
            Position = 0;
            oldPosition = 0;
            myMediaElement.Position = new TimeSpan(0, 0, 0);
        }

       

        private void TimeLBtn_Click(object sender, RoutedEventArgs e)
        {
            timelineSlider.Value -= 5;
        }

        private void TimeRBtn_Click(object sender, RoutedEventArgs e)
        {
            timelineSlider.Value += 5;
        }
       
    }
}

