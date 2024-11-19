using System.ServiceProcess;
using System.Windows.Forms;

namespace Net.Business.Service
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new BillingService()
            //};
            //ServiceBase.Run(ServicesToRun);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_BillingService());
        }
    }
}
