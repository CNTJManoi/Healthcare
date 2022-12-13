using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Healthcare.Logic;
using Healthcare.Logic.Separations.Base;
using Healthcare.WPF.ParsersInformation;

namespace Healthcare.WPF.ViewModels.MainModels
{
    internal class AppointmentDoctorViewModel : ViewModelBase
    {
        private Hospital _hp;
        private int _selectedDepartment;
        private HospitalStringCreator _stringCreator;
        public ObservableCollection<DoctorViewModel> ListBoxItems { get; set; }
        public ObservableCollection<string> DepartmentList { get; set; }
        public int SelectedDepartment
        {
            get { return _selectedDepartment;}
            set
            {
                _selectedDepartment = value;
                RefreshDoctorsList(_hp.Buildings);
                UpdatePage();
            }
        }

        public AppointmentDoctorViewModel(Hospital hp)
        {
            _hp = hp;
            _stringCreator = new HospitalStringCreator();
            RefreshDepartmentList(hp.Buildings);
            SelectedDepartment = 0;
        }

        private void RefreshDepartmentList(IEnumerable<IDepartment> departments)
        {
            DepartmentList = new ObservableCollection<string>();
            foreach (var department in departments)
            {
                DepartmentList.Add(department.Name);
            }
        }
        private void RefreshDoctorsList(IEnumerable<IDepartment> departments)
        {
            ListBoxItems = new ObservableCollection<DoctorViewModel>();
                foreach (var doctor in departments.ToList()[SelectedDepartment].Doctors)
                {
                    ListBoxItems.Add(new DoctorViewModel(
                        "https://www.meme-arsenal.com/memes/17546868fd82d11133e23d38fe7e8d5e.jpg", 
                        _stringCreator.GetDoctorSpecilialization(doctor), 
                        doctor.FullName, 
                        doctor.BeginWorkTime + " - " + doctor.EndWorkTime));
                }
            
        }

        private void UpdatePage()
        {
            OnPropertyChanged(nameof(ListBoxItems));
            OnPropertyChanged(nameof(ListBoxItems));
        }
    }
}
