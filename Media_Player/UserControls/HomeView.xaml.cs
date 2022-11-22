using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
using Media_Player.View;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        List<Song> list;

        public HomeView()
        {
            InitializeComponent();
            list = new List<Song>();

            listp2.ItemsSource = list;
            string[] tennhac = new string[15];
            string[] tencasi = new string[15];
            using (StreamReader sr = new StreamReader("Cothebansethich\\15baicothethich.txt"))
            {
                int i = 0;
                string line;
                while ((line = sr.ReadLine()) != "")
                {
                    tennhac[i] = line;
                    i += 1;
                }
            }
            using (StreamReader tr = new StreamReader("Cothebansethich\\15tencasiP2.txt"))
            {
                int j = 0;
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    tencasi[j] = line;
                    j += 1;
                }
            }
            for (int k = 0; k < 15; k++)
            {
                string linknhac = AppDomain.CurrentDomain.BaseDirectory + "Cothebansethich/" + "15AudioP2\\" + "b" + k + ".mp3";
                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + "Cothebansethich/" + "LinkAnh\\" + "a" + k + ".png";
                list.Add(new Song()
                {
                    songNames = tennhac[k],
                    singerNames = tencasi[k],
                    linkanh = linkAnh,
                    savepath = linknhac
                });
            }
        }

        string filename;
        void openmusic()
        {
            Phatnhac.mediaPlayer.Open(new Uri(filename));
            Phatnhac.Isplaying2 = true;
            Phatnhac.mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
        }

        private void MediaPlayer_MediaOpened(object? sender, EventArgs e)
        {
            if (Phatnhac.mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                thisSong.Duration = Phatnhac.mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ((MainWindow)System.Windows.Application.Current.MainWindow).txblDuration.Text = new TimeSpan(0, (int)(thisSong.Duration / 60), (int)(thisSong.Duration % 60)).ToString(@"mm\:ss");
                ((MainWindow)System.Windows.Application.Current.MainWindow).timelineSlider.Maximum = thisSong.Duration;
                thisSong.Position = 0;
                MainWindow.Timer.Start();
            }
        }

        void HamTuongTac(Song song)
        {
            if (song.Open == true)
            {
                Phatnhac.mediaPlayer.Stop();
                Phatnhac.Isplaying2 = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Open == false) list[i].Open = true;
                    list[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                }
                ((MainWindow)System.Windows.Application.Current.MainWindow).Anh.Source = new BitmapImage(new Uri(song.linkanh));
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenBH.Content = song.songNames;
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenTG.Content = song.singerNames;
            }
            filename = song.savepath;

            if (song.Open == true)
            {
                Phatnhac.isplaying = true;
                openmusic();

                song.Open = false;
            }

            Phatnhac.isplaying = !Phatnhac.isplaying;
            if (Phatnhac.isplaying == true)
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

            MainWindow.getsong = song;
            thisSong = song;
        }
        Song thisSong;
        public EventHandler onAction = null;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            MainWindow.Songs = list;
            HamTuongTac(song);
            if (onAction != null) onAction.Invoke(this, e);
        }
    }
}
