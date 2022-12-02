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
            if(BtnPlay.Content.ToString() == "Nhạc Pop")
            {
                MainWindow.getList = GenresView.getPopL;
                Phatnhac.thisList = GenresView.getPopL;
            }    
            Phatnhac.HamTuongTac(song);
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
