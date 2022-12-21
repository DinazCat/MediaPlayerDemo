using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Data;
using Media_Player.Model;

namespace Media_Player.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public bool IsSkip { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand CloseCommand { get; set; }
        public ICommand SkipCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            SkipCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsSkip = true; p.Close(); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void Login(Window p)
        {
            if (p == null)
                return;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM [User] WHERE Username=@Username AND Password=@Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", UserName);
                    sqlCmd.Parameters.AddWithValue("@Password", Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        IsLogin = true;
                        MainWindow.userName = UserName;
                        p.Close();
                    }
                    else
                    {
                        IsLogin = false;
                        (p as LoginWindow).txblError.Text = "Sai tài khoản hoặc mật khẩu!";
                        //MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }

                }
            }
            catch { }
            finally { sqlCon.Close(); }

        }
    }
}
