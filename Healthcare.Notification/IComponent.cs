using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Notification
{
    public interface IComponent
    {
        TypeNotification TypeNotification { get; }
        public void Notify(string result);
    }
}
