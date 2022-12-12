using Media_Player.Model;
using Media_Player.ViewModel;
using System;
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
            for (int k = 0; k < 5; k++)
            {

                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/Nuoc" + k + ".jpg";

                QuocGiaPLs.Add(new PlayList()
                {
                    picture = linkAnh,                    
                    title = tendaidien[k]
                });
            }
            
        }
        PlayListView page = new PlayListView();
        UserControl p;
        private void ButtonQuocGia_Click(object sender, RoutedEventArgs e)
        {
            PlayList item = (sender as Button).DataContext as PlayList;
            PlayListView.Title = item.title;
            if (item.haveOpened == false)
            {
                for (int i = 0; i < QuocGiaPLs.Count; i++)
                {
                    QuocGiaPLs[i].haveOpened = false;
                }
                page = new PlayListView();
                item.haveOpened = true;
            }
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
