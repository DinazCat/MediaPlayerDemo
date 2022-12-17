using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static System.Net.Mime.MediaTypeNames;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for GenresView.xaml
    /// </summary>
    public partial class GenresView : UserControl
    {
        List<PlayList> QuocGiaPLs;
        PlayList PopList;
        PlayList EDMList;
        PlayList ClassicList;
        PlayList OSTList;
        PlayList RnBList;
        PlayList JazzList;
        PlayList InstrumentalList;
        PlayList AcousticList;
        PlayList HipHopList;
        public GenresView()
        {
            InitializeComponent();
            
            PopList = new PlayList();
            InitListPop(ref PopList, "Nhạc Pop");
            listPop.ItemsSource = PopList.songs;
            getPopL = PopList.songs;

            EDMList = new PlayList();
            InitGenreList(ref EDMList, "Nhạc EDM", "EDM");
            listEDM.ItemsSource = EDMList.songs;

            ClassicList = new PlayList();
            InitGenreList(ref ClassicList, "Nhạc Cổ Điển", "Cổ Điển");
            listCoDien.ItemsSource = ClassicList.songs;

            OSTList = new PlayList();
            InitGenreList(ref OSTList, "Nhạc Phim", "Nhạc Phim");
            listOST.ItemsSource = OSTList.songs;

            RnBList = new PlayList();
            InitGenreList(ref RnBList, "Nhạc R&B", "R&B");
            listRnB.ItemsSource = RnBList.songs;

            JazzList = new PlayList();
            InitGenreList(ref JazzList, "Nhạc Jazz", "Jazz");
            listJazz.ItemsSource = JazzList.songs;

            InstrumentalList = new PlayList();
            InitGenreList(ref InstrumentalList, "Nhạc Không Lời", "Nhạc Không Lời");
            listKhongLoi.ItemsSource = InstrumentalList.songs;

            AcousticList = new PlayList();
            InitGenreList(ref AcousticList, "Nhạc Acoustic", "Acoustic");
            listAcoustic.ItemsSource = AcousticList.songs;

            HipHopList = new PlayList();
            InitGenreList(ref HipHopList, "Nhạc Hip Hop", "Hip Hop");
            listHipHop.ItemsSource = HipHopList.songs;

            QuocGiaPLs = new List<PlayList>();
            ListQuocGia.ItemsSource = QuocGiaPLs;

            string[] tendaidien = new string[5] { 
                "Nhạc Việt Nam", "Nhạc Âu Mỹ", "Nhạc Hàn Quốc", "Nhạc Trung Quốc", "Nhạc Nhật Bản"
            };
            string[] linkAnh= new string[5] {
                "NhacViet.jpg", "NhacAuMy.jpg", "NhacHan.jpg", "NhacHoa.jpg", "NhacNhat.jpg"
            };
            for (int k = 0; k < 5; k++)
            {
                QuocGiaPLs.Add(new PlayList()
                {
                    picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + linkAnh[k],                    
                    title = tendaidien[k]
                });
            }
            
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
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }
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
        PlayListView page = new PlayListView();
        UserControl p;
        PlayList USUKList;
        PlayList VNList;
        PlayList ChinaList;
        PlayList KoreaList;
        PlayList JapanList;
        private void ButtonQuocGia_Click(object sender, RoutedEventArgs e)
        {
            PlayList item = (sender as Button).DataContext as PlayList;
            PlayListView.Title = item.title;
            if (item.title == "Nhạc Âu Mỹ")
            {
                USUKList = new PlayList();
                InitListbyNation(ref USUKList, "Nhạc Âu Mỹ", "Âu Mỹ");
                page = new PlayListView(USUKList.songs, item.title);
            }
            else if (item.title == "Nhạc Việt Nam")
            {
                VNList = new PlayList();
                InitListbyNation(ref VNList, "Nhạc Việt Nam", "Việt Nam");
                page = new PlayListView(VNList.songs, item.title);

            }
            else if (item.title == "Nhạc Hàn Quốc")
            {
                KoreaList = new PlayList();
                InitListbyNation(ref KoreaList, "Nhạc Hàn Quốc", "Hàn Quốc");
                page = new PlayListView(KoreaList.songs, item.title);

            }
            else if (item.title == "Nhạc Nhật Bản")
            {
                JapanList = new PlayList();
                InitListbyNation(ref JapanList, "Nhạc Nhật Bản", "Nhật Bản");
                page = new PlayListView(JapanList.songs, item.title);

            }
            else if (item.title == "Nhạc Trung Quốc")
            {
                ChinaList = new PlayList();
                InitListbyNation(ref ChinaList, "Nhạc Hoa", "Trung Quốc");
                page = new PlayListView(ChinaList.songs, item.title);

            }

            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
           
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(MainWindow.CurrentView);
                //MainWindow.View.RemoveAt(index - 1);
                for(int i = index + 1; i < MainWindow.View.Count; i++)
                {
                    MainWindow.View.RemoveAt(i);
                }    
                MainWindow.CheckBack = false;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Next.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "next.png"));
            }
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            MainWindow.CountPage = -1;
        }
        void InitGenreList(ref PlayList pl, string PlaylistName, string genre)
        {
            //Đổ các dữ liệu cơ bản của playlist
            String query = "SELECT * FROM Playlist WHERE Title=@Title";

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
            query = "SELECT * FROM Song WHERE Genre=@Genre1";
            SqlParameter param1 = new SqlParameter("@Genre1", genre);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        pl.songs.Add(new Song()
                        {
                            songName = dr[0].ToString(),
                            singerName = dr[1].ToString(),
                            album = dr[2].ToString(),
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                            time = dr["Duration"].ToString(),
                            getPL = PlaylistName
                        });
                        n++;
                    }
                    foreach (Song s in pl.songs)
                    {
                        s.getList = pl.songs;
                    }
                }
            }
        }
        public static List<Song> getPopL;
        void InitListPop(ref PlayList pl, string PlaylistName)
        {
            //Đổ các dữ liệu cơ bản của playlist
            String query = "SELECT * FROM Playlist WHERE Title=@Title";

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
            query = "SELECT * FROM Song WHERE Genre=@Genre1 or Genre=@Genre2 or Genre=@Genre3";
            SqlParameter param1 = new SqlParameter("@Genre1", "Pop");
            SqlParameter param2 = new SqlParameter("@Genre2", "KPop");
            SqlParameter param3 = new SqlParameter("@Genre3", "VPop");
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1, param2, param3))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach(DataRow dr in dt.Rows)
                    {
                        pl.songs.Add(new Song()
                        {
                            songName = dr[0].ToString(),
                            singerName = dr[1].ToString(),
                            album = dr[2].ToString(),
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                            time = dr["Duration"].ToString(),
                            getPL = PlaylistName
                        }) ;
                        n++;
                    }
                    foreach (Song s in pl.songs)
                    {
                        s.getList = pl.songs;
                    }
                }
            }

        }
    }
}
