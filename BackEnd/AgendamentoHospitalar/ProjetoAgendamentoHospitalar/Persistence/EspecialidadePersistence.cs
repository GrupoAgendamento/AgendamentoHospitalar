using Microsoft.EntityFrameworkCore;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class EspecialidadePersistence : IEspecialidadePersist
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadePersistence(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidade>> GetAllEspecialidadesAsync()
        {
            IQueryable<Especialidade> query = _context.Especialidades;
            query = query.OrderBy(b => b.IdEspecialidade);

            return await query.ToListAsync();
        }

        public async Task<Especialidade> GetEspecialidadeAsyncById(int especialidadeId)
        {
            IQueryable<Especialidade> query = _context.Especialidades;
            query = query.AsNoTracking().Where(b => b.IdEspecialidade == especialidadeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Especialidade> GetEspecialidadeAsyncByNome(string especialidadeNome)
        {
            IQueryable<Especialidade> query = _context.Especialidades;
            query = query.AsNoTracking().Where(b => b.Nome.ToLower().Contains(especialidadeNome.ToLower())).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}