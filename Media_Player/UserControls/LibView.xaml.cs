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
    /// Interaction logic for LibView.xaml
    /// </summary>
    public partial class LibView : UserControl
    {
        List<PlayList> userPlaylists = new List<PlayList>();
        public LibView()
        {
            InitializeComponent();

            userPlaylists = new List<PlayList>();
            InitUserList();
            DanhSachPhatlist.ItemsSource = userPlaylists;

        }

        void InitUserList()
        {
            String query = "SELECT * FROM Playlist WHERE UserName=@UserName";

            SqlParameter param = new SqlParameter("@UserName", MainWindow.userName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        userPlaylists.Add(new PlayList()
                        {
                            title = dr[0].ToString(),
                            picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" +  dr[1].ToString()
                        });
                    }
                }
            }
        }

    }
}
