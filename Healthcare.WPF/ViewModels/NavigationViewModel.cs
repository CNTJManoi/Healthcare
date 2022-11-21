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
    class NavigationViewModel : ViewModelBase
    {
        private DelegateCommand _registrationCommand;
        public DelegateCommand ButtonBegins => _registrationCommand ?? 
                                               (_registrationCommand = new DelegateCommand(OpenRegistration));

        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }



        public NavigationViewModel()
        {
            SelectedViewModel = new RegistrationViewModel();
        }

        private void OpenRegistration(object obj)
        {
            SelectedViewModel = new RegistrationViewModel();
        }

    }
}
