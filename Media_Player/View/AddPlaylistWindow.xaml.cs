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
using System.Windows.Shapes;

namespace Media_Player.View
{
    /// <summary>
    /// Interaction logic for AddPlaylistWindow.xaml
    /// </summary>
    public partial class AddPlaylistWindow : Window
    {
        public delegate void AddNewPlaylist(string playlistName);
        public event AddNewPlaylist AddNewPlaylistEvent;
        public AddPlaylistWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addPLBtn_Click(object sender, RoutedEventArgs e)
        {            
            string playlistName = txbPLName.Text.Trim();
            if(AddNewPlaylistEvent != null)
            {
                AddNewPlaylistEvent(playlistName);
            }
            this.Close();
        }
    }
}
