using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceDebuggerHelper
{
    public interface IDebuggableService : INotifyPropertyChanged
    {
        void Start(string[] args);
        void StopService();
        void Pause();
        void Continue();
    }
}