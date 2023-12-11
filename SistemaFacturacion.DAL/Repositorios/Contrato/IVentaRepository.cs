using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.Model;
namespace SistemaFacturacion.DAL.Repositorios.Contrato
{
    public interface IVentaRepository : IGenericRepository<Dfactura>
    {
        Task<Dfactura> Registrar(Dfactura modelo);
    }
}
