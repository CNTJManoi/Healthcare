using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.WPF.Command;

namespace Healthcare.WPF.ViewModels
{
    internal class AuthViewModel : ViewModelBase
    {
        private DelegateCommand _registrationCommand;
        public DelegateCommand RegistrationCommand => _registrationCommand ??
                                                      (_registrationCommand = new DelegateCommand(OpenRegistration));

        public void OpenRegistration(object obj)
        {
            App.NavigationViewModel.OpenRegistration();
        }
    }
}
