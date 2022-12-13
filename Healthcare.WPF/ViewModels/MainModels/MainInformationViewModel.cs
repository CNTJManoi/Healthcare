using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Logic;

namespace Healthcare.WPF.ViewModels.MainModels
{
    public class MainInformationViewModel : ViewModelBase
    {
        public string Welcome { get; set; }
        public string Text { get; set; }
        public string End { get; set; }

        public MainInformationViewModel(string hospitalName)
        {
            Welcome = "Мы рады приветствовать вас в официальном приложении нашего медицинского учреждения \"" + hospitalName + "\"!";
            Text =
                "На страницах нашего приложения Вы можете найти общую информацию о больнице и видах предоставляемой медицинской помощи, ознакомиться с историей и достижениями медицинского учреждения, со спецификой работы отделений, узнать об особенностях и порядках госпитализации.\n" +
                "Вы можете осуществить запись к врачу на необходимое Вам время, что позволит получить необходимую медицинскую помощь в достаточно быстрый срок\n" +
                "Мы надеемся, что наше приложение поможет Вам в получении своевременной, достоверной и полезной информации.";
            End = "С наилучшими пожеланиями, коллектив медицинского учреждения \"" + hospitalName + "\"";
        }
    }
}
