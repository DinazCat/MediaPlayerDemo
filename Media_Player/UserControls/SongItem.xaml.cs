using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SongItem.xaml
    /// </summary>
    public partial class SongItem : UserControl
    {
        public SongItem()
        {
            InitializeComponent();
        }
        //public bool IsActive
        //{
        //    get { return (bool)GetValue(IsActiveProperty); }
        //    set { SetValue(IsActiveProperty, value); }
        //}
        //public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(SongItem));

        //public bool IsLiked
        //{
        //    get { return (bool)GetValue(IsLikedProperty); }
        //    set { SetValue(IsLikedProperty, value); }
        //}
        //public static readonly DependencyProperty IsLikedProperty = DependencyProperty.Register("IsLiked", typeof(bool), typeof(SongItem));
        public EventHandler onAction = null;
        private void BtnPlay_click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;
            MainWindow.getList = PlayListView.curlist;
            Phatnhac.thisList =PlayListView.curlist;
            Phatnhac.HamTuongTac(song);
            if (onAction != null) onAction.Invoke(this, e);
        }

        private void songitem_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Visible;
            this.Picture.Opacity = 0.6;
        }

        private void songitem_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BtnPlay.Visibility = Visibility.Hidden;
            this.Picture.Opacity = 1;
        }
    }
}
