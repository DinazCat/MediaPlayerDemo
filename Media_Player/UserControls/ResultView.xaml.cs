using Media_Player.Model;
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
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {
        public static List<Song> Result;
        public static List<Song> result { get { return Result; } set { Result = value; } }
        public static string setTextKq;
        public static string SetTextKq { get { return setTextKq; } set { setTextKq = value; } }
        public ResultView()
        {
            InitializeComponent();
            ListKetQua.ItemsSource = Result;
            txtKQ.Text = SetTextKq;
        }
    }
}
