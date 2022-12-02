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
        List<Song> listMaybeulike;
        public HomeView()
        {
            InitializeComponent();
            listMaybeulike = new List<Song>();
            string Path1 = "ListSongOutSide\\Cothebansethich";
            string Path2 = "ListSongOutSide/Cothebansethich";
            ReadFile.ReadSong(ref listMaybeulike, 15,Path1,Path2,".png");
            listp2.ItemsSource = listMaybeulike; 
            
            
        }

        public EventHandler onAction = null;
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getList = listMaybeulike;
            Phatnhac.thisList = listMaybeulike;
            Song song = (sender as Button).DataContext as Song;
            Phatnhac.HamTuongTac(song);
            Phatnhac.occupying = listMaybeulike;
            if (onAction != null) onAction.Invoke(this, e);
        }
        private void songpnl_mouseEnter(object sender, MouseEventArgs e)
        {
            //this.BtnPlay.Visibility = Visibility.Visible;
            //this.Picture.Opacity = 0.6;
        }

        private void songpnl_mouseLeave(object sender, MouseEventArgs e)
        {
            //this.BtnPlay.Visibility = Visibility.Hidden;
            //this.Picture.Opacity = 1;
        }
    }
}
