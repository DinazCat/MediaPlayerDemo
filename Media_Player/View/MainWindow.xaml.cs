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
using Media_Player.View;
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
            View.Add(homepage);
            CurrentView = homepage;
            Phatnhac.Init();
            getList = Phatnhac.thisList;
            getSong = Phatnhac.thisSong;
            Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png"));
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
        private static string _getListName;
        public static string getListName { get { return _getListName; } set { _getListName = value; } }
        private static string _userName;
        public static string userName { get { return _userName; } set { _userName = value; }}
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
        public static List<UserControl> View = new List<UserControl>();
        public static UserControl CurrentView;
        public static bool CheckBack = false;
        int index;
        private void backViewBtn_Click(object sender, RoutedEventArgs e)
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
        private void nextViewBtn_Click(object sender, RoutedEventArgs e)
        {
            index = View.IndexOf(CurrentView);
            if (index < View.Count - 1)
            {
                frame.NavigationService.Navigate(View[index + 1]);
                CurrentView = View[index + 1];
            }
        }
        HomeView homepage;
        LibView libpage;
        GenresView genrepage = new GenresView();
        LikedView likedpage;
        UserControl page;
        private void mainViewBtn_Click(object sender, RoutedEventArgs e)
        {
            // page = page1;
            txtKetqua.Text = "";
            frame.NavigationService.Navigate(homepage);
            View.Add(homepage);
            CurrentView = homepage;
        }

        private void libraryViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                if (loginwd.isClosed)
                    return;
            }
            libpage = new LibView();
           // LibView LV = new LibView(LibView.ListenedList);
            txtKetqua.Text = "";
            page = libpage;
            frame.NavigationService.Navigate(page);
            View.Add(libpage);
            CurrentView = libpage;
        }

        private void genresViewBtn_Click(object sender, RoutedEventArgs e)
        {
            page = genrepage;
            txtKetqua.Text = "";
            frame.NavigationService.Navigate(page);
            View.Add(genrepage);
            CurrentView = genrepage;
        }

        private void chartViewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void likedViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                if (loginwd.isClosed)
                    return;
            }
            likedpage = new LikedView();
            txtKetqua.Text = "";
            page = likedpage;
            frame.NavigationService.Navigate(page);
            View.Add(likedpage);
            CurrentView = likedpage;
        }
        private void volumeBtn_Click(object sender, RoutedEventArgs e)
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
        PlayListView playingPLView;
        PlayList curPlaylist;
        private void openCurPLBtn_Click(object sender, RoutedEventArgs e)
        {           
            PlayList curPlaylist = new PlayList();
            curPlaylist.songs = getList;
            playingPLView = new PlayListView(getList, getListName);            

            page = playingPLView;
            frame.NavigationService.Navigate(page);
            View.Add(playingPLView);
            CurrentView = playingPLView;

            scrollviewer.ScrollToTop();

        }
        PlayListView newPLView;
        private void addNewPLBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                if (loginwd.isClosed)
                    return;
            }
            AddPlaylistWindow wd = new AddPlaylistWindow();
            wd.AddNewPlaylistEvent += Wd_AddNewPlaylistEvent;
            wd.ShowDialog();
        }

        private void Wd_AddNewPlaylistEvent(string playlistName)
        {
            newPLView = new PlayListView();
            newPLView.txtTitle.Text = playlistName;

            page = newPLView;
            frame.NavigationService.Navigate(page);
            View.Add(newPLView);
            CurrentView = newPLView;

            Random rd = new Random();
            int i = rd.Next(1, 6);
            string PLPictureBydefault = "PLPictureBydefault" + i + ".webp";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Playlist(Title, Picture, UserName) values(N'" + playlistName + "','" + PLPictureBydefault + "','" + userName + "')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void addSongToPLbtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                return;
            }

            List<PlayList> userPlaylists = new List<PlayList>();
            String query = "SELECT * FROM Playlist WHERE UserName=@UserName";

            SqlParameter param = new SqlParameter("@UserName", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        userPlaylists.Add(new PlayList()
                        {
                            title = dr[0].ToString()
                        });
                    }
                }
            }
            userPlaylistMenu.ItemsSource = userPlaylists;
            addSongToPLBtn.ContextMenu.IsOpen = true;
        }

        private void playlist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayList playList = (sender as StackPanel).DataContext as PlayList;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Belong values(N'" + playList.title + "', N'" + getSong.songName + "')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Heart_Click(object sender, RoutedEventArgs e)
        {
            if (userName == null) return;
            string query = "SELECT * FROM Liked L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
            SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
            DataTable dt;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            if (getSong.isLike == false)
            {
                Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png"));
                getSong.isLike = true;
                string m = "Insert into [Liked] values(N'" + MainWindow.userName + "',N'" + getSong.songName + "','" + dt.Rows.Count + "' )";
                Phatnhac.SqlInteract(m);
            }    
            else
            {
                Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png"));
                getSong.isLike = false;
                string m = "delete from [Liked] where Songname=N'" + getSong.songName + "' and UserName = N'" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);

                m = "Update [Liked] Set STT = STT - 1 where UserName = '" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);
            }    
        }
    }
}
