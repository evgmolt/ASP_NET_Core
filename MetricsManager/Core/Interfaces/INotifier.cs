using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Interfaces
{
    public interface INotifier
    {
        void Notify();

        bool CanRun();
    }

    public class Notifier1 : INotifier
    {
        public bool CanRun()
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            Debug.WriteLine("Debugging from Notifier 1");
        }
    }
}
