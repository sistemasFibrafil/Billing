using Dapper;
using Net.Business.Entity;

namespace Net.Data.Repository
{
    public interface IFacturaElectronicaRepository
    {
        ResultadoTransaccion<FacturaElectronicaEntity> GetListFacturaElectronica();
    }
}
