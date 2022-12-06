using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
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
using Media_Player.View;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Reflection;
using Media_Player.Model;
using System.Data.SqlClient;
using System.Data;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        PlayList MaybeulikeList;
        public static List<Song> getMaybeulikeL;
        PlayList PopularList;
        public static List<Song> getPopularL;
        PlayList NewReleasesList;
        public static List<Song> getNewrealeasesL;
        public HomeView()
        {
            InitializeComponent();

            MaybeulikeList = new PlayList();
            InitList(ref MaybeulikeList, "Có Thể Bạn Sẽ Thích");
            listCothebansethich.ItemsSource = MaybeulikeList.songs;
            getMaybeulikeL = MaybeulikeList.songs;

            PopularList = new PlayList();
            InitList(ref PopularList, "Phổ Biến");
            listPhobien.ItemsSource= PopularList.songs;
            getPopularL= PopularList.songs;

            NewReleasesList = new PlayList();
            InitList(ref NewReleasesList, "Mới Phát Hành");
            listMoiphathanh.ItemsSource= NewReleasesList.songs;
            getNewrealeasesL = NewReleasesList.songs;

            Phatnhac.thisList = MaybeulikeList.songs; 
            Phatnhac.thisSong = MaybeulikeList.songs[0];
        }

        public EventHandler onAction = null;
        
        void InitList(ref PlayList pl, string PlaylistName)
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
            query = "SELECT S.* FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
            SqlParameter param1 = new SqlParameter("@PlaylistName", PlaylistName);
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
                }
            }

        }
    }
}
