using System;

namespace Net.Business.Entity.Modulos.Ventas
{
    public class GuiaElectronicaEntity
    {
        public int DocEntry { get; set; }
        public int DocNum { get; set; }

        public string SerieDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ClienteTipoDocumento { get; set; }
        public string ClienteNumeroDocumento { get; set; }
        public string ClienteDenominacion { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteEmail { get; set; }

        public DateTime FechaEmision { get; set; }
        public DateTime FechaInicioTraslado { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string MotivoTraslado { get; set; }
        public decimal PesoBrutoTotal { get; set; }
        public decimal NumeroBultos { get; set; }
        public string TipoTransporte { get; set; }

        public string TransportistaDocumentoNumero { get; set; }
        public string TransportistaDenominacion { get; set; }
        public string TransportistaPlacaNumero { get; set; }

        public string ConductorDocumentoTipo { get; set; }
        public string ConductorDocumentoNumero { get; set; }
        public string ConductorDenominacion { get; set; }
        public string ConductorNombre { get; set; }
        public string ConductorApellidos { get; set; }
        public string ConductorNumeroLicencia { get; set; }

        public string PuntoPartidaDireccion { get; set; }
        public string PuntoLlegadaDireccion { get; set; }
    }
}
