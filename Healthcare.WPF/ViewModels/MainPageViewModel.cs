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
        private ViewModelBase _infoView;
        private ViewModelBase _profileView;

        private DelegateCommand _goToMain;
        private DelegateCommand _goToRecording;
        private DelegateCommand _goToProfile;
        private DelegateCommand _infoCommand;
        private DelegateCommand _exitCommand;

        public DelegateCommand ExitCommand => _exitCommand ??
                                              (_exitCommand = new DelegateCommand(Exit));
        public DelegateCommand ProfileCommand => _goToProfile ??
                                              (_goToProfile = new DelegateCommand(GoToProfilePage));
        public DelegateCommand InfoCommand => _infoCommand ??
                                              (_infoCommand = new DelegateCommand(GoToInfoPage));
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
            _infoView = new InfoViewModel();
            _profileView = new ProfileViewModel(_hospital.Buildings.ToList()[0].Patients.ToList()[0],
                _hospital.Buildings.ToList()[0]);
            GoToMainPage(null);
        }
        public void Exit(object obj)
        {
            App.OnMusic();
            Environment.Exit(0);
        }
        public void GoToInfoPage(object obj)
        {
            App.OffMusic();
            ChangePage(_infoView);
        }
        public void GoToProfilePage(object obj)
        {
            App.OnMusic();
            ChangePage(_profileView);
        }
        public void GoToMainPage(object obj)
        {
            App.OnMusic();
            ChangePage(_mainInformation);
        }
        public void GoToRecordingPage(object obj)
        {
            App.OnMusic();
            ChangePage(_appointmentDoctor);
        }
    }
}
