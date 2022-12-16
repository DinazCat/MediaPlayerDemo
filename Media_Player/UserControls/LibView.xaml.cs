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
    /// Interaction logic for LibView.xaml
    /// </summary>
    public partial class LibView : UserControl
    {
        public static List<PlayList> userPlaylists;
        public static List<Song> ListenedList = new List<Song>();
        public static List<Song> LikedList = new List<Song>();
        public LibView()
        {
            InitializeComponent();
            userPlaylists = new List<PlayList>();
            InitUserList();
            DanhSachPhatlist.ItemsSource = userPlaylists;
            getUserPLs = DanhSachPhatlist;

            InitListenList(ref ListenedList);
            listListened.ItemsSource = ListenedList;

            InitLikedList(ref LikedList);
            listLiked.ItemsSource = LikedList;
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
        void InitListenList(ref List<Song> pl)
        {
            if (MainWindow.userName == null) return;
            pl = new List<Song>();
           
            string  query = "SELECT * FROM Listenrecently L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
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

    }
}
