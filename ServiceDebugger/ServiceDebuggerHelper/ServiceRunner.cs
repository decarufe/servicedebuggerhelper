using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace ServiceDebuggerHelper
{
    public partial class ServiceRunner : Form
    {
        private readonly IDebuggableService _theService;
        private readonly ServiceBase winService;

        public ServiceRunner(IDebuggableService service)
        {
            InitializeComponent();
            _theService = service;
            winService = _theService as ServiceBase;
            if (winService == null)
                throw new ArgumentException("{0} is not a ServiceBase class", "service");
            pauseButton.Enabled = continueButton.Enabled = winService.CanPauseAndContinue;
            Text = winService.ServiceName + " Controler";
            Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _theService.Start(new string[] {});
            toolStripStatusLabel1.Text = "Started";
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            _theService.Pause();
            toolStripStatusLabel1.Text = "Paused";
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            _theService.Continue();
            toolStripStatusLabel1.Text = "Started";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _theService.StopService();
            toolStripStatusLabel1.Text = "Stopped";
        }
    }
}