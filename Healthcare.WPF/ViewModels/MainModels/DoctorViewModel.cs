using System.Windows.Media;

namespace Healthcare.WPF.ViewModels.MainModels
{
    public class DoctorViewModel : ViewModelBase
    {
        static ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();
        public ImageSource ImageOnScreen { get; set ; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Specialization { get; set; }
        public DoctorViewModel(string path, string specialization, string fio, string time)
        { 
            ImageOnScreen = (ImageSource)_imageSourceConverter.ConvertFrom(path);
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
