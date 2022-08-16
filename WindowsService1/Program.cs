using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

            string v1 = System.Configuration.ConfigurationManager.AppSettings["k1"];
            string v2 = System.Configuration.ConfigurationManager.AppSettings["k2"];
            string v3 = System.Configuration.ConfigurationManager.AppSettings["k3"];

            Console.WriteLine(v1 + " " + v2 + " " + v3);
            Console.ReadKey();

        }
    }
}
