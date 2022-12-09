using System.Threading;
using System.Threading.Tasks;

namespace Healthcare.WPF.ViewModels.Utilites
{
    public abstract class ChangePagesBase : ViewModelBase
    {
        private double _opacity;
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel; 
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        public double OpacityValue
        {
            get => _opacity;
            set { _opacity = value; OnPropertyChanged("OpacityValue"); }
        }
        public async void ChangePage(ViewModelBase page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.05)
                {
                    OpacityValue = i;
                    Thread.Sleep(1);
                }

                SelectedViewModel = page;
                for (double i = 0.0; i < 1.1; i += 0.05)
                {
                    OpacityValue = i;
                    Thread.Sleep(1);
                }

            });
        }
    }
}
