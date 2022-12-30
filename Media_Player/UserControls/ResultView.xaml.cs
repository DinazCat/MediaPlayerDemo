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
                            Song s = new Song();
                            s.songName = dr[0].ToString();
                            s.singerName = dr[1].ToString();
                            s.album = dr[2].ToString();
                            s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                            s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                            s.time = dr["Duration"].ToString();
                            s.getList = listSongs;
                            if (PlayListView.CheckLiked(s.songName) == true)
                            {
                                s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                                s.isLike = true;
                            }
                            listSongs.Add(s);
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
            //string query1 = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Album=@Album";
            SqlParameter param = new SqlParameter("@Album", playList.title);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Song s = new Song();
                        s.songName = dr[0].ToString();
                        s.singerName = dr[1].ToString();
                        s.album = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = playList.title;
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }
                        songs.Add(s);
                        
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }
            query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
            param = new SqlParameter("@PlaylistName", playList.title);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Song s = new Song();
                        s.songName = dr[0].ToString();
                        s.singerName = dr[1].ToString();
                        s.album = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = playList.title;
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }
                        songs.Add(s);
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }
            switch (playList.title)
            {
                case "Nhạc Pop":
                    songs = GenresView.PopList.songs;
                    break;
                case "Nhạc Hàn Quốc":
                    songs = GenresView.KoreaList.songs;
                    break;
                case "Nhạc Âu Mỹ":
                    songs = GenresView.USUKList.songs;
                    break;
                case "Nhạc Trung Quốc":
                    songs = GenresView.ChinaList.songs;
                    break;
                case "Nhạc Việt Nam":
                    songs = GenresView.VNList.songs;
                    break;
                case "Nhạc Nhật Bản":
                    songs = GenresView.JapanList.songs;
                    break;
                case "Nhạc EDM":
                    songs = GenresView.EDMList.songs;
                    break;
                case "Nhạc Cổ Điển":
                    songs = GenresView.ClassicList.songs;
                    break;
                case "Nhạc Phim":
                    songs = GenresView.OSTList.songs;
                    break;
                case "Nhạc R&B":
                    songs = GenresView.RnBList.songs;
                    break;
                case "Nhạc Jazz":
                    songs = GenresView.JazzList.songs;
                    break;
                case "Nhạc Không Lời":
                    songs = GenresView.InstrumentalList.songs;
                    break;
                case "Nhạc Acoustic":
                    songs = GenresView.AcousticList.songs;
                    break;
                case "Nhạc Hip Hop":
                    songs = GenresView.HipHopList.songs;
                    break;
                case "Nhạc Tâm Trạng":
                    songs = GenresView.EmotionalList.songs;
                    break;
                case "Nhạc Thư Giãn":
                    songs = GenresView.RelaxingList.songs;
                    break;
                case "Nhạc Tập Trung":
                    songs = GenresView.ConcentrationList.songs;
                    break;
                case "Có Thể Bạn Sẽ Thích":
                    songs = HomeView.MaybeulikeList.songs;
                    break;
                case "Phổ Biến":
                    songs = HomeView.PopularList.songs;
                    break;
                case "Mới Phát Hành":
                    songs = HomeView.NewReleasesList.songs;
                    break;

            }
            page = new PlayListView(songs, playList.title);
            p = page;
            MainWindow.nvgPlayListView(p);
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
                        Song s = new Song();
                        s.songName = dr[0].ToString();
                        s.singerName = dr[1].ToString();
                        s.album = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = playList.title;
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
            page = new PlayListView(songs, playList.title);
            p = page;
            MainWindow.nvgPlayListView(p);
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
        }
    }
}
