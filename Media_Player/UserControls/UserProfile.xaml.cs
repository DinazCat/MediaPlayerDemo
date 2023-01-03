using Media_Player.View;
using Microsoft.Win32;
using System;
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
using System.Security.Principal;
using Media_Player.Model;
using System.Text.RegularExpressions;
using static Media_Player.View.ConfirmationDialog;
using Path = System.IO.Path;
using System.IO;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        Account account;
        public UserProfile()
        {
            InitializeComponent();
            if (MainWindow.userName != null)
            {
                string query = "SELECT * FROM [User] Where UserName = @UserName";
                SqlParameter param1 = new SqlParameter("@UserName", MainWindow.userName);
                DataTable dt;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            account = new Account()
                            {
                                userName = dr[1].ToString(),
                                displayName = dr[2].ToString(),
                                email = dr[4].ToString(),
                                picture = AppDomain.CurrentDomain.BaseDirectory + "UserPictures/" + dr[5].ToString()
                            };
                        }
                        this.DataContext = account;
                    }
                }
            }
 
        }

        private void changePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string WriteFile = AppDomain.CurrentDomain.BaseDirectory + @"UserPictures\" + MainWindow.userName + Path.GetFileName(openFileDialog.FileName);
                if (!File.Exists(WriteFile))
                {
                    File.Copy(openFileDialog.FileName, WriteFile);                    
                }
                account.picture = WriteFile;
                MainWindow.thisAccount.picture = account.picture;
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update [User] set Picture='" + MainWindow.userName + Path.GetFileName(openFileDialog.FileName) + "' where UserName=N'" + MainWindow.userName + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
            }
        }
        string oldDName, oldEmail;
        private void editDisplayName_Click(object sender, RoutedEventArgs e)
        {
            panelDName.Visibility = Visibility.Visible;
            DName.IsReadOnly = false;
            DName.Focus();
            oldDName= DName.Text;
        }

        private void editEmail_Click(object sender, RoutedEventArgs e)
        {
            panelEmail.Visibility = Visibility.Visible;
            Email.IsReadOnly = false;
            Email.Focus();
            oldEmail= Email.Text;
        }

        private void editPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasswordwd = new ChangePassword();
            changePasswordwd.PasswordBox.Visibility = Visibility.Visible;
            changePasswordwd.ShowDialog();
        }

        private void OkDNameBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update [User] set DisplayName=N'" + DName.Text + "' where UserName=N'" + MainWindow.userName + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            panelDName.Visibility = Visibility.Collapsed;
            DName.IsReadOnly = true;
            MainWindow.thisAccount.displayName = DName.Text;
        }

        private void OkEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txblError.Text = "Email không hợp lệ!";
                Email.Focus();
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update [User] set Email=N'" + Email.Text + "' where UserName=N'" + MainWindow.userName + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            panelEmail.Visibility = Visibility.Collapsed;
            Email.IsReadOnly = true;
        }

        private void cancelDNameBtn_Click(object sender, RoutedEventArgs e)
        {
            account.displayName = oldDName;
            panelDName.Visibility = Visibility.Collapsed;
            DName.IsReadOnly = true;
        }

        private void cancelEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            account.email = oldEmail;
            panelEmail.Visibility = Visibility.Collapsed;
            Email.IsReadOnly = true;
        }
    }
}
