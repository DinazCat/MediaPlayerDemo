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
        public static PlayList thisPlayList;
        public PlayListView()
        {
            InitializeComponent(); 
           
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

            bool isPLLiked = IsLiked(listName);
            thisPlayList = new PlayList()
            {
                title = listName,
                description = "Số bài hát: " + songs.Count,
                isLiked = isPLLiked,
                LinkLikeIcon = isPLLiked ? AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLfilledHeart.png" : AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLheart.png",
                songs = songs
            };
            if(listName=="Danh Sách Đang Phát" || songs[0].getLoaiPL == "userPL")
                thisPlayList.LinkLikeIcon = "";
            if (IsPlaying()) thisPlayList.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLpause.png";
            this.DataContext = thisPlayList;

            for (int i = 0; i < songs.Count; i++)
            {
                if (CheckLiked(songs[i].songName))
                {
                    songs[i].LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                    songs[i].isLike = true;
                }    
            }    

            listSongs = songs;
            listSongItem.ItemsSource = listSongs;

            if (MainWindow.userName != null)
                userListView = listSongItem;
        }
        public PlayListView(PlayList playList)
        {
            InitializeComponent();
            
            
            thisPlayList = playList;
            bool isPLLiked = IsLiked(playList.title);                        
            playList.isLiked = isPLLiked;
            playList.LinkLikeIcon = isPLLiked ? AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLfilledHeart.png" : AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLheart.png";
            if(playList.description == null) playList.description = "Số bài hát: " + playList.songs.Count;
            if(IsPlaying()) playList.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLpause.png";

            this.DataContext = playList;
            for (int i = 0; i < playList.songs.Count; i++)
            {
                if (CheckLiked(playList.songs[i].songName))
                {
                    playList.songs[i].LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                    playList.songs[i].isLike = true;
                }
            }
            listSongs = playList.songs;
            listSongItem.ItemsSource = listSongs;

            if (MainWindow.userName != null)
                userListView = listSongItem;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPlaying())
            {
                MainWindow.getListName = thisPlayList.title;
                MainWindow.getList = Phatnhac.thisList = thisPlayList.songs;
                Phatnhac.HamTuongTac(thisPlayList.songs[0]);
                Phatnhac.occupying = Phatnhac.thisList;
                thisPlayList.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLpause.png";
            }
            else
            {
                MainWindow.getListName = thisPlayList.title;
                MainWindow.getList = Phatnhac.thisList = thisPlayList.songs;
                foreach (Song song in thisPlayList.songs)
                {
                    if (song.Linkicon == AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png")
                    {
                        Phatnhac.HamTuongTac(song);                        
                        break;
                    }
                }
                Phatnhac.occupying = Phatnhac.thisList;
                thisPlayList.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLplay.png";
            }
        }

        private void BtnLove_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.userName == null)
            {
                LoginWindow loginwd = new LoginWindow();
                loginwd.SkipBtn.Visibility = Visibility.Collapsed;
                loginwd.ShowDialog();
                return;
            }
            if (!thisPlayList.isLiked)
            {
                string query = "Insert into LikedPL(UserName,PlaylistName) values(N'" + MainWindow.userName + "',N'" + thisPlayList.title + "' )";
                Phatnhac.SqlInteract(query);
                thisPlayList.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLfilledHeart.png";
            }
            else
            {
                string query = "Delete from LikedPL where UserName=N'" + MainWindow.userName + "' and PlaylistName=N'" + thisPlayList.title + "'";
                Phatnhac.SqlInteract(query);
                thisPlayList.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "PLheart.png";
            }
            thisPlayList.isLiked = !thisPlayList.isLiked;
        }
        bool IsLiked(string listName)
        {
            if (MainWindow.userName == null)
                return false;
            string query = "SELECT * FROM LikedPL WHERE UserName = @username AND PlaylistName=@PlaylistName";
            SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
            SqlParameter param2 = new SqlParameter("@PlaylistName", listName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1, param2))
            {
                if (reader.HasRows)
                    return true;
            }
            return false;
        }
        bool IsPlaying()
        {
            foreach (Song song in thisPlayList.songs)
            {
                if (song.Linkicon == AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png")
                {
                    return true;
                }
            }
            return false;
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + e.Delta);
        }
    }
}
