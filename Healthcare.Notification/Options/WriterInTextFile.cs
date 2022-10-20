using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Json;
using Healthcare.Logic;
using Healthcare.Logic.Reception.Models;

namespace Healthcare.Notification.Options
{
    internal class WriterInTextFile : IComponent
    {
        public WriterInTextFile()
        {
            TypeNotification = TypeNotification.File;
        }

        public TypeNotification TypeNotification { get; }
        public void Notify(string result)
        {

            if (File.Exists(FileData.FileResultPath)) File.Delete(FileData.FileResultPath);
            File.Create(FileData.FileResultPath).Close();
            File.WriteAllText(FileData.FileResultPath, result);
        }
    }
}
