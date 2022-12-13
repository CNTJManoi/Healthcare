using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Database;
using Healthcare.Logic;
using Healthcare.WPF.Command;
using Healthcare.WPF.ViewModels.MainModels;
using Healthcare.WPF.ViewModels.Utilites;
using Healthcare.WPF.Views.Pages.Main;

namespace Healthcare.WPF.ViewModels
{
    internal class MainPageViewModel : ChangePagesBase
    {
        private Hospital _hospital;

        private ViewModelBase _mainInformation;
        private ViewModelBase _appointmentDoctor;

        private DelegateCommand _goToMain;
        private DelegateCommand _goToRecording;
        private DelegateCommand _exitCommand;

        public DelegateCommand ExitCommand => _exitCommand ??
                                              (_exitCommand = new DelegateCommand(Exit));
        public DelegateCommand MainCommand => _goToMain ??
                                              (_goToMain = new DelegateCommand(GoToMainPage));
        public DelegateCommand RecordingCommand => _goToRecording ??
                                                   (_goToRecording = new DelegateCommand(GoToRecordingPage));

        public MainPageViewModel()
        {
            var dm = new DatabaseManager();
            _hospital = dm.LoadDatabase();
            _mainInformation = new MainInformationViewModel(_hospital.Name);
            _appointmentDoctor = new AppointmentDoctorViewModel(_hospital);
            GoToMainPage(null);
        }
        public void Exit(object obj)
        {
            Environment.Exit(0);
        }
        public void GoToMainPage(object obj)
        {
            ChangePage(_mainInformation);
        }
        public void GoToRecordingPage(object obj)
        {
            ChangePage(_appointmentDoctor);
        }
    }
}
