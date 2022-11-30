using Media_Player.Model;
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

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for PlayListView.xaml
    /// </summary>
    public partial class PlayListView : UserControl
    {
        public static List<Song> list;
        public static string Title;
        public PlayListView()
        {
            InitializeComponent();
            list = new List<Song>();
            imgScan.DataContext = new { prescanImage = AppDomain.CurrentDomain.BaseDirectory + "Quocgia/" + "AnhnenAuMy.jpg" };
            if (Title == "Nhạc Âu Mỹ")
            {
                string Path1 = "Quocgia\\ListAuMy";
                string Path2 = "Quocgia/ListAuMy";
                ReadFile.ReadSong(ref list, 7, Path1, Path2, ".jpg");
                
                txtName.Text = "Nhạc Âu Mỹ";
            }
            else if(Title == "Nhạc Việt Nam")
            {
                string Path1 = "Quocgia\\ListVietNam";
                string Path2 = "Quocgia/ListVietNam";
                ReadFile.ReadSong(ref list, 7, Path1, Path2, ".jpg");
                txtName.Text = "Nhạc Việt Nam";

            }
            
            ListNhac.ItemsSource = list;
           
        }

        public EventHandler onAction = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            MainWindow.getList = list;
            Phatnhac.thisList = list;
            Phatnhac.HamTuongTac(song);
            Phatnhac.occupying = list;
            if (onAction != null) onAction.Invoke(this, e);
        }
    }
}
