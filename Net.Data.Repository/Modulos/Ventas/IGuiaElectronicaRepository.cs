using Net.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Data.Repository
{ 
    public interface IGuiaElectronicaRepository
    {
        ResultadoTransaccion<FacturaElectronicaEntity> GetListGuiaElectronica();
    }
}
