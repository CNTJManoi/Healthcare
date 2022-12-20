using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Healthcare.WPF.ViewModels;

namespace Healthcare.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationViewModel NavigationViewModel { get; set; }
        public static MediaPlayer MusicPlayer { get; private set; }

        public App()
        {
            MusicPlayer = new MediaPlayer();
            MusicPlayer.Open(new Uri(@"D:\music.wav"));
            MusicPlayer.Play();
        }

        public static void OffMusic()
        {
            MusicPlayer.Volume = 0;
        }
        public static void OnMusic()
        {
            MusicPlayer.Volume = 1;
        }
    }
}
