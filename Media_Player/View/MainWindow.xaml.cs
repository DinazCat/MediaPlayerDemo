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
            frame.NavigationService.Navigate(page1);
            View.Add(page1);
            CurrentView = page1;
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

        bool OldVolume = true;
        double OldvolumeSize;
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Phatnhac.mediaPlayer.Volume = (double)volumeSlider.Value;
            if (OldVolume == true)
            {
                OldvolumeSize = (double)volumeSlider.Value;
                OldVolume = false;
            }
            if ((double)volumeSlider.Value == 0)
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "mute.png"));
            else
                Volume.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "volume.png"));
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
            if(isDraging)
            {
                getSong.Position = timelineSlider.Value;
                Phatnhac.mediaPlayer.Position = new TimeSpan(0, 0, (int)getSong.Position);
            }    
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
        //Nút back view
        public static List<UserControl> View = new List<UserControl>();
        public static UserControl CurrentView;
        public static bool CheckBack = false;
        int index;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            index = View.IndexOf(CurrentView);
            if (index > 0)
            {
                frame.NavigationService.Navigate(View[index - 1]);
                CurrentView = View[index - 1];
                CheckBack = true;
            }

        }
        //Nút Next view
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            index = View.IndexOf(CurrentView);
            if (index < View.Count - 1)
            {
                frame.NavigationService.Navigate(View[index + 1]);
                CurrentView = View[index + 1];
            }
        }
        HomeView page1 = new HomeView();
        LibView page2 = new LibView();
        GenresView page3 = new GenresView();
        LikedView page4 = new LikedView();
        UserControl page;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            page = page1;
            frame.NavigationService.Navigate(page);
            View.Add(page1);
            CurrentView = page1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            page = page2;
            frame.NavigationService.Navigate(page);
            View.Add(page2);
            CurrentView = page2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            page = page3;

            frame.NavigationService.Navigate(page);
            View.Add(page3);
            CurrentView = page3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            page = page4;
            frame.NavigationService.Navigate(page);
            View.Add(page4);
            CurrentView = page4;
        }
        // Volume click
        private void Button_Click_6(object sender, RoutedEventArgs e)
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

       
    }
}
