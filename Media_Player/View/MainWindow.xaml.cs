using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            View.Add(page1);
            CurrentView = page1;
            Phatnhac.Init();
            getList = Phatnhac.thisList;
            getSong = Phatnhac.thisSong;
        }
        public static double oldPosition;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (getSong.Position - oldPosition > 0)
                Phatnhac.mediaPlayer.Position = new TimeSpan(0, 0, (int)getSong.Position);
            getSong.Position += 1;
            oldPosition = getSong.Position;
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
            if (OldVolume == true && (double)volumeSlider.Value !=0)
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
            getSong.Position = timelineSlider.Value;
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
            txtKetqua.Text = "";
            index = View.IndexOf(CurrentView);
            if (index > 0)
            {
                frame.NavigationService.Navigate(View[index - 1]);
                CurrentView = View[index - 1];
                CheckBack = true;
            }
            else if(index == 0) frame.NavigationService.Navigate(View[index]);
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
        HomeView page1;
        LibView page2 = new LibView() ;
        GenresView page3 = new GenresView();
        LikedView page4 = new LikedView();
        UserControl page;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // page = page1;
            txtKetqua.Text = "";
            frame.NavigationService.Navigate(page1);
            View.Add(page1);
            CurrentView = page1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtKetqua.Text = "";
            page = page2;
            frame.NavigationService.Navigate(page);
            View.Add(page2);
            CurrentView = page2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            page = page3;
            txtKetqua.Text = "";
            frame.NavigationService.Navigate(page);
            View.Add(page3);
            CurrentView = page3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            txtKetqua.Text = "";
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
       // ResultView pageKq = new ResultView();
        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            if (txtKetqua.Text != "")
            {
                ResultView.setTextKq = "Không tìm thấy kết quả nào";
                ResultView.Result = new List<Song>();
                ResultView.Result.Clear();
                string query = "SELECT * FROM Song";
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString().ToUpper().Contains(txtKetqua.Text.ToUpper()) || dr[1].ToString().ToUpper().Contains(txtKetqua.Text.ToUpper()))
                            {
                                ResultView.Result.Add(new Song()
                                {
                                    songName = dr[0].ToString(),
                                    singerName = dr[1].ToString(),
                                    linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                                    savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                                    getPL = "Result"
                                });
                                ResultView.setTextKq = "Kết quả tìm kiếm";
                            }
                        }
                    }
                }
                for (int i = 0; i < ResultView.Result.Count - 1; i++)
                {
                    string namesong = ResultView.Result[i].songName;
                    for (int j = i + 1; j < ResultView.Result.Count; j++)
                    {
                        if (ResultView.Result[j].songName == namesong)
                        {
                            ResultView.Result.RemoveAt(j);
                        }
                    }
                }
            }
            else ResultView.setTextKq = "Có thể bạn muốn tìm";
            ResultView pageKq = new ResultView();
            frame.NavigationService.Navigate(pageKq);
            View.Add(pageKq);
            CurrentView = pageKq;
        }



        private void txtKetqua_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtKetqua.Text != "")
            {
                ResultView.setTextKq = "Không tìm thấy kết quả nào";
                ResultView.Result = new List<Song>();
                ResultView.Result.Clear();
                string query = "SELECT * FROM Song";
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString().ToUpper().Contains(txtKetqua.Text.ToUpper()) || dr[1].ToString().ToUpper().Contains(txtKetqua.Text.ToUpper()))
                            {
                                ResultView.Result.Add(new Song()
                                {
                                    songName = dr[0].ToString(),
                                    singerName = dr[1].ToString(),
                                    linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                                    savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                                    getPL = "Result"
                                });
                                ResultView.setTextKq = "Kết quả tìm kiếm";
                            }
                        }
                    }
                }
                for (int i = 0; i < ResultView.Result.Count - 1; i++)
                {
                    string namesong = ResultView.Result[i].songName;
                    for (int j = i + 1; j < ResultView.Result.Count; j++)
                    {
                        if (ResultView.Result[j].songName == namesong)
                        {
                            ResultView.Result.RemoveAt(j);
                        }
                    }
                }
            }
            else ResultView.setTextKq = "Có thể bạn muốn tìm";
                ResultView pageKq = new ResultView();
                frame.NavigationService.Navigate(pageKq);
            

        }

    }
}
