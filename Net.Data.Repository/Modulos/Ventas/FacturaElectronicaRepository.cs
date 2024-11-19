using Dapper;
using System;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using Net.CrossCotting;
using Net.Business.Entity;
using Net.Data.Connection;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Net.Data.Repository
{
    public class FacturaElectronicaRepository : RepositoryBase, IFacturaElectronicaRepository
    {
        private string _metodoName;
        private readonly string _aplicacionName;
        private readonly Regex regex = new Regex(@"<(\w+)>.*");

        private readonly IConnectionSQL _connectionSQL;

        // STORED PROCEDURE
        const string DB_ESQUEMA = "";

        const string SP_GET_LIST_FACTURA_ELECTRONICA = DB_ESQUEMA + "FIB_GetFacturaElectronica";
        const string SP_GET_LIST_FACTURA_ELECTRONICA_DETALLE = DB_ESQUEMA + "FIB_GetFacturaElectronicaDetalle";
        const string SP_GET_LIST_FACTURA_ELECTRONICA_GUIA = DB_ESQUEMA + "FIB_GetFacturaElectronicaGuia";
        const string SP_GET_LIST_FACTURA_ELECTRONICA_VENTACREDITO = DB_ESQUEMA + "FIB_GetFacturaElectronicaVentaCredito";

        const string SP_SET_UPDATE_FACTURA_ELECTRONICA = DB_ESQUEMA + "FIB_SetFacturaElectronicaUpdate";
        const string SP_SET_UPDATE_FACTURA_ELECTRONICAERROR = DB_ESQUEMA + "FIB_SetFacturaElectronicaErrorUpdate";

        public FacturaElectronicaRepository()
        {
            _connectionSQL = new ConnectionSQL();
        }

        public ResultadoTransaccion<FacturaElectronicaEntity> GetListFacturaElectronica()
        {
            var dynamicParameters = new DynamicParameters();
            var resultadoTransaccion = new ResultadoTransaccion<FacturaElectronicaEntity>();

            _metodoName = regex.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Groups[1].Value.ToString();

            resultadoTransaccion.NombreMetodo = _metodoName;
            resultadoTransaccion.NombreAplicacion = _aplicacionName;

            try
            {
                using (var conexion = _connectionSQL.GetConnection())
                {
                    var listFactura = GetDataList<FacturaElectronicaEntity>(conexion, SP_GET_LIST_FACTURA_ELECTRONICA, dynamicParameters, CommandType.StoredProcedure).ToList();

                    foreach (FacturaElectronicaEntity factura in listFactura)
                    {
                        Invoice invoiceQuery = new Invoice();
                        invoiceQuery.operacion = factura.Operacion;
                        invoiceQuery.tipo_de_comprobante = factura.TipoComprobante;
                        invoiceQuery.serie = factura.Serie;
                        invoiceQuery.numero = factura.Numero;

                        Invoice invoice = new Invoice();
                        invoice.operacion = factura.Operacion;
                        invoice.tipo_de_comprobante = factura.TipoComprobante;
                        invoice.serie = factura.Serie;
                        invoice.numero = factura.Numero;
                        invoice.sunat_transaction = factura.SunatTransaction;
                        invoice.cliente_tipo_de_documento = factura.ClienteTipoDocumento;
                        invoice.cliente_numero_de_documento = factura.ClienteNumeroDocumento;
                        invoice.cliente_denominacion = factura.ClienteDenominacion;
                        invoice.cliente_direccion = factura.ClienteDireccion;
                        invoice.cliente_email = factura.ClienteEmail;
                        invoice.cliente_email_1 = factura.ClienteEmail1;
                        invoice.cliente_email_2 = factura.ClienteEmail2;
                        invoice.fecha_de_emision = factura.FechaEmision;
                        invoice.fecha_de_vencimiento = factura.FechaVencimiento;
                        invoice.moneda = factura.Moneda;
                        invoice.tipo_de_cambio = factura.TipoCambio;
                        invoice.porcentaje_de_igv = factura.PorcentajeIgv;
                        invoice.descuento_global = factura.DescuentoGlobal;
                        invoice.total_descuento = factura.TotalDescuento;
                        invoice.total_anticipo = factura.TotalAnticipo;
                        invoice.total_gravada = factura.TotalGravada;
                        invoice.total_inafecta = factura.TotalInafecta;
                        invoice.total_exonerada = factura.TotalExonerada;
                        invoice.total_igv = factura.TotalIgv;
                        invoice.total_gratuita = factura.TotalGratuita;
                        invoice.total_otros_cargos = factura.TotalOtrosCargos;
                        invoice.total = factura.Total;
                        if (factura.PercepcionTipo != 0)
                        {
                            invoice.percepcion_tipo = factura.PercepcionTipo;
                            invoice.percepcion_base_imponible = factura.PercepcionBaseImponible;
                            invoice.total_percepcion = factura.TotalPercepcion;
                            invoice.total_incluido_percepcion = factura.TotalIncluidoPercepcion;
                        }
                        if (factura.RetencionTipo != 0)
                        {
                            invoice.retencion_tipo = factura.RetencionTipo;
                            invoice.retencion_base_imponible = factura.RetencionBaseImponible;
                            invoice.total_retencion = factura.TotalRetencion;
                        }
                        if (factura.Detraccion)
                        {
                            invoice.detraccion = factura.Detraccion;
                            invoice.detraccion_total = factura.DetraccionTotal;
                            invoice.medio_de_pago_detraccion = factura.MedioPagoDetraccion;
                            invoice.medio_de_pago_detraccion = factura.MedioPagoDetraccion;
                        }
                        else
                        {
                            invoice.detraccion = factura.Detraccion;
                        }
                        if (factura.DocumentoQueSeModificaTipo != "")
                        {
                            invoice.documento_que_se_modifica_tipo = factura.DocumentoQueSeModificaTipo;
                            invoice.documento_que_se_modifica_serie = factura.DocumentoQuSeModificaSerie;
                            invoice.documento_que_se_modifica_numero = factura.DocumentoQueSeModificaNumero;
                        }
                        if (factura.TipoNotaCredito != 0)
                        {
                            invoice.tipo_de_nota_de_credito = factura.TipoNotaCredito;
                        }
                        if (factura.TipoNotaDebito != 0)
                        {
                            invoice.tipo_de_nota_de_debito = factura.TipoNotaDebito;
                        }
                        invoice.enviar_automaticamente_a_la_sunat = factura.EnviarAutomaticamenteSunat;
                        invoice.enviar_automaticamente_a_la_sunat = factura.EnviarAutomaticamenteSunat;
                        invoice.codigo_unico = factura.CodigoUnico;
                        invoice.condiciones_de_pago = factura.CondicionesPago;
                        invoice.medio_de_pago = factura.MedioPago;
                        invoice.placa_vehiculo = factura.PlacaVehiculo;
                        invoice.orden_compra_servicio = factura.OrdenCompraServicio;
                        invoice.tabla_personalizada_codigo = factura.TablaPersonalizadaCodigo;
                        invoice.formato_de_pdf = factura.FormatoPdf;

                        dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("@ObjType", factura.ObjType);
                        dynamicParameters.Add("@DocEntry", factura.DocEntry);
                        var listFacturaDetalle = GetDataList<FacturaElectronicaDetalleEntity>(conexion, SP_GET_LIST_FACTURA_ELECTRONICA_DETALLE, dynamicParameters, CommandType.StoredProcedure).ToList();

                        foreach (var detalle in listFacturaDetalle)
                        {
                            invoice.items.Add(new ItemsFacturas
                            {
                                unidad_de_medida = detalle.UnidadMedida,
                                codigo = detalle.Codigo,
                                descripcion = detalle.Descripcion,
                                cantidad = detalle.Cantidad,
                                valor_unitario = detalle.ValorUnitario,
                                precio_unitario = detalle.PrecioUnitario,
                                descuento = detalle.Descuento,
                                subtotal = detalle.SubTotal,
                                tipo_de_igv = detalle.TipoIgv,
                                igv = detalle.Igv,
                                total = detalle.Total,
                                anticipo_regularizacion = detalle.AnticipoRegularizacion,
                                anticipo_documento_serie = detalle.AnticipoDocumentoSerie,
                                anticipo_documento_numero = detalle.AnticipoDocumentoNumero,
                            });
                        }

                        if (factura.ObjType == "13" && (factura.TipoComprobante == 1 || factura.TipoComprobante == 2))
                        {
                            dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@DocEntry", factura.DocEntry);
                            var listGuias = GetDataList<FacturaElectronicaGuiaEntity>(conexion, SP_GET_LIST_FACTURA_ELECTRONICA_GUIA, dynamicParameters, CommandType.StoredProcedure).ToList();

                            foreach (var guia in listGuias)
                            {
                                invoice.guias.Add(new Guias
                                {
                                    guia_tipo = guia.GuiaTipo,
                                    guia_serie_numero = guia.GuiaSerieNumero
                                });
                            }

                            dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@ObjType", factura.ObjType);
                            dynamicParameters.Add("@DocEntry", factura.DocEntry);
                            var listVentaCredito = GetDataList<FacturaElectronicaVentaCreditoEntity>(conexion, SP_GET_LIST_FACTURA_ELECTRONICA_VENTACREDITO, dynamicParameters, CommandType.StoredProcedure).ToList();

                            foreach (var ventaCredito in listVentaCredito)
                            {
                                invoice.venta_al_credito.Add(new Venta_al_credito
                                {
                                    cuota = ventaCredito.Cuota,
                                    fecha_de_pago = ventaCredito.FechaPago,
                                    importe = ventaCredito.Importe,
                                });
                            }
                        }

                        var jSon = JsonConvert.SerializeObject(invoice, Formatting.Indented);

                        var responseSend = SendComprobanteElectronico.GetRespuesta(jSon);

                        if (responseSend.errors == null)
                        {
                            resultadoTransaccion = SetUpdateFacturaElectronicaEnvio(factura, responseSend, conexion);
                        }
                        else if (responseSend.errors.ToUpper().Contains("EXISTE"))
                        {
                            var jSonQuery = JsonConvert.SerializeObject(invoiceQuery, Formatting.Indented);
                            var responseQuery = SendComprobanteElectronico.GetRespuesta(jSonQuery);

                            resultadoTransaccion = SetUpdateFacturaElectronicaConsulta(factura, responseSend, conexion);
                        }
                        else
                        {
                            resultadoTransaccion = SetUpdateFacturaElectronicaError(factura, responseSend, conexion);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                resultadoTransaccion.IdRegistro = -1;
                resultadoTransaccion.ResultadoCodigo = -1;
                resultadoTransaccion.ResultadoDescripcion = ex.Message.ToString();
            }

            return resultadoTransaccion;
        }

        private ResultadoTransaccion<FacturaElectronicaEntity> SetUpdateFacturaElectronicaEnvio(FacturaElectronicaEntity factura, RespuestaNubefact respuesta, SqlConnection conn)
        {
            var resultadoTransaccion = new ResultadoTransaccion<FacturaElectronicaEntity>();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocEntry", factura.DocEntry);
            dynamicParameters.Add("@ObjType", factura.ObjType);
            dynamicParameters.Add("@AceptadaPorSunat", respuesta.aceptada_por_sunat);
            dynamicParameters.Add("@SunatDescription", respuesta.sunat_description);
            dynamicParameters.Add("@SunatNote", respuesta.sunat_note);
            dynamicParameters.Add("@SunatResponsecode", respuesta.sunat_responsecode);
            dynamicParameters.Add("@SunatSoapError", respuesta.sunat_soap_error);
            dynamicParameters.Add("@CadenaParaCodigoQr", respuesta.cadena_para_codigo_qr);
            dynamicParameters.Add("@CodigoHash", respuesta.codigo_hash);

            Execute(conn, SP_SET_UPDATE_FACTURA_ELECTRONICA, dynamicParameters, CommandType.StoredProcedure);

            resultadoTransaccion.IdRegistro = 0;
            resultadoTransaccion.ResultadoCodigo = 0;
            resultadoTransaccion.ResultadoDescripcion = "El documento se envío con éxito...!!!";

            return resultadoTransaccion;
        }

        private ResultadoTransaccion<FacturaElectronicaEntity> SetUpdateFacturaElectronicaConsulta(FacturaElectronicaEntity factura, RespuestaNubefact respuesta, SqlConnection conn)
        {
            var resultadoTransaccion = new ResultadoTransaccion<FacturaElectronicaEntity>();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocEntry", factura.DocEntry);
            dynamicParameters.Add("@ObjType", factura.ObjType);
            dynamicParameters.Add("@AceptadaPorSunat", respuesta.aceptada_por_sunat);
            dynamicParameters.Add("@SunatDescription", respuesta.sunat_description);
            dynamicParameters.Add("@SunatNote", respuesta.sunat_note);
            dynamicParameters.Add("@SunatResponsecode", respuesta.sunat_responsecode);
            dynamicParameters.Add("@SunatSoapError", respuesta.sunat_soap_error);
            dynamicParameters.Add("@CadenaParaCodigoQr", respuesta.cadena_para_codigo_qr);
            dynamicParameters.Add("@CodigoHash", respuesta.codigo_hash);

            Execute(conn, SP_SET_UPDATE_FACTURA_ELECTRONICA, dynamicParameters, CommandType.StoredProcedure);

            resultadoTransaccion.IdRegistro = 0;
            resultadoTransaccion.ResultadoCodigo = 0;
            resultadoTransaccion.ResultadoDescripcion = "El documento actualizada con éxito...!!!";

            return resultadoTransaccion;
        }

        private ResultadoTransaccion<FacturaElectronicaEntity> SetUpdateFacturaElectronicaError(FacturaElectronicaEntity factura, RespuestaNubefact respuesta, SqlConnection conn)
        {
            var resultadoTransaccion = new ResultadoTransaccion<FacturaElectronicaEntity>();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocEntry", factura.DocEntry);
            dynamicParameters.Add("@ObjType", factura.ObjType);
            dynamicParameters.Add("@Error", respuesta.errors);

            Execute(conn, SP_SET_UPDATE_FACTURA_ELECTRONICAERROR, dynamicParameters, CommandType.StoredProcedure);

            resultadoTransaccion.IdRegistro = -1;
            resultadoTransaccion.ResultadoCodigo = -1;
            resultadoTransaccion.ResultadoDescripcion = respuesta.errors;

            return resultadoTransaccion;
        }
    }
}
