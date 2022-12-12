using Media_Player.Model;
using Media_Player.ViewModel;
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
    /// Interaction logic for SongItem2.xaml
    /// </summary>
    public partial class SongItem2 : UserControl
    {
        public SongItem2()
        {
            InitializeComponent();
        }
        public EventHandler onAction = null;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;          

            MainWindow.getListName = BtnPlay.Content.ToString();
            MainWindow.getList = song.getList;
            Phatnhac.thisList = song.getList;
            Phatnhac.HamTuongTac(song);
            Phatnhac.occupying = Phatnhac.thisList;
            if (onAction != null) onAction.Invoke(this, e);
        }

        private void songpnl_mouseEnter(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Visible;
            this.Picture.Opacity = 0.6;
        }

        private void songpnl_mouseLeave(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Hidden;
            this.Picture.Opacity = 1;
        }

        List<Song> songs;
        PlayListView page = new PlayListView();
        UserControl p;
        private void artistBtn_click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            PlayListView.Title = song.singerName;

            songs = new List<Song>();
            string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Artist=@Artist";
            SqlParameter param1 = new SqlParameter("@Artist", song.singerName);
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
                            getPL = song.singerName
                        });
                        n++;
                    }
                    foreach (Song s in songs)
                    {
                        s.getList = songs;
                    }
                }
            }

            page = new PlayListView(songs, song.singerName);
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
    }
}
