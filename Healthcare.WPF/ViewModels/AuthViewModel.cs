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
        private DelegateCommand _goToMainPage;
        public DelegateCommand RegistrationCommand => _registrationCommand ??
                                                      (_registrationCommand = new DelegateCommand(OpenRegistration));
        public DelegateCommand MainPageCommand => _goToMainPage ??
                                                  (_goToMainPage = new DelegateCommand(OpenMainPage));

        public void OpenRegistration(object obj)
        {
            App.NavigationViewModel.OpenRegistration();
        }
        public void OpenMainPage(object obj)
        {
            App.NavigationViewModel.OpenMainPage();
        }
    }
}
