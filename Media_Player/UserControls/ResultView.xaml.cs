using Media_Player.Model;
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
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {
        List<Song> listSongs;
        List<PlayList> listPlaylists;
        List<PlayList> listArtists;
        public ResultView()
        {
            InitializeComponent();

        }
        string keyword;
        public ResultView(string keyword)
        {
            InitializeComponent();
            this.keyword = keyword;

            listSongs = new List<Song>();
            CreateListSongResult();
            ListSongResult.ItemsSource = listSongs;
            if (listSongs.Count > 0)
                Baihat.Text = "Bài hát";

            listPlaylists = new List<PlayList>();
            CreateListPlaylistResult();
            ListPLResult.ItemsSource = listPlaylists;
            if (listPlaylists.Count > 0)
                PlaylistAlbum.Text = "Playlist/Album";

            listArtists = new List<PlayList>();
            CreateListArtistResult();
            ListArtistResult.ItemsSource = listArtists;
            if (listArtists.Count > 0)
                Nghesi.Text = "Nghệ sĩ";

            if (listSongs.Count > 0 || listPlaylists.Count > 0 || listArtists.Count > 0)
                txtKQ.Text = "Kết Quả Tìm Kiếm";
            else txtKQ.Text = "Không Tìm Thấy Kết Quả Nào";
        }

        void CreateListSongResult()
        {
            string query = "SELECT DISTINCT Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song";
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0].ToString().ToUpper().Contains(keyword.ToUpper()) || dr[1].ToString().ToUpper().Contains(keyword.ToUpper()) || dr["Album"].ToString().ToUpper().Contains(keyword.ToUpper()))
                        {
                            listSongs.Add(new Song()
                            {
                                songName = dr[0].ToString(),
                                singerName = dr[1].ToString(),
                                album = dr["Album"].ToString(),
                                linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                                savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                                time = dr["Duration"].ToString(),
                                getList = listSongs
                            });
                        }
                    }
                }
            }
        }
        void CreateListPlaylistResult()
        {
            string query = "SELECT *  FROM Album";
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0].ToString().ToUpper().Contains(keyword.ToUpper()) || dr[1].ToString().ToUpper().Contains(keyword.ToUpper()))
                        {
                            listPlaylists.Add(new PlayList()
                            {
                                title = dr[0].ToString(),
                                picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[2].ToString(),
                                description = "Nghệ sĩ: " + dr[1] + ", Nám phát hành: " + dr[3]
                            });
                        }
                    }
                }
            }
            query = "SELECT * FROM Playlist WHERE UserName is NULL";
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0].ToString().ToUpper().Contains(keyword.ToUpper()))
                        {
                            listPlaylists.Add(new PlayList()
                            {
                                title = dr[0].ToString(),
                                picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[1].ToString()
                            });
                        }
                    }
                }
            }
        }
        void CreateListArtistResult()
        {
            string query = "SELECT DISTINCT S.Name, S.Artist, A.Picture FROM Song S JOIN Artist A ON A.Name=S.Artist";
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0].ToString().ToUpper().Contains(keyword.ToUpper()) || dr[1].ToString().ToUpper().Contains(keyword.ToUpper()))
                        {
                            bool checkExist = false;
                            foreach (PlayList playList in listArtists)
                                if (playList.title == dr[1].ToString())
                                {
                                    checkExist = true; break;
                                }
                            if (!checkExist)
                            {
                                listArtists.Add(new PlayList()
                                {
                                    title = dr[1].ToString(),
                                    picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Picture"].ToString()
                                });
                            }
                        }
                    }
                }
            }
        }
        PlayListView page = new PlayListView();
        UserControl p;
        private void PlaylistOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;
            List<Song> songs = new List<Song>();
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Album=@Album";
            SqlParameter param1 = new SqlParameter("@Album", playList.title);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                else
                {
                    query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
                    param1 = new SqlParameter("@PlaylistName", playList.title);
                    using (SqlDataReader reader1 = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader1);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                int n = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    songs.Add(new Song()
                    {
                        songName = dr["Name"].ToString(),
                        singerName = dr["Artist"].ToString(),
                        album = dr["Album"].ToString(),
                        linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                        savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                        time = dr["Duration"].ToString(),
                        getPL = playList.title
                    });
                    n++;
                }
                foreach (Song s in songs)
                {
                    s.getList = songs;
                }
            }
            page = new PlayListView(songs, playList.title);
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(p);
                MainWindow.View.RemoveAt(index - 1);
                MainWindow.CheckBack = false;
            }
        }

        private void ArtistOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;
            List<Song> songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Artist=@Artist";
            SqlParameter param1 = new SqlParameter("@Artist", playList.title);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        songs.Add(new Song()
                        {
                            songName = dr["Name"].ToString(),
                            singerName = dr["Artist"].ToString(),
                            album = dr["Album"].ToString(),
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                            time = dr["Duration"].ToString(),
                            getPL = playList.title
                        });
                        n++;
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }
            page = new PlayListView(songs, playList.title);
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(p);
                MainWindow.View.RemoveAt(index - 1);
                MainWindow.CheckBack = false;
            }
        }
    }
}
