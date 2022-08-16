using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        Timer timerVlog = new Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("Service started at " + DateTime.Now);
            timerVlog.Elapsed += new ElapsedEventHandler(TimeInterval);
            timerVlog.Interval = 10000;
            timerVlog.Enabled = true;
        }

        private void TimeInterval(object source,ElapsedEventArgs e)
        {
            WriteLog("Service is recall at " + DateTime.Now);
        }

        protected override void OnStop()
        {
            WriteLog("Service stopped at " + DateTime.Now);
        }
        private void WriteLog (string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
            if(!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string file = path + DateTime.Now.ToString("dd-MM-yyy") + ".txt";
            if (!System.IO.File.Exists(file))
            {
                using(StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(message);
                }
            }

        }

    }
}
