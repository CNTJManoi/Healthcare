using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.WPF.ViewModels.Models
{
    public class DoctorViewModel : ViewModelBase
    {
        public string Path { get; set ; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Specialization { get; set; }
        public DoctorViewModel(string path, string specialization, string fio, string time)
        {
            Path = path;
            Name = fio;
            Time = time;
            Specialization = specialization;
            OnPropertyChanged(nameof(Path));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Time));
            OnPropertyChanged(nameof(Specialization));
        }
    }
}
