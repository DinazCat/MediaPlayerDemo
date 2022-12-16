using Media_Player.Model;
using System;
using System.Collections;
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
    /// Interaction logic for PlaylistItem.xaml
    /// </summary>
    public partial class PlaylistItem : UserControl
    {
        List<Song> songs;
        public PlaylistItem()
        {
            InitializeComponent();
        }
        PlayListView page = new PlayListView();
        UserControl p;
        private void PlaylistOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayList item = (sender as Button).DataContext as PlayList;
            PlayListView.Title = item.title;

            songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
            SqlParameter param1 = new SqlParameter("@PlaylistName", item.title);
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
                        s.getPL = item.title;
                        s.getLoaiPL = "userPL";
                        if (PlayListView.CheckLiked(s.songName) == true)
                        {
                            s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            s.isLike = true;
                        }
                        songs.Add(s);
                        n++;
                    }
                    foreach (Song song in songs)
                    {
                        song.getList = songs;
                    }
                }
            }

            page = new PlayListView(songs, item.title);
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(MainWindow.CurrentView);
                //MainWindow.View.RemoveAt(index - 1);
                for (int i = index + 1; i < MainWindow.View.Count; i++)
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

        private void PlaylistItem_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Visible;
            this.BtnDelete.Visibility = Visibility.Visible;
        }

        private void PlaylistItem_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Hidden;
            this.BtnDelete.Visibility = Visibility.Hidden;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Playlist where Title=N'" + playList.title + "' and Username=N'" + MainWindow.userName + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Delete from Belong where PlaylistName=N'" + playList.title + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteReader();
            con.Close();

            int index = LibView.userPlaylists.IndexOf(playList);
            LibView.userPlaylists.RemoveAt(index);
            LibView.getUserPLs.Items.Refresh();

        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
