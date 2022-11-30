using Media_Player.Model;
using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for GenresView.xaml
    /// </summary>
    public partial class GenresView : UserControl
    {
        List<PlayList> QuocGia;
        public GenresView()
        {
            InitializeComponent();
            QuocGia = new List<PlayList>();
            ListQuocGia.ItemsSource = QuocGia;
            string[] tendaidien = new string[4];
            using (StreamReader sr = new StreamReader("Quocgia\\Tendaidien.txt"))
            {
                int i = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    tendaidien[i] = line;
                    i += 1;
                }
            }
            for (int k = 0; k < 4; k++)
            {
                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + "Quocgia/" + "Hinhanh\\" + "a" + k + ".jpg";
                QuocGia.Add(new PlayList()
                {
                    picture = linkAnh,
                    title = tendaidien[k]
                });
            }
        }
        PlayListView page = new PlayListView();
        UserControl p;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayList item = (sender as Button).DataContext as PlayList;
            PlayListView.Title = item.title;
            if(item.haveOpened == false)
            {

                for (int i = 0; i < QuocGia.Count; i++)
                {
                    QuocGia[i].haveOpened = false;
                }
                page = new PlayListView();
                item.haveOpened = true;  
            }    
            p = page;
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.NavigationService.Navigate(p);
            MainWindow.View.Add(p);
            MainWindow.CurrentView = p;
            if (MainWindow.CheckBack)
            {
                int index = MainWindow.View.IndexOf(p);
                MainWindow.View.RemoveAt(index - 1);
                MainWindow.CheckBack = false;
            }
        }
    }
}
