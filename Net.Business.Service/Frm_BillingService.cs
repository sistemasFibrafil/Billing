using System;
using Net.CrossCotting;
using Net.Data.Repository;
using System.Configuration;
using System.Windows.Forms;

namespace Net.Business.Service
{
    public partial class Frm_BillingService : Form
    {
        private Timer _timer;
        private IFacturaElectronicaRepository _facturaElectronicaRepository;

        public Frm_BillingService()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _timer = new Timer();
            _timer.Interval = 100;// int.Parse(ConfigurationManager.AppSettings["intervalo"].ToString());
            _timer.Enabled = true;
            _timer.Tick += new EventHandler(SetSendComprobante);
            _timer.Start();

            CreateFile.SaveLog("Start Service");
        }

        private void SetSendComprobante(object sender, EventArgs e)
        {
            _facturaElectronicaRepository = new FacturaElectronicaRepository();
            var response = _facturaElectronicaRepository.GetListFacturaElectronica();

            CreateFile.SaveLog(response.ResultadoDescripcion);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();
            _timer.Dispose();

            CreateFile.SaveLog("Stop Service");
        }
    }
}
