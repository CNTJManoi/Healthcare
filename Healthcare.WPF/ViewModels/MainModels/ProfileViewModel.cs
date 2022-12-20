using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;

namespace Healthcare.WPF.ViewModels.MainModels
{
    internal class ProfileViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string NameDepartment { get; set; }
        public string AddressDepartment { get; set; }

        public ProfileViewModel(Patient p, IDataDepartment department)
        {
            Name = p.Name;
            Surname = p.Surname;
            Patronymic = p.Patronymic;
            Address = p.Address;
            NameDepartment = department.Name;
            AddressDepartment = department.Address;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Patronymic));
            OnPropertyChanged(nameof(Address));
            OnPropertyChanged(nameof(NameDepartment));
            OnPropertyChanged(nameof(AddressDepartment));
        }
    }
}
