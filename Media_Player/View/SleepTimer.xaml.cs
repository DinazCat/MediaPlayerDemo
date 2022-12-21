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
    /// Interaction logic for SleepTimer.xaml
    /// </summary>
    public partial class SleepTimer : Window
    {
        public SleepTimer()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public delegate void SetSleepTimer(int totalseconds);
        public event SetSleepTimer SetSleepTimerEvent;
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            int hour;
            int min;
            int sec;
            try
            {
                hour = int.Parse(hourtxb.Text);
                min = int.Parse(minutetxb.Text);
                sec = int.Parse((secondtxb.Text)); 
            } catch
            {
                errortxbl.Text = "Giờ hoặc phút hoặc giây bạn nhập không hợp lệ!";
                return;
            }
            if (SetSleepTimerEvent != null)
            {
                SetSleepTimerEvent(hour * 3600 + min * 60 + sec);
            }
            this.Close();
        }
    }
}
