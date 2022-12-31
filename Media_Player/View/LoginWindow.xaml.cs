using MaterialDesignThemes.Wpf;
using Media_Player.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Media_Player.View;

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool isClosed = false;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            isClosed = true;
            this.Close();            
        }       
        public Window loginwd()
        {
            return this;
        }
        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignupWindow signupwd = new SignupWindow(this);
            signupwd.ShowDialog();
        }
        public TextBlock txbl()
        {
            return txblError;
        }

        private void ForgetPass_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SendCode sendCode = new SendCode();
            sendCode.ShowDialog();
            this.ShowDialog();
        }
    }
}
