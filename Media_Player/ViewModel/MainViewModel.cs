using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Media_Player.Command;
using Media_Player.View;

namespace Media_Player.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand AddPlaylistWindowCommand { get; set; }
        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin || loginVM.IsSkip)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            }
              );

            UpdateViewCommand = new UpdateViewCommand(this);
            AddPlaylistWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddPlaylistWindow wd = new AddPlaylistWindow();
                wd.ShowDialog();
            });
        }
        private BaseViewModel _selectedViewModel = new HomeViewModel();
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
