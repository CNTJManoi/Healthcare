using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.WPF.ViewModels.Models;

namespace Healthcare.WPF.ViewModels
{
    internal class AppointmentDoctorViewModel : ViewModelBase
    {
        public ObservableCollection<DoctorViewModel> ListBoxItems { get; set; }

        public AppointmentDoctorViewModel()
        {
            ListBoxItems = new ObservableCollection<DoctorViewModel>();
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
            ,"Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
                , "Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
                , "Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
                , "Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
                , "Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            ListBoxItems.Add(new DoctorViewModel("C:\\Users\\lecha\\source\\repos\\Healthcare\\Healthcare.WPF\\Views\\Pages\\Main\\Y1g2xS08uZE.jpg"
                , "Терапевт", "Жмышенко Валерий Иванович", "09:00 - 12:00"));
            OnPropertyChanged(nameof(ListBoxItems));
        }
    }
}
