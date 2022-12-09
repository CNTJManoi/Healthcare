using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.WPF.Command;
using Healthcare.WPF.ViewModels.Utilites;
using Healthcare.WPF.Views.Pages.Main;

namespace Healthcare.WPF.ViewModels
{
    internal class MainPageViewModel : ChangePagesBase
    {
        private ViewModelBase _appointmentDoctor;
        private DelegateCommand _goToRecording;
        private DelegateCommand _exitCommand;
        public DelegateCommand ExitCommand => _exitCommand ??
                                              (_exitCommand = new DelegateCommand(Exit));
        public DelegateCommand RecordingCommand => _goToRecording ??
                                                   (_goToRecording = new DelegateCommand(GoToRecordingPage));

        public MainPageViewModel()
        {
            _appointmentDoctor = new AppointmentDoctorViewModel();
        }
        public void Exit(object obj)
        {
            Environment.Exit(0);
        }
        public void GoToRecordingPage(object obj)
        {
            ChangePage(_appointmentDoctor);
        }
    }
}
