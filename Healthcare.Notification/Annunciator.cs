﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Notification.Options;

namespace Healthcare.Notification
{
    public class Annunciator
    {
        List<IComponent> _components;

        public Annunciator()
        {
            _components = new List<IComponent>();
            _components.Add(new WriterInTextFile());
        }
        public void Add(IComponent component)
        {
            _components.Add(component);
        }
        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }

        public void Notify(string result)
        {
            foreach (var component in _components)
            {
                component.Notify(result);
            }
        }
        public void Notify(string result, TypeNotification tn)
        {
            foreach (var component in _components)
            {
                if(component.TypeNotification == tn) component.Notify(result);
            }
        }
    }
}
