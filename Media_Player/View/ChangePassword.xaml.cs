using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
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
using System.Runtime.CompilerServices;

namespace Media_Player.View
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) FROM [User] WHERE (Username=@Username OR Email=@Username) AND Password=@Password";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@Username", MainWindow.userName);
                        sqlCmd.Parameters.AddWithValue("@Password", PasswordBox.Password);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count < 1)
                        {
                            Errortxt.Text = "Mật khẩu cũ không chính xác!";
                            PasswordBox.Focus();
                            return;
                        }
                    }
                }
                catch { }
                finally { sqlCon.Close(); }
            }

            if (PasswordBox1.Password != PasswordBox2.Password)
            {
                Errortxt.Text = "Mật khẩu không trùng nhau!";
                PasswordBox1.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update [User] set Password='" + PasswordBox1.Password + "' where Email='" + SendCode.to + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                    CustomMessageBox messageBox = new CustomMessageBox("Đổi mật khẩu thành công!");
                    messageBox.ShowDialog();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
