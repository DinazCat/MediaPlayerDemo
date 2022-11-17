using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.Command;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {       
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand AddPlaylistWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();
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
            set { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));            
            }
        }
    }
}
