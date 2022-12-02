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

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
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
            this.Close();
        }
        private void BtnLogin_click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM [User] WHERE Username=@Username AND Password=@Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", UserName.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", PasswordBox.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                    }

                    //SqlParameter parameterYear = new SqlParameter("@Year", 10);

                    //var dap = new SqlDataAdapter("select * from [User]", sqlCon);
                    //var table = new DataTable();
                    //dap.Fill(table);
                    //MessageBox.Show("hello" + table.Rows[0]["Username"].ToString());

                    //using (SqlDataReader reader = command.ExecuteReader())
                    //{
                    //    DataTable myTable = new DataTable();

                    //    if (reader.HasRows)
                    //    {
                    //        myTable.Load(reader);
                    //    }
                    //    else
                    //    {
                    //        //No rows
                    //    }
                    //}
                }
            }
            catch { }
            finally { sqlCon.Close(); }
        }
    }
}
