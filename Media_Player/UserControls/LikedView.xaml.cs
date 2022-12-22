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
    /// Interaction logic for LikedView.xaml
    /// </summary>
    public partial class LikedView : UserControl
    {
        List<Song> LikedList;
        public LikedView()
        {
            InitializeComponent();
            LikedList = new List<Song>();
            InitLikedList(ref LikedList);
            listLiked.ItemsSource = LikedList;
            txtDescription.Text = "Số bài hát: " + LikedList.Count;
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
