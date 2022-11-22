using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.WPF.Command;

namespace Healthcare.WPF.ViewModels
{
    internal class RegistrationViewModel : ViewModelBase
    {
        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand => _backCommand ??
                                               (_backCommand = new DelegateCommand(OpenBackPage));
        public void OpenBackPage(object obj)
        {
            App.NavigationViewModel.OpenAuth();
        }
    }
}
