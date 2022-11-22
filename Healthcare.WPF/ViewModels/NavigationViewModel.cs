using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Healthcare.WPF.Command;

namespace Healthcare.WPF.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            private set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        public NavigationViewModel()
        {
            OpenAuth();
        }

        public void OpenRegistration()
        {
            SelectedViewModel = new RegistrationViewModel();
        }
        public void OpenAuth()
        {
            SelectedViewModel = new AuthViewModel();
        }
    }
}
