using Examen.Core.Application.Dto;
using Examen.Core.Domain.Entity;
using System.ComponentModel.Design;

namespace Examen.Core.Application.Interfaces
{
    public interface IChoferRepository
    {
        Task<IEnumerable<Chofer>> GetAllChoferes();

        Task<IEnumerable<Chofer>> GetAllChoferesConTaxis();

        Task<IEnumerable<ChoferDTO>> GetChoferesTaxisAccesorios();

        Task<Chofer> CreateChofer(Chofer chofer);

        Task<Chofer> GetChoferById(int id);

        Task UpdateChofer(Chofer chofer);

        Task DeleteChofer(int id);
    }
}
