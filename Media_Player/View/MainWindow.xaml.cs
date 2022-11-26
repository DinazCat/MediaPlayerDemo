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
using Media_Player.UserControls;
using Media_Player.ViewModel;
using static Media_Player.MainWindow;

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            if (Phatnhac.isplaying == true)
            {
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
            }
            else
            {
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
            }
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            getsong.Position++;
            timelineSlider.Value = getsong.Position;
        }

        string filename;
        public static DispatcherTimer Timer;
        void openmussic()
        {
            Phatnhac.mediaPlayer.Open(new Uri(filename));
            Phatnhac.Isplaying2 = true;
            Phatnhac.mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
        }

        public void MediaPlayer_MediaOpened(object? sender, EventArgs e)
        {
            if (Phatnhac.mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                getsong.Duration = Phatnhac.mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                txblDuration.Text = new TimeSpan(0, (int)(getsong.Duration / 60), (int)(getsong.Duration % 60)).ToString(@"mm\:ss");
                timelineSlider.Maximum = getsong.Duration;
                getsong.Position = 0;
                Timer.Start();
            }

        }

        void HamTuongTac(Song song)
        {
            if (song.Open == true)
            {
                Phatnhac.mediaPlayer.Stop();
                Phatnhac.Isplaying2 = false;
                for (int i = 0; i < Songs.Count; i++)
                {
                    if (Songs[i].Open == false) Songs[i].Open = true;
                    Songs[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                }
                Anh.Source = new BitmapImage(new Uri(song.linkanh));
                TenBH.Content = song.songNames;
                TenTG.Content = song.singerNames;
            }
            filename = song.savepath;

            if (song.Open == true)
            {
                Phatnhac.isplaying = true;
                openmussic();

                song.Open = false;
            }

            Phatnhac.isplaying = !Phatnhac.isplaying;
            if (Phatnhac.isplaying == true)
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                Timer.Stop();
            }
            else
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                Timer.Start();
            }

            getsong = song;
        }
        private static List<Song> songs;
        public static List<Song> Songs { get { return songs; } set { songs = value; } }

        private static Song Getsong;
        public static Song getsong { get { return Getsong; } set { Getsong = value; } }

        //back song
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Songs.IndexOf(getsong);
            index -= 1;
            if (Songs[index + 1] != Songs[0])
            {
                HamTuongTac(Songs[index]);
                if (onAction != null) onAction.Invoke(this, e);
            }
        }
        //play song
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Phatnhac.isplaying = !Phatnhac.isplaying;
            if (Phatnhac.isplaying == true)
            {
                getsong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                Timer.Stop();
            }
            else
            {
                getsong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                Timer.Start();
            }
        }
        public EventHandler onAction = null;
        //next song
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = Songs.IndexOf(getsong);
            index += 1;
            if (Songs[index - 1] != Songs[Songs.Count - 1])
            {
                HamTuongTac(Songs[index]);
                if (onAction != null) onAction.Invoke(this, e);
            }
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Phatnhac.mediaPlayer.Volume = (double)volumeSlider.Value;
        }

        bool isDraging = false;
        private void timelineSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isDraging = true;
        }

        private void timelineSlider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            isDraging = false;
        }

        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDraging)
            {
                Getsong.Position = timelineSlider.Value;
                Phatnhac.mediaPlayer.Position = new TimeSpan(0, 0, (int)Getsong.Position);
            }
            txblPosition.Text = new TimeSpan(0, (int)(Getsong.Position / 60), (int)(Getsong.Position % 60)).ToString(@"mm\:ss");
        }
    }
}
