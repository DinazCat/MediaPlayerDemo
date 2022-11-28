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
using MaterialDesignThemes.Wpf;
using Media_Player.Model;
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
            getList = Phatnhac.thisList;
            getSong = Phatnhac.thisSong;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            getSong.Position++;
            timelineSlider.Value = getSong.Position;
        }

        public static DispatcherTimer Timer;
        private static List<Song> _getList;
        public static List<Song> getList { get { return _getList; } set { _getList = value; } }
        private static Song _getSong;
        public static Song getSong { get { return _getSong; } set { _getSong = value; } }

        private void Backsongbtn_Click(object sender, RoutedEventArgs e)
        {
            
            int index = getList.IndexOf(getSong);
            index -= 1;
            if (getList[index + 1] != getList[0])
            {
                Phatnhac.HamTuongTac(getList[index]);
                getSong = getList[index];
                if (onAction != null) onAction.Invoke(this, e);
            }
        }
        private void ButtonPlay2_Click(object sender, RoutedEventArgs e)
        {
            Phatnhac.isplaying = !Phatnhac.isplaying;
            if (Phatnhac.isplaying == true)
            {
                getSong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                Timer.Stop();
            }
            else
            {
                getSong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                Timer.Start();
            }
        }
        public EventHandler onAction = null;

        private void Nextsongbtn_click(object sender, RoutedEventArgs e)
        {
            int index = getList.IndexOf(getSong);
            index += 1;
            if (getList[index - 1] != getList[getList.Count - 1])
            {
                Phatnhac.HamTuongTac(getList[index]);
                getSong = getList[index];
                if (onAction != null) onAction.Invoke(this, e);
            }
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Phatnhac.mediaPlayer.Volume = (double)volumeSlider.Value;
        }


        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            getSong.Position = timelineSlider.Value;
            Phatnhac.mediaPlayer.Position = new TimeSpan(0, 0, (int)getSong.Position);
            txblPosition.Text = new TimeSpan(0, (int)(getSong.Position / 60), (int)(getSong.Position % 60)).ToString(@"mm\:ss");
        }

        private void shufflebtn_click(object sender, RoutedEventArgs e)
        {
            Phatnhac.isshuffle = !Phatnhac.isshuffle;
            if (Phatnhac.isshuffle)
            {
                shuffleicon.Foreground = new SolidColorBrush(Colors.CadetBlue);
                if (Phatnhac.isrepeat)
                {
                    Phatnhac.isrepeat=!Phatnhac.isrepeat;
                    repeaticon.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            else { shuffleicon.Foreground = new SolidColorBrush(Colors.White); }

        }
        private void repeatbtn_click(object sender, RoutedEventArgs e)
        {
            Phatnhac.isrepeat = !Phatnhac.isrepeat;
            if (Phatnhac.isrepeat)
            {
                repeaticon.Foreground = new SolidColorBrush(Colors.CadetBlue);
                if (Phatnhac.isshuffle)
                {
                    Phatnhac.isshuffle = !Phatnhac.isshuffle;
                    shuffleicon.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            else { repeaticon.Foreground = new SolidColorBrush(Colors.White); }

        }
    }
}
