﻿using MaterialDesignThemes.Wpf;
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
using System.Diagnostics.Eventing.Reader;

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
            loginwd.isClosed = true;
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
                txblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                Email.Focus();
            }
            else if (PasswordBox1.Password != PasswordBox2.Password)
            {
                txblError.Text = "Mật khẩu không trùng nhau!";
                PasswordBox1.Focus();
            }
            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txblError.Text = "Email không hợp lệ!";
                Email.Focus();
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) FROM [User] WHERE Username=@Username";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            txblError.Text = "Tên đăng nhập này đã có người sử dụng!";
                            return;
                        }
                    }
                }
                catch { }
                finally { sqlCon.Close(); }
                Random rd = new Random();
                int ID = rd.Next(100000, 999999);
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into [User] values('" + ID.ToString() + "',N'" + Username.Text + "',N'" + Displayname.Text + "','" + PasswordBox1.Password + "','" + Email.Text + "','default.png')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                CustomMessageBox messageBox = new CustomMessageBox("Đăng ký thành công!");
                messageBox.ShowDialog();
                loginwd.Show();
                this.Close();
            }

        }
    }
}
