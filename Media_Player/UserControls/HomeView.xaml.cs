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

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        PlayList listMaybeulike;
        public HomeView()
        {
            InitializeComponent();
            listMaybeulike = new PlayList();
            listMaybeulike.songs = new List<Song>();
            listp2.ItemsSource = listMaybeulike.songs;
            string[] tennhac = new string[15];
            string[] tencasi = new string[15];
            using (StreamReader sr = new StreamReader("Cothebansethich\\15baicothethich.txt"))
            {
                int i = 0;
                string line;
                while ((line = sr.ReadLine()) != "")
                {
                    tennhac[i] = line;
                    i += 1;
                }
            }
            using (StreamReader tr = new StreamReader("Cothebansethich\\15tencasiP2.txt"))
            {
                int j = 0;
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    tencasi[j] = line;
                    j += 1;
                }
            }
            for (int k = 0; k < 15; k++)
            {
                string linknhac = AppDomain.CurrentDomain.BaseDirectory + "Cothebansethich/" + "15AudioP2\\" + "b" + k + ".mp3";
                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + "Cothebansethich/" + "LinkAnh\\" + "a" + k + ".png";
                listMaybeulike.songs.Add(new Song()
                {
                    songName = tennhac[k],
                    singerName = tencasi[k],
                    linkanh = linkAnh,
                    savepath = linknhac
                });
            }
            Phatnhac.thisList = listMaybeulike.songs;
        }

        public EventHandler onAction = null;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            MainWindow.getList = listMaybeulike.songs;
            Phatnhac.HamTuongTac(song);
            if (onAction != null) onAction.Invoke(this, e);
        }
    }
}
