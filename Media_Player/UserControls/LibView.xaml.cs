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
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using Media_Player.ViewModel;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for LibView.xaml
    /// </summary>
    public partial class LibView : UserControl
    {
        public static List<PlayList> userPlaylists;
        List<Song> ListenedList = new List<Song>();
        List<Song> LikedList = new List<Song>();
        List<Song> UpLoadList = new List<Song>();
        List<PlayList> likedPlaylists;
        List<PlayList> likedArtists;
        List<PlayList> likedAlbums;
        public LibView()
        {
            InitializeComponent();
            userPlaylists = new List<PlayList>();
            InitUserList();
            DanhSachPhatlist.ItemsSource = userPlaylists;
            getUserPLs = DanhSachPhatlist;

            InitListenedList(ref ListenedList);
            listListened.ItemsSource = ListenedList;

            InitLikedList(ref LikedList);
            listLiked.ItemsSource = LikedList;

            InitLoadList(ref UpLoadList);
            listUpLoad.ItemsSource = UpLoadList;

            likedPlaylists = new List<PlayList>();
            InitLikedPlaylistsList();
            DanhSachPhatDaThichlist.ItemsSource = likedPlaylists;

            likedArtists= new List<PlayList>();
            InitLikedArtistsList();
            ArtistsList.ItemsSource = likedArtists;

            likedAlbums = new List<PlayList>();
            InitLikedAlbumsList();
            Albumslist.ItemsSource = likedAlbums;
        }
        private static ListView _getUserPLs;
        public static ListView getUserPLs { get { return _getUserPLs; } set { _getUserPLs = value; } }
        void InitUserList()
        {
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
                            title = dr[0].ToString(),
                            picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" +  dr[1].ToString()
                        });
                    }
                }
            }
        }
        void InitListenedList(ref List<Song> pl)
        {
            if (MainWindow.userName == null) return;
            pl = new List<Song>();
           
            string  query = "SELECT TOP 8 * FROM Listenrecently L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
            SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
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
                        s.songName = dr["SongName"].ToString();
                        s.singerName = dr["Artist"].ToString();
                        s.album = dr["Album"].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = "Đã nghe gần đây";
                        pl.Add(s);
                        n++;
                    }
                }
            }
            foreach (Song s in pl)
            {
                s.getList = pl;
            }

        }

        void InitLikedList(ref List<Song> pl)
        {
            if (MainWindow.userName == null) return;
            pl = new List<Song>();

            string query = "SELECT * FROM Liked L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
            SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (n > 5) break;
                        Song s = new Song();
                        s.songName = dr["SongName"].ToString();
                        s.singerName = dr["Artist"].ToString();
                        s.album = dr["Album"].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                        s.time = dr["Duration"].ToString();
                        s.getPL = "Đã thích";
                        s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                        s.isLike = true;
                        pl.Add(s);
                        n++;
                    }
                }
            }
            foreach (Song s in pl)
            {
                s.getList = pl;
            }

        }

        void InitLoadList(ref List<Song> pl)
        {
            if (MainWindow.userName == null) return;
            pl = new List<Song>();

            string query = "SELECT * FROM UserSongs WHERE UserName = @username";
            SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
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
                        s.songName = dr[1].ToString();
                        s.singerName = dr[2].ToString();
                        s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/Default.jpeg";
                        s.savepath = AppDomain.CurrentDomain.BaseDirectory + "UserSongs/" + dr[4].ToString();
                        s.time = dr[3].ToString();
                        s.getPL = "Đã tải lên";
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }
                        pl.Add(s);
                        n++;
                    }
                }
            }
            foreach (Song s in pl)
            {
                s.getList = pl;
            }

        }

        void InitLikedArtistsList()
        {
            String query = "SELECT * FROM  Artist A JOIN LikedPL L ON A.Name=L.PlaylistName WHERE L.UserName=@UserName";

            SqlParameter param = new SqlParameter("@UserName", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        likedArtists.Add(new PlayList()
                        {
                            title = dr[0].ToString(),
                            picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[1].ToString()
                        });
                    }
                }
            }
        }
        void InitLikedPlaylistsList()
        {
            String query = "SELECT * FROM  Playlist P JOIN LikedPL L ON P.Title=L.PlaylistName WHERE L.UserName=@UserName";

            SqlParameter param = new SqlParameter("@UserName", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        likedPlaylists.Add(new PlayList()
                        {
                            title = dr[0].ToString(),
                            picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[1].ToString()
                        });
                    }
                }
            }
        }

        void InitLikedAlbumsList()
        {
            String query = "SELECT * FROM  Album A JOIN LikedPL L ON A.Title=L.PlaylistName WHERE L.UserName=@UserName";

            SqlParameter param = new SqlParameter("@UserName", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        likedAlbums.Add(new PlayList()
                        {
                            title = dr[0].ToString(),
                            picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr[2].ToString(),
                            description = "Nghệ sĩ: " + dr[1] + ", Năm phát hành: " + dr[3]
                        });
                    }
                }
            }
        }
        UserControl p, page;
        private void viewAllLikedSongBtn_click(object sender, RoutedEventArgs e)
        {
            MainWindow.likedpage = new LikedView();
            p = MainWindow.likedpage;
            MainWindow.nvgPlayListView(p);
        }
        private void viewAllloadedSongBtn_click(object sender, RoutedEventArgs e)
        {
            PlayListView page = new PlayListView(UpLoadList, "Bài hát đã tải lên");
            MainWindow.nvgPlayListView(page);
        }
        private void ArtistOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;
            playList.songs= new List<Song>();
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
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }

                        playList.songs.Add(s);
                        n++;
                    }
                    foreach (Song s in playList.songs)
                    {
                        s.getList = playList.songs;
                    }
                }
            }

            page = new PlayListView(playList);
            p = page;
            MainWindow.nvgPlayListView(p);
        }

        private void LikedPlaylistOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;

            playList.songs = new List<Song>();
            switch (playList.title)
            {
                case "Nhạc Pop":
                    playList.songs = GenresView.PopList.songs;
                    break;
                case "Nhạc Hàn Quốc":
                    playList.songs = GenresView.KoreaList.songs;
                    break;
                case "Nhạc Âu Mỹ":
                    playList.songs = GenresView.USUKList.songs;
                    break;
                case "Nhạc Trung Quốc":
                    playList.songs = GenresView.ChinaList.songs;
                    break;
                case "Nhạc Việt Nam":
                    playList.songs = GenresView.VNList.songs;
                    break;
                case "Nhạc Nhật Bản":
                    playList.songs = GenresView.JapanList.songs;
                    break;
                case "Nhạc EDM":
                    playList.songs = GenresView.EDMList.songs;
                    break;
                case "Nhạc Cổ Điển":
                    playList.songs = GenresView.ClassicList.songs;
                    break;
                case "Nhạc Phim":
                    playList.songs = GenresView.OSTList.songs;
                    break;
                case "Nhạc R&B":
                    playList.songs = GenresView.RnBList.songs;
                    break;
                case "Nhạc Jazz":
                    playList.songs = GenresView.JazzList.songs;
                    break;
                case "Nhạc Không Lời":
                    playList.songs = GenresView.InstrumentalList.songs;
                    break;
                case "Nhạc Acoustic":
                    playList.songs = GenresView.AcousticList.songs;
                    break;
                case "Nhạc Hip Hop":
                    playList.songs = GenresView.HipHopList.songs;
                    break;
                case "Nhạc Tâm Trạng":
                    playList.songs = GenresView.EmotionalList.songs;
                    break;
                case "Nhạc Thư Giãn":
                    playList.songs = GenresView.RelaxingList.songs;
                    break;
                case "Nhạc Tập Trung":
                    playList.songs = GenresView.ConcentrationList.songs;
                    break;
                case "Có Thể Bạn Sẽ Thích":
                    playList.songs = HomeView.MaybeulikeList.songs;
                    break;
                case "Phổ Biến":
                    playList.songs = HomeView.PopularList.songs;
                    break;
                case "Mới Phát Hành":
                    playList.songs = HomeView.NewReleasesList.songs;
                    break;
            }
            page = new PlayListView(playList);
            p = page;
            MainWindow.nvgPlayListView(p);
        }

        private void AlbumOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;
            playList.songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Album=@Album";
            SqlParameter param1 = new SqlParameter("@Album", playList.title);
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
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }

                        playList.songs.Add(s);
                        n++;
                    }
                    foreach (Song s in playList.songs)
                    {
                        s.getList = playList.songs;
                    }
                }
            }

            page = new PlayListView(playList);
            p = page;
            MainWindow.nvgPlayListView(p);
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
        }
        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = (sender as Button).Name;
            if (s == "RListenedBtn")
                scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
            else if(s == "RYourPLBtn")
                scrollYourPL.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
            else if (s == "RLikedPLBtn")
                scrollLikedPL.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
            else if (s == "RNghesiBtn")
                scrollNghesi.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
            else if (s == "RAlbumBtn")
                scrollAlbum.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
        }

        private void DeleteUpLoad_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            // xóa khỏi db
            string m = "delete from [UserSongs] where SongName=N'" + song.songName + "' and UserName ='" + MainWindow.userName + "'";
            Phatnhac.SqlInteract(m);
            // xóa khỏi folder
            System.IO.File.Delete(song.savepath);
            // xóa khỏi thư viện
            UpLoadList = new List<Song>();
            InitLoadList(ref UpLoadList);
            listUpLoad.ItemsSource = UpLoadList;
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = (sender as Button).Name;
            if (s == "LListenedBtn")
                scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
            else if (s == "LYourPLBtn")
                scrollYourPL.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
            else if (s == "LLikedPLBtn")
                scrollLikedPL.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
            else if (s == "LNghesiBtn")
                scrollNghesi.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
            else if (s == "LAlbumBtn")
                scrollAlbum.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
        }
    }
}
