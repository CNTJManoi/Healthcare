using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using Healthcare.WPF.ViewModels;

namespace Healthcare.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationViewModel NavigationViewModel { get; set; }
        private SoundPlayer MusicPlayer { get; set; }

        public App()
        {
            MusicPlayer = new SoundPlayer();
            MusicPlayer.SoundLocation = @"D:\music.mp3";
            MusicPlayer.Load();
            MusicPlayer.Play();
        }
    }
}
