using Examen.Core.Application.Dto;
using Examen.Core.Application.Interfaces;
using Examen.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Examen.Infrastructure.Persistence
{
    public class ChoferRepository : IChoferRepository
    {
        private readonly ApplicationDbContext _context;

        public ChoferRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Chofer>> GetAllChoferes()
        {
            return await _context.Choferes.ToListAsync();
        }

        public async Task<IEnumerable<Chofer>> GetAllChoferesConTaxis()
        {
            return await _context.Choferes
                .Include(cho => cho.Taxis)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChoferDTO>> GetChoferesTaxisAccesorios() {
            var chofer = await _context.Choferes
                .Include(cho => cho.Taxis)
                .ThenInclude(tax => tax.Accesorios)
                .ToListAsync();

            var choferDto = chofer
                //.Where(cho => cho.Edad > 30)
                .Select(cho => new ChoferDTO
                {
                    Nombre = cho.Nombre,
                    Edad = cho.Edad,
                    Taxis = cho.Taxis
                    //.Where(tax => tax.Kilometraje > 90)
                    .Select(tax => new TaxiDTO
                    {
                        Modelo = tax.Modelo,
                        Kilometraje = tax.Kilometraje,
                        Accesorios = tax.Accesorios
                        .Select(acc => new AccesorioDTO
                        {
                            Nombre = acc.Nombre,
                            Precio = acc.Precio,
                            Cantidad = acc.Cantidad
                        }).ToList()
                    }).ToList()
                }).ToList();

            return choferDto;
        }

        public async Task<Chofer> CreateChofer(Chofer chofer) {
            _context.Choferes.Add(chofer);
            await _context.SaveChangesAsync();
            return chofer;
        }

        public async Task<Chofer> GetChoferById(int id)
        {
            return await _context.Choferes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateChofer(Chofer chofer)
        {
            _context.Entry(chofer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChofer(int id)
        {
            var chofer = await _context.Choferes.FindAsync(id);
            if (chofer != null)
            {
                _context.Choferes.Remove(chofer);
                await _context.SaveChangesAsync();
            }
        }

    }
}
