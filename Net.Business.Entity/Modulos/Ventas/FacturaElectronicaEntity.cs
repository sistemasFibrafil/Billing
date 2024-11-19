using System;

namespace Net.Business.Entity
{
    public class FacturaElectronicaEntity
    {
        public int DocEntry { get; set; }
        public string CodEstadoSunat { get; set; }
        public string DesEstadoSunat { get; set; }
        public string ObjType { get; set; }

        public string Operacion { get; set; }
        public int TipoComprobante { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int SunatTransaction { get; set; }
        public int ClienteTipoDocumento { get; set; }
        public string ClienteNumeroDocumento { get; set; }
        public string ClienteDenominacion { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteEmail1 { get; set; }
        public string ClienteEmail2 { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public double PorcentajeIgv { get; set; }
        public decimal DescuentoGlobal { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalAnticipo { get; set; }
        public decimal TotalGravada { get; set; }
        public decimal TotalInafecta { get; set; }
        public decimal TotalExonerada { get; set; }
        public double TotalIgv { get; set; }
        public decimal TotalGratuita { get; set; }
        public decimal TotalOtrosCargos { get; set; }
        public double Total { get; set; }
        public int PercepcionTipo { get; set; }
        public decimal PercepcionBaseImponible { get; set; }
        public decimal TotalPercepcion { get; set; }
        public decimal TotalIncluidoPercepcion { get; set; }
        public int RetencionTipo { get; set; }
        public double RetencionBaseImponible { get; set; }
        public double TotalRetencion { get; set; }
        public bool Detraccion { get; set; }
        public int DetraccionTipo { get; set; }
        public double DetraccionTotal { get; set; }
        public int MedioPagoDetraccion { get; set; }
        public string Observaciones { get; set; }
        public string DocumentoQueSeModificaTipo { get; set; }
        public string DocumentoQuSeModificaSerie { get; set; }
        public int DocumentoQueSeModificaNumero { get; set; }
        public int TipoNotaCredito { get; set; }
        public int TipoNotaDebito { get; set; }
        public bool EnviarAutomaticamenteSunat { get; set; }
        public bool EnviarAutomaticamenteCliente { get; set; }
        public string CodigoUnico { get; set; }
        public string CondicionesPago { get; set; }
        public string MedioPago { get; set; }
        public string PlacaVehiculo { get; set; }
        public string OrdenCompraServicio { get; set; }
        public string TablaPersonalizadaCodigo { get; set; }
        public string FormatoPdf { get; set; }
    }

    public class FacturaElectronicaDetalleEntity
    {
        public string UnidadMedida { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double ValorUnitario { get; set; }
        public double PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public double SubTotal { get; set; }
        public int TipoIgv { get; set; }
        public double Igv { get; set; }
        public double Total { get; set; }
        public bool AnticipoRegularizacion { get; set; }
        public string AnticipoDocumentoSerie { get; set; }
        public string AnticipoDocumentoNumero { get; set; }
    }

    public class FacturaElectronicaGuiaEntity
    {
        public int GuiaTipo { get; set; }
        public string GuiaSerieNumero { get; set; }
    }

    public class FacturaElectronicaVentaCreditoEntity
    {
        public int Cuota { get; set; }
        public DateTime FechaPago { get; set; }
        public double Importe { get; set; }
    }
}
