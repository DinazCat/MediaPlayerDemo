using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for SongItem.xaml
    /// </summary>
    public partial class SongItem : UserControl
    {
        public SongItem()
        {
            InitializeComponent();
        }        

        public EventHandler onAction = null;
        private void BtnPlay_click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            if (BtnPlay.Content.ToString() == "Result")
            {
                MainWindow.getList = ResultView.result;
                Phatnhac.thisList = ResultView.result;
            }
            else
            {

                MainWindow.getListName = song.getPL;
                MainWindow.getList = Phatnhac.thisList = song.getList;
            }
            Phatnhac.HamTuongTac(song);
            Phatnhac.occupying = Phatnhac.thisList;
            if (onAction != null) onAction.Invoke(this, e);
        }

        private void songitem_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Visible;
            this.Picture.Opacity = 0.6;
        }

        private void songitem_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Hidden;
            this.Picture.Opacity = 1;
        }
        List<Song> songs;
        PlayListView page = new PlayListView();
        UserControl p;
        private void artistBtn_click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            PlayListView.Title = song.singerName;

            songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Artist=@Artist";
            SqlParameter param1 = new SqlParameter("@Artist", song.singerName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Song s = new Song();
                        s.songName = dr[0].ToString();
                        s.singerName = dr[1].ToString();
                        s.album = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = song.singerName;
                        if (PlayListView.CheckLiked(s.songName) == true)
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                        songs.Add(s);
                        n++;
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }

            page = new PlayListView(songs, song.singerName);
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            MainWindow.CountPage = -1;
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(p);
                MainWindow.View.RemoveAt(index - 1);
                MainWindow.CheckBack = false;
            }
        }

        private void albumBtn_click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            PlayListView.Title = song.album;

            songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Album=@Album";
            SqlParameter param1 = new SqlParameter("@Album", song.album);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Song s = new Song();
                        s.songName = dr[0].ToString();
                        s.singerName = dr[1].ToString();
                        s.album = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = song.album;
                        if (PlayListView.CheckLiked(s.songName) == true)
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                        songs.Add(s);
                        n++;
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }

            page = new PlayListView(songs, song.album);
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            MainWindow.CountPage = -1;
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(p);
                MainWindow.View.RemoveAt(index - 1);
                MainWindow.CheckBack = false;
            }
        }

        private void LibHeart_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
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
            Song song = (sender as Button).DataContext as Song;
            if (song.isLike == false)
            {
                song.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                if (song.songName == MainWindow.getSong.songName)
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png"));
                song.isLike = true;
                string m = "Insert into [Liked] values(N'" + MainWindow.userName + "',N'" + song.songName + "','" + dt.Rows.Count + "' )";
                Phatnhac.SqlInteract(m);
            }
            else
            {
                song.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png";
                if (song.songName == MainWindow.getSong.songName)
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png"));
                song.isLike = false;
                string m = "delete from [Liked] where Songname=N'" + song.songName + "' and UserName ='" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);
                m = "Update [Liked] Set STT = STT - 1 where UserName = '" + MainWindow.userName + "'";
                Phatnhac.SqlInteract(m);

            }
        }

        List<PlayList> userPlaylists;
        Song selectedSong;
        private void songItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.userName == null)
                return;           
            selectedSong = (sender as Border).DataContext as Song;
            if (selectedSong.getLoaiPL != "userPL")
                deleteSongFromPL.Visibility = Visibility.Collapsed;
            userPlaylists = new List<PlayList>();
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
            userPlaylistMenuItem.ItemsSource = userPlaylists;
            songItemContextMenu.Visibility = Visibility.Visible;
            songItemContextMenu.IsOpen = true;
        }

        private void playlist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.userName == null)
                return;
            PlayList playList = (sender as StackPanel).DataContext as PlayList;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Belong values(N'" + playList.title + "', N'" + selectedSong.songName + "')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void deleteSongFromCurPL_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
                return;

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Belong where SongName=N'" + selectedSong.songName + "' and PlaylistName=N'" + selectedSong.getPL + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteReader();
            con.Close();

            int index = PlayListView.listSongs.IndexOf(selectedSong);
            PlayListView.listSongs.RemoveAt(index);
            PlayListView.userListView.Items.Refresh();
        }
    }
}
