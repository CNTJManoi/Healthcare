using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Healthcare.WPF.Command;
using Healthcare.WPF.ViewModels.Utilites;

namespace Healthcare.WPF.ViewModels
{
    public class NavigationViewModel : ChangePagesBase
    {
        private readonly ViewModelBase _registrationViewModel;
        private readonly ViewModelBase _authViewModel;
        private readonly ViewModelBase _mainPage;
        public NavigationViewModel()
        {
            _registrationViewModel = new RegistrationViewModel();
            _authViewModel = new AuthViewModel();
            _mainPage = new MainPageViewModel();
            OpacityValue = 1.0;
            OpenAuth();
        }

        public void OpenRegistration()
        {
            ChangePage(_registrationViewModel);
        }
        public void OpenAuth()
        {
            ChangePage(_authViewModel);
        }
        public void OpenMainPage()
        {
            ChangePage(_mainPage);
        }
    }
}
