using Microsoft.EntityFrameworkCore;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class ProfissionalPersistence : IProfissionalPersist
    {
        private readonly ApplicationDbContext _context;

        public ProfissionalPersistence(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Profissional>> GetAllProfissionalAsync()
        {
            IQueryable<Profissional> query = _context.Profissionals;
            query = query.OrderBy(b => b.IdProfissional);

            return await query.ToListAsync();
        }

        public async Task<Profissional> GetProfissionalAsyncByEndereço(string profissionalEndereço)
        {
            IQueryable<Profissional> query = _context.Profissionals;
            query = query.AsNoTracking().Where(p => p.Endereço == profissionalEndereço);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Profissional> GetProfissionalAsyncById(int profissionalId)
        {
            IQueryable<Profissional> query = _context.Profissionals;
            query = query.AsNoTracking().Where(p => p.IdProfissional == profissionalId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Profissional> GetProfissionalAsyncByNome(string profissionalNome)
        {
            IQueryable<Profissional> query = _context.Profissionals;
            query = query.AsNoTracking().Where(p => p.Nome.ToLower().Contains(profissionalNome.ToLower())).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}