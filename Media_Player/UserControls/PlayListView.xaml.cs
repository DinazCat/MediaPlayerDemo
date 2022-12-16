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
      

        public static List<Song> listSongs;
        private static ListView _userListView;
        public static ListView userListView { get { return _userListView; } set { _userListView = value; } }
        public PlayListView(List<Song> songs, string listName)
        {
            InitializeComponent();
            for(int i = 0; i < songs.Count; i++)
            {
                if (CheckLiked(songs[i].songName))
                {
                    songs[i].LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                    songs[i].isLike = true;
                }    
            }    
            listSongs = songs;
            listSongItem.ItemsSource = listSongs;
            Title = listName;
            txtTitle.Text = Title;
            if (MainWindow.userName != null)
            userListView = listSongItem;
        }
    }
}
