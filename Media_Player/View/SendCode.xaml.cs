using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Media_Player.View
{
    /// <summary>
    /// Interaction logic for SendCode.xaml
    /// </summary>
    public partial class SendCode : Window
    {
        public SendCode()
        {
            InitializeComponent();
        }
        string randomCode;
        public static string to;
        private void SendCode_Click(object sender, RoutedEventArgs e)
        { 
            string from, pass, message;
            Random rd = new Random();
            randomCode = rd.Next(999999).ToString();
            MailMessage mailMessage = new MailMessage();
            to = txbEmail.Text;
            from = "zincat510@gmail.com";
            pass = "jywghiutqphlbaun";
            message = "Mã xác thực tài khoản Music4Life của bạn là: " + randomCode;
            if (!Regex.IsMatch(to, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            else mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = message;
            mailMessage.Subject = "Mã xác thực";
            SmtpClient smtpClient= new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtpClient.Send(mailMessage);
                CustomMessageBox messageBox = new CustomMessageBox("Đã gửi mã xác thực vào email!");
                messageBox.ShowDialog();
                email.Visibility = Visibility.Hidden;
                verifyCode.Visibility = Visibility.Visible;
                btnsendcode.Visibility = Visibility.Hidden;
                btnverifycode.Visibility = Visibility.Visible;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void VerifyCode_Click(object sender, RoutedEventArgs e)
        {
            if (randomCode == txbCode.Text)
            {
                this.Hide();
                ChangePassword changePasswordwd = new ChangePassword();
                changePasswordwd.ShowDialog();
                this.Close();
            }
            else
            {
                Errortxt.Text = "Mã xác thực không chính xác!";
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
