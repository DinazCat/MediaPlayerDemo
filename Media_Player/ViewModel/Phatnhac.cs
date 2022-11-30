using Media_Player.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Media_Player.ViewModel
{

    public static class Phatnhac
    {
        public static MediaPlayer mediaPlayer = new MediaPlayer();
        private static List<Song> Occupying;
        public static List<Song> occupying { get { return Occupying; } set { Occupying = value; } }
        private static bool _playing = true;        
        public static bool isplaying
        {
            get
            {
                return _playing;
            }
            set
            {
                _playing = value;
                if (_playing)
                {
                    mediaPlayer.Pause();
                }
                else
                {
                    mediaPlayer.Play();
                }
            }
        }
        private static bool _shuffle = false;
        private static bool _repeat = false;
        public static bool isshuffle { get { return _shuffle; } set { _shuffle = value; } }
        public static bool isrepeat { get { return _repeat; } set { _repeat = value; } }
        private static Song _thisSong;
        public static Song thisSong { get { return _thisSong; } set { _thisSong = value; } }
        private static List<Song> _thisList;
        public static List<Song> thisList { get { return _thisList; } set { _thisList = value; } }
        public static string filename;
        public static void openmussic()
        {
            mediaPlayer.Open(new Uri(filename));
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }
       
        private static void MediaPlayer_MediaOpened(object? sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                thisSong.Duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ((MainWindow)System.Windows.Application.Current.MainWindow).txblDuration.Text
                    = new TimeSpan(0, (int)(thisSong.Duration / 60), (int)(thisSong.Duration % 60)).ToString(@"mm\:ss");
                ((MainWindow)System.Windows.Application.Current.MainWindow).timelineSlider.Maximum = thisSong.Duration;
                thisSong.Position = 0;
                mediaPlayer.Position = new TimeSpan(0, 0, 0);
                MainWindow.Timer.Start();
            }
        }
        private static void MediaPlayer_MediaEnded(object? sender, EventArgs e)
        {
            //thisSong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
            // ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));

            if (isrepeat)
            {
                thisSong.Open = true;
                HamTuongTac(thisSong);
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    thisSong.Duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txblDuration.Text
                        = new TimeSpan(0, (int)(thisSong.Duration / 60), (int)(thisSong.Duration % 60)).ToString(@"mm\:ss");
                    ((MainWindow)System.Windows.Application.Current.MainWindow).timelineSlider.Maximum = thisSong.Duration;
                    thisSong.Position = 0;
                    mediaPlayer.Position = new TimeSpan(0, 0, 0);
                    MainWindow.Timer.Start();
                }
            }
            else if (isshuffle)
            {
                thisSong.Open = true;
                int curindex = thisList.IndexOf(thisSong), index;
                do
                {
                    Random random = new Random();
                    index = random.Next(0, thisList.Count);
                } while (curindex == index);
                MainWindow.getSong = thisList[index];
                HamTuongTac(thisList[index]);
            }
        }
        public static void HamTuongTac(Song song)
        {
            if (song.Open == true)
            {
                mediaPlayer.Stop();
                for (int i = 0; i < thisList.Count; i++)
                {
                    if (thisList[i].Open == false) thisList[i].Open = true;
                    thisList[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                }
                if (occupying != null)
                    for (int i = 0; i < occupying.Count; i++)
                    {
                        if (occupying[i].Open == false) occupying[i].Open = true;
                        occupying[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                    }
                ((MainWindow)System.Windows.Application.Current.MainWindow).Anh.Source = new BitmapImage(new Uri(song.linkanh));
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenBH.Content = song.songName;
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenTG.Content = song.singerName;
            }
            filename = song.savepath;

            if (song.Open == true)
            {
                isplaying = true;
                openmussic();
                song.Open = false;
            }

            isplaying = !isplaying;
            if (isplaying == true)
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                MainWindow.Timer.Stop();
            }
            else
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png";
                ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                MainWindow.Timer.Start();
            }

            MainWindow.getSong = song;
            thisSong = song;
        }
    }
}
