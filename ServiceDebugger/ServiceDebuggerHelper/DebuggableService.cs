using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceDebuggerHelper
{
    public class DebuggableService : ServiceBase, IDebuggableService
    {
        public void Start(string[] args)
        {
            OnStart(args);
        }

        public void StopService()
        {
            OnStop();
        }

        public void Pause()
        {
            OnPause();
        }

        public void Continue()
        {
            OnContinue();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        protected void RaisePropertyChanged(params string[] properties)
        {
            foreach (string property in properties)
                OnPropertyChanged(new PropertyChangedEventArgs(property));
        }

        #endregion

    }
}