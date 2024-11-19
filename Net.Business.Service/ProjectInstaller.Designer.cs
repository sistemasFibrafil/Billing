namespace Net.Business.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerBilling = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerBilling = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerBilling
            // 
            this.serviceProcessInstallerBilling.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerBilling.Password = null;
            this.serviceProcessInstallerBilling.Username = null;
            // 
            // serviceInstallerBilling
            // 
            this.serviceInstallerBilling.Description = "Servicio de facturación electrónica";
            this.serviceInstallerBilling.DisplayName = "Facturación Electrónica Service";
            this.serviceInstallerBilling.ServiceName = "BillinElectrnicService";
            this.serviceInstallerBilling.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerBilling,
            this.serviceInstallerBilling});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerBilling;
        private System.ServiceProcess.ServiceInstaller serviceInstallerBilling;
    }
}