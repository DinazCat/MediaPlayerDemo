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
                        songs.Add(new Song()
                        {
                            songName = dr["Name"].ToString(),
                            singerName = dr["Artist"].ToString(),
                            album = dr["Album"].ToString(),
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                            time = dr["Duration"].ToString(),
                            getPL = item.title
                        });
                        n++;
                    }
                    foreach(Song song in songs)
                    {
                        song.getList = songs;
                    }
                }
            }

            page = new PlayListView(songs,item.title);
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
            
        }
        
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
