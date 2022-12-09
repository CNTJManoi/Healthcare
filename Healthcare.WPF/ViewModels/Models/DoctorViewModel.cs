using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Healthcare.WPF.ViewModels.Models
{
    public class DoctorViewModel : ViewModelBase
    {
        static ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
        public ImageSource ImageOnScreen { get; set ; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Specialization { get; set; }
        public DoctorViewModel(string path, string specialization, string fio, string time)
        { 
            ImageOnScreen = (ImageSource)imageSourceConverter.ConvertFrom(path);
            Name = fio;
            Time = time;
            Specialization = specialization;
            OnPropertyChanged(nameof(ImageOnScreen));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Time));
            OnPropertyChanged(nameof(Specialization));
        }
    }
}
