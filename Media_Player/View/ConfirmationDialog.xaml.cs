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
    /// Interaction logic for ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : Window
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
        }
        public ConfirmationDialog(string header, string confirmquestion)
        {
            InitializeComponent();
            Header.Text = header;
            Confirmquestion.Text = confirmquestion;
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public delegate void DialogResult(string result);
        public event DialogResult DialogResultEvent;
        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DialogResultEvent != null)
            {
                DialogResultEvent("Yes");
            }
            this.Close();
        }
    }
}
