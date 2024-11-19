using System;
using System.IO;
using System.Timers;
using Net.CrossCotting;
using Net.Data.Repository;
using System.Configuration;
using System.ServiceProcess;

namespace Net.Business.Service
{
    public partial class BillingService : ServiceBase
    {
        private Timer _timer;
        private IFacturaElectronicaRepository _facturaElectronicaRepository;

        public BillingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Iniciar();
        }

        protected override void OnStop()
        {
            Parar();
        }

        #region <<< Métodos privados >>>
        private void Iniciar()
        {
            _timer = new Timer();
            _timer.Interval = int.Parse(ConfigurationManager.AppSettings["intervalo"].ToString());
            _timer.Elapsed += SetSendComprobante;
            _timer.Start();

            StreamWriter sw = new StreamWriter("C:\\Servicio de facturacion electronica\\log.txt", true);
            sw.WriteLine("Star Service: {0:HH:mm:ss.fff}", DateTime.Now);
            sw.Close();
        }

        private void SetSendComprobante(object sender, ElapsedEventArgs e)
        {
            _facturaElectronicaRepository = new FacturaElectronicaRepository();
            var response = _facturaElectronicaRepository.GetListFacturaElectronica();

            //CreateFile.SaveLog(response.ResultadoDescripcion);

            //CreateFile.SaveLog("Evento Service");

            StreamWriter sw = new StreamWriter("C:\\Servicio de facturacion electronica\\log.txt", true);
            sw.WriteLine(response.ResultadoDescripcion + " : {0:HH:mm:ss.fff}", DateTime.Now);
            sw.Close();
        }

        private void Parar()
        {
            _timer.Stop();
            _timer.Dispose();

            //CreateFile.SaveLog("Stop Service");

            StreamWriter sw = new StreamWriter("C:\\Servicio de facturacion electronica\\log.txt", true);
            sw.WriteLine("Stop Service: {0:HH:mm:ss.fff}", DateTime.Now);
            sw.Close();
        }
        #endregion
    }
}
