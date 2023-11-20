using Camioneros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Camioneros.Data.Repositorio
{
    public interface InterfaceCamionero
    {
        Task<IEnumerable<Camionero>> GetAllCamionero();
        Task<Camionero> GetCamionero(int id);
        Task<bool> InsertCamionero(Camionero camionero);
        Task<bool> UpdateCamionero(Camionero camionero);
        Task<bool> DeleteCamionero(Camionero camionero);

    }
}
