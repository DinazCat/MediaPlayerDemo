using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Media_Player.ViewModel;

namespace Media_Player.View
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }
        private LoginWindow loginwd;
        public SignupWindow(Window callingwd)
        {
            loginwd = callingwd as LoginWindow;
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            loginwd.Close();
            this.Close();
        }

        private void Grid_Mousedown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loginwd.ShowDialog();
        }

        private void BtnSignup_click(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "" || Username.Text == "" || Displayname.Text == "" || PasswordBox1.Password == "" || PasswordBox2.Password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                Email.Focus();
            }
            else if (PasswordBox1.Password != PasswordBox2.Password)
            {
                MessageBox.Show("Mật khẩu không trùng nhau!");
            }
            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email không hợp lê!");
            }
            else
            {
                Random rd = new Random();
                int ID = rd.Next(100000, 999999);
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into [User] values('" + ID.ToString() + "','" + Username.Text + "','" + Displayname.Text + "','" + PasswordBox1.Password + "','" + Email.Text + "')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Đăng ký thành công!");
                loginwd.Show();
                this.Close();
            }

        }
    }
}
