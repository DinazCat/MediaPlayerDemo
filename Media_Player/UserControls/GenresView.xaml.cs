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
        List<PlayList> QuocGia;
        PlayList PopList;
        public static List<Song> getPopL;
        public GenresView()
        {
            InitializeComponent();
            QuocGia = new List<PlayList>();
            PopList = new PlayList();
            InitListPop(ref PopList, "Nhạc Pop");
            listPop.ItemsSource = PopList.songs;
            getPopL = PopList.songs;
            ListQuocGia.ItemsSource = QuocGia;
            string[] tendaidien = new string[4];
            using (StreamReader sr = new StreamReader("Quocgia/Tendaidien.txt"))
            {
                int i = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    tendaidien[i] = line;
                    i += 1;
                }
            }
            for (int k = 0; k < 4; k++)
            {
                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + "Quocgia/" + "Hinhanh/" + "a" + k + ".jpg";
                QuocGia.Add(new PlayList()
                {
                    picture = linkAnh,                    
                    title = tendaidien[k]
                });
            }
            
        }
        PlayListView page = new PlayListView();
        UserControl p;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayList item = (sender as Button).DataContext as PlayList;
            PlayListView.Title = item.title;
            if(item.haveOpened == false)
            {

                for (int i = 0; i < QuocGia.Count; i++)
                {
                    QuocGia[i].haveOpened = false;
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
        
        void InitListPop(ref PlayList pl, string PlaylistName)
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
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString() ,
                            getPL = "Nhạc Pop"
                        });
                        n++;
                    }
                }
            }

        }


    }
}
