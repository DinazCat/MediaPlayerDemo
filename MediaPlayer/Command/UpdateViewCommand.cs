using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaPlayer.ViewModel;

namespace MediaPlayer.Command
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel ViewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Home")
                ViewModel.SelectedViewModel = new HomeViewModel();
            else if(parameter.ToString() == "Library")
                ViewModel.SelectedViewModel = new LibViewModel();
            else if (parameter.ToString() == "Genres")
                ViewModel.SelectedViewModel = new GenresViewModel();
            else if (parameter.ToString() == "Liked")
                ViewModel.SelectedViewModel = new LikedViewModel();
        }
    }
}
