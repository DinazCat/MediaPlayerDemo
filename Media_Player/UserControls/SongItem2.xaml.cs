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
            if (BtnPlay.Content.ToString() == "Có Thể Bạn Sẽ Thích")
            {
                MainWindow.getList = HomeView.getMaybeulikeL;
                Phatnhac.thisList = HomeView.getMaybeulikeL;
            }
            else if (BtnPlay.Content.ToString() == "Phổ Biến")
            {
                MainWindow.getList = HomeView.getPopularL;
                Phatnhac.thisList = HomeView.getPopularL;
            }
            else if (BtnPlay.Content.ToString() == "Mới Phát Hành")
            {
                MainWindow.getList = HomeView.getNewrealeasesL;
                Phatnhac.thisList = HomeView.getNewrealeasesL;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc Pop")
            {
                MainWindow.getList = GenresView.getPopL;
                Phatnhac.thisList = GenresView.getPopL;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc EDM")
            {
                MainWindow.getList = GenresView.getEDML;
                Phatnhac.thisList = GenresView.getEDML;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc Cổ Điển")
            {
                MainWindow.getList = GenresView.getClassicL;
                Phatnhac.thisList = GenresView.getClassicL;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc Phim")
            {
                MainWindow.getList = GenresView.getOSTL;
                Phatnhac.thisList = GenresView.getOSTL;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc R&B")
            {
                MainWindow.getList = GenresView.getRnBL;
                Phatnhac.thisList = GenresView.getRnBL;
            }
            else if (BtnPlay.Content.ToString() == "Nhạc Jazz")
            {
                MainWindow.getList = GenresView.getJazzL;
                Phatnhac.thisList = GenresView.getJazzL;
            }
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
    }
}
