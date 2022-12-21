using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "back.png"));
            Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));

        }
        public static double oldPosition;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (getSong.Position - oldPosition > 0)
                Phatnhac.mediaPlayer.Position = new TimeSpan(0, 0, (int)getSong.Position);
            getSong.Position += 1;
            oldPosition = getSong.Position;
            timelineSlider.Value = getSong.Position;
            if (isSleepTimerRun && remainTime != 0)
            {
                remainTime--;
                remainTimetxbl.Text = "Thời gian còn lại: " + remainTime / 3600 + ":" + remainTime % 3600 / 60 + ":" + remainTime % 3600 % 60;
            }                
            else if(isSleepTimerRun)
            {               
                getSong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                isSleepTimerRun = false;
                remainTimetxbl.Text = "";
                sleeptimerMenuItem.Foreground = sleeptimerIcon.Foreground = new SolidColorBrush(Colors.White);
                Phatnhac.mediaPlayer.Pause();
                Timer.Stop();
            }
        }

        public static DispatcherTimer Timer;
        private static List<Song> _getList;
        public static List<Song> getList { get { return _getList; } set { _getList = value; } }
        private static Song _getSong;
        public static Song getSong { get { return _getSong; } set { _getSong = value; } }
        private static string _getListName;
        public static string getListName { get { return _getListName; } set { _getListName = value; } }
        private static string _userName;
        private static List<Song> _curList;
        public static List<Song> curList { get { return _curList; } set { _curList = value; } }
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
        public static int index = -2;
        public static int CountPage = -1;
        private void backViewBtn_Click(object sender, RoutedEventArgs e)
        {
            txbTimKiem.Text = "";
            if (CountPage == -1)
                for (int i = 0; i < View.Count; i++)
                {
                    if (View[i] == CurrentView) index = i;
                    CountPage = View.Count;
                }
            else
            {
                for (int i = 0; i < CountPage; i++)
                {
                    if (View[i] == CurrentView) index = i;
                }
            }
            if (index > 0)
            {
                if (index == 1)
                    Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "back.png"));
                Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "cannext.png"));
                frame.NavigationService.Navigate(View[index - 1]);
                CurrentView = View[index - 1];
                CheckBack = true;
                CountPage -= 1;
            }
           
            //if(index == 0 && CountPage == View.Count)
            //    Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));

        }
        private void nextViewBtn_Click(object sender, RoutedEventArgs e)
        {
            txbTimKiem.Text = "";
            if (index < View.Count && index != -2)
            {
                if(index == View.Count-1)
                    Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
                Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "canback.png"));
                if (index == 0)
                {
                    frame.NavigationService.Navigate(View[index + 1]);
                }
                else
                    frame.NavigationService.Navigate(View[index]);
                CurrentView = View[index];
                index += 1;
                CheckBack = false;
                if (index - 1 < View.Count)
                    CountPage += 1;
            }
        }
        HomeView homepage;
        LibView libpage;
        GenresView genrepage = new GenresView();
        public static LikedView likedpage;
        UserControl page;        

        private void mainViewBtn_Click(object sender, RoutedEventArgs e)
        {
            // page = page1;
            txbTimKiem.Text = "";
            Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "back.png"));
            if(CurrentView != homepage)
            {
                frame.NavigationService.Navigate(homepage);
                View.Add(homepage);
                CurrentView = homepage;
                CheckBack = false;
                CountPage = -1;
            }           
        }

        private void libraryViewBtn_Click(object sender, RoutedEventArgs e)
        {
            txbTimKiem.Text = "";
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                this.Opacity = 0.3;
                loginwd.ShowDialog();
                this.Opacity = 1;
                if (loginwd.isClosed)
                    return;
            }
            if(index == 1 && CheckBack == true)
            {
                View.Clear();
                View.Add(homepage);
                Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
                index = -2;
            } 
                
            libpage = new LibView();
            if (CurrentView != libpage)
            {
                Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "canback.png"));
                page = libpage;
                frame.NavigationService.Navigate(page);
                View.Add(libpage);
                CurrentView = libpage;
                CheckBack = false;
                CountPage = -1;
            }            
        }

        private void genresViewBtn_Click(object sender, RoutedEventArgs e)
        {
            txbTimKiem.Text = "";
            Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "canback.png"));
            page = genrepage;
            if (index == 1 && CheckBack == true)
            {
                View.Clear();
                View.Add(homepage);
                Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
                index = -2;
            }
            if (CurrentView != page)
            {
                frame.NavigationService.Navigate(page);
                View.Add(genrepage);
                CurrentView = genrepage;
                CheckBack = false;
                CountPage = -1;
            }
        }

        private void likedViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                this.Opacity = 0.3;
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                this.Opacity = 1;
                if (loginwd.isClosed)
                    return;
            }
            likedpage = new LikedView();
            Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "canback.png"));
            if (index == 1 && CheckBack == true)
            {
                View.Clear();
                View.Add(homepage);
                Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
                index = -2;
            }
            if (CurrentView!= likedpage)
            {
                page = likedpage;
                frame.NavigationService.Navigate(page);
                View.Add(likedpage);
                CurrentView = likedpage;
                CheckBack = false;
                CountPage = -1;
            }

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
        ResultView pageKq;
        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            if (txbTimKiem.Text != "")
            {
                pageKq = new ResultView(txbTimKiem.Text);
                frame.NavigationService.Navigate(pageKq);
                View.Add(pageKq);
                CurrentView = pageKq;
            }
        }
        private void txtbFind_KeyEnterDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnFind_Click(sender, e);
                FindPopup.IsOpen = false;
            }
        }

        private void txtbFind_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txbTimKiem.Text != "")
            {
                List<Song> searchedSongs = new List<Song>();
                string query = "SELECT DISTINCT Name, Thumbnail FROM Song";
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString().ToUpper().Contains(txbTimKiem.Text.ToUpper()))
                            {
                                if (searchedSongs.Count < 6)
                                {
                                    searchedSongs.Add(new Song()
                                    {
                                        songName = dr[0].ToString(),
                                        linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[1],
                                    });
                                }
                                else break;
                            }
                        }
                    }
                }
                query = "SELECT * FROM Artist";
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString().ToUpper().Contains(txbTimKiem.Text.ToUpper()))
                            {
                                if (searchedSongs.Count < 9)
                                {
                                    searchedSongs.Add(new Song()
                                    {
                                        songName = dr[0].ToString(),
                                        linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[1],
                                    });
                                }
                                else break;
                            }
                        }
                    }
                }
                query = "SELECT * FROM Album";
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString().ToUpper().Contains(txbTimKiem.Text.ToUpper()))
                            {
                                if (searchedSongs.Count < 9)
                                {
                                    searchedSongs.Add(new Song()
                                    {
                                        songName = dr[0].ToString(),
                                        linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[2],
                                    });
                                }
                                else break;
                            }
                        }
                    }
                }
                listSearchSong.ItemsSource = searchedSongs;
            }
        }
        private void txtbFind_GotFocus(object sender, RoutedEventArgs e)
        {
            FindPopup.IsOpen = true;
        }

        private void txtbFind_LostFocus(object sender, RoutedEventArgs e)
        {
            FindPopup.IsOpen = false;
        }

        private void searchItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Song song = (sender as Grid).DataContext as Song;
            pageKq = new ResultView(song.songName);
            frame.NavigationService.Navigate(pageKq);
            View.Add(pageKq);
            CurrentView = pageKq;

        }
        PlayListView playingPLView;
        PlayList curPlaylist;
        private void openCurPLBtn_Click(object sender, RoutedEventArgs e)
        {           
            PlayList curPlaylist = new PlayList();
            curPlaylist.songs = getList;
            playingPLView = new PlayListView(getList, getListName);
            Back.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "canback.png"));
            page = playingPLView;
            if (index == 1 && CheckBack == true)
            {
                View.Clear();
                View.Add(homepage);
                Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
                index = -2;
            }
            if (CurrentView != page)
            {
                frame.NavigationService.Navigate(page);
                View.Add(playingPLView);
                CurrentView = playingPLView;
                CheckBack = false;
                CountPage = -1;
            }            
        }
        PlayListView newPLView;
        private void addNewPLBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                this.Opacity = 0.3;
                loginwd.ShowDialog();
                this.Opacity = 1;
                if (loginwd.isClosed)
                    return;
            }
            AddPlaylistWindow wd = new AddPlaylistWindow();
            this.Opacity = 0.3;
            wd.AddNewPlaylistEvent += Wd_AddNewPlaylistEvent;
            wd.ShowDialog();
            this.Opacity = 1;
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
                this.Opacity = 0.3;
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                this.Opacity = 1;
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
            if (userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                this.Opacity = 0.3;
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                this.Opacity = 1;
                return;
            }
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
                getSong.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                getSong.isLike = true;
                string m = "Insert into [Liked] values(N'" + MainWindow.userName + "',N'" + getSong.songName + "','" + dt.Rows.Count + "' )";
                Phatnhac.SqlInteract(m);
            }    
            else
            {
                Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png"));
                getSong.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png";
                getSong.isLike = false;
                string m = "delete from [Liked] where Songname=N'" + getSong.songName + "' and UserName = N'" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);

                m = "Update [Liked] Set STT = STT - 1 where UserName = '" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);
            }    
        }

        private void otherOptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            otherOptionsMenu.IsOpen = true;
        }

        private void timerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isSleepTimerRun)
            {
                SleepTimer sleepTimer = new SleepTimer();
                sleepTimer.SetSleepTimerEvent += SleepTimer_SetSleepTimerEvent;
                this.Opacity = 0.3;
                sleepTimer.ShowDialog();
                this.Opacity = 1;
                if (isSleepTimerRun)
                    sleeptimerMenuItem.Foreground = sleeptimerIcon.Foreground = new SolidColorBrush(Colors.CadetBlue);
            }
            else
            {
                ConfirmationDialog confirmationDialog = new ConfirmationDialog("XÓA HẸN GIỜ","Bạn có chắc chắn muốn xóa hẹn giờ?");
                confirmationDialog.DialogResultEvent += ConfirmationDialog_DialogResultEvent;
                this.Opacity = 0.3;
                confirmationDialog.ShowDialog();
                this.Opacity = 1;
            }
        }
        
        int remainTime = -1;
        bool isSleepTimerRun = false;
        private void SleepTimer_SetSleepTimerEvent(int totalseconds)
        {
            remainTime = totalseconds;
            isSleepTimerRun= true;
        }
        private void ConfirmationDialog_DialogResultEvent(string result)
        {
            if (result == "Yes")
            {
                sleeptimerMenuItem.Foreground = sleeptimerIcon.Foreground = new SolidColorBrush(Colors.White);
                isSleepTimerRun = false;
                remainTimetxbl.Text = "";
            }
        }


        private void autoPlayToggle_Checked(object sender, RoutedEventArgs e)
        {
            Phatnhac.isAutoplay = true;
        }

        private void autoPlayToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            Phatnhac.isAutoplay = false;
        }

        private void speed_Checked(object sender, RoutedEventArgs e)
        {
            foreach (MenuItem item in speedMenuItem.Items)
                if (item.IsChecked && item != (sender as MenuItem)) item.IsChecked = false;
            float speed = float.Parse((sender as MenuItem).Header.ToString()) / 10;
            Phatnhac.mediaPlayer.SpeedRatio = speed;
        }
        

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentView == homepage)
            {
                mainView.Opacity = 1;
                libView.Opacity = genresView.Opacity = likedView.Opacity = 0.7;
            }
            else if (CurrentView == libpage)
            {
                libView.Opacity = 1;
                mainView.Opacity = genresView.Opacity = likedView.Opacity = 0.7;
            }
            else if (CurrentView == genrepage)
            {
                genresView.Opacity = 1;
                mainView.Opacity = libView.Opacity = likedView.Opacity = 0.7;
            }
            else if (CurrentView == likedpage)
            {
                likedView.Opacity = 1;
                mainView.Opacity = libView.Opacity = genresView.Opacity = 0.7;
            }
            else likedView.Opacity = mainView.Opacity = libView.Opacity = genresView.Opacity = 0.7;
        }
    }
}
