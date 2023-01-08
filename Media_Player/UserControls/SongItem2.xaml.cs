using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections;
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
using Media_Player.View;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for SongItem2.xaml
    /// </summary>
    public partial class SongItem2 : UserControl
    {
        public SongItem2()
        {
            InitializeComponent();
        }
        public EventHandler onAction = null;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;          

            MainWindow.getListName = song.getPL;
            MainWindow.getList = song.getList;
            Phatnhac.thisList = song.getList;
            Phatnhac.HamTuongTac(song);
            Phatnhac.occupying = Phatnhac.thisList;
            if (onAction != null) onAction.Invoke(this, e);
        }

        private void songpnl_mouseEnter(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Visible;
            this.Picture.Opacity = 0.6;
        }

        private void songpnl_mouseLeave(object sender, MouseEventArgs e)
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
            if (MainWindow.getListName != null && MainWindow.getListName == song.singerName)
            {
                page = new PlayListView(MainWindow.getList, song.singerName);
            }
            else
            {
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
                            {
                                s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                                s.isLike = true;
                            }

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
            }
            p = page;
            MainWindow.nvgPlayListView(p);
        }
        List<PlayList> userPlaylists;
        Song selectedSong;
        private void songItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedSong = (sender as Border).DataContext as Song;
            if (selectedSong.getLoaiPL != "userPL")
                deleteSongFromPL.Visibility = Visibility.Collapsed;
            if (MainWindow.userName != null)
            {
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
                userPlaylistMenuItem.Visibility = Visibility.Visible;
            }
            else userPlaylistMenuItem.Visibility = Visibility.Collapsed;
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
        private void addSongToPlayingList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getList.Add(selectedSong);
            Phatnhac.thisList = MainWindow.getList;
        }

        private void addSongToPlayNext_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getList.Insert(MainWindow.getList.IndexOf(MainWindow.getSong) + 1, selectedSong);
            Phatnhac.thisList = MainWindow.getList;
        }

        private void addSongToUserPL_Click(object sender, RoutedEventArgs e)
        {
            if(userPlaylistMenuItem.Items.Count < 1)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Thông báo", "Bạn chưa có playlist nào!");
                messageBox.ShowDialog();
            }
        }
    }
}
