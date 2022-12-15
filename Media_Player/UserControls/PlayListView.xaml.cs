using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
    /// Interaction logic for PlayListView.xaml
    /// </summary>
    public partial class PlayListView : UserControl
    {
        public static string Title;
        PlayList USUKList;
        PlayList VNList;
        PlayList ChinaList;
        PlayList KoreaList;
        PlayList JapanList;
        public PlayListView()
        {
            InitializeComponent();

            //imgScan.DataContext = new { prescanImage = AppDomain.CurrentDomain.BaseDirectory + "Quocgia/" + "AnhnenAuMy.jpg" };
            txtTitle.Text = Title;
            if (Title == "Nhạc Âu Mỹ")
            {                
                USUKList= new PlayList();
                InitListbyNation(ref USUKList, "Nhạc Âu Mỹ", "Âu Mỹ");
                listSongItem.ItemsSource = USUKList.songs;
            }
            else if(Title == "Nhạc Việt Nam")
            {
                VNList = new PlayList();
                InitListbyNation(ref VNList, "Nhạc Việt Nam", "Việt Nam");
                listSongItem.ItemsSource = VNList.songs;
            }
            else if(Title == "Nhạc Hàn Quốc")
            {
                KoreaList = new PlayList();
                InitListbyNation(ref KoreaList, "Nhạc Hàn Quốc", "Hàn Quốc");
                listSongItem.ItemsSource = KoreaList.songs;
            }
            else if (Title == "Nhạc Nhật Bản")
            {
                JapanList = new PlayList();
                InitListbyNation(ref JapanList, "Nhạc Nhật Bản", "Nhật Bản");
                listSongItem.ItemsSource = JapanList.songs;
            }
            else if (Title == "Nhạc Trung Quốc")
            {
                ChinaList = new PlayList();
                InitListbyNation(ref ChinaList, "Nhạc Hoa", "Trung Quốc");
                listSongItem.ItemsSource = ChinaList.songs;
            }
        }
        public static bool CheckLiked(string songname)
        {
            if (MainWindow.userName == null) return false;

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
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Songname"].ToString() == songname) return true;
            }
            return false;
        }
        void InitListbyNation(ref PlayList pl, string PlaylistName, string Nation)
        {
            //Đổ các dữ liệu cơ bản của playlist
            String query = "SELECT * FROM Playlist WHERE Title=N'@Title'";

            SqlParameter param = new SqlParameter("@Title", PlaylistName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    DataRow dr = dt.Rows[0];
                    pl.title = dr[0].ToString();
                    pl.picture = dr[1].ToString();
                }
            }
            //Đổ dữ liệu cho songs
            pl.songs = new List<Song>();
            query = "SELECT * FROM Song WHERE Nation=@Nation ";
            SqlParameter param1 = new SqlParameter("@Nation", Nation);
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
                        s.getPL = PlaylistName;
                        if (CheckLiked(s.songName) == true)
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                        pl.songs.Add(s);
                        n++;
                    }
                    foreach (Song song in pl.songs)
                    {
                        song.getList = pl.songs;
                    }
                }
            }
        }

        public static List<Song> listSongs;
        private static ListView _userListView;
        public static ListView userListView { get { return _userListView; } set { _userListView = value; } }
        public PlayListView(List<Song> songs, string listName)
        {
            InitializeComponent();

            listSongs = songs;
            listSongItem.ItemsSource = listSongs;
            Title = listName;
            txtTitle.Text = Title;
            if (MainWindow.userName != null)
            userListView = listSongItem;
        }
    }
}
