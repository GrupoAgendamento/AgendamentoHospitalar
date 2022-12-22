using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class AgendamentoConfiguracaoPersistence : IAgendamentoConfiguracaoPersist
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoConfiguracaoPersistence(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AgendamentoConfiguracao>> GetAllAgendamentoConfiguracaosAsync()
        {
            IQueryable<AgendamentoConfiguracao> query = _context.AgendamentoConfiguracaos;
            query = query.OrderBy(a => a.IdConfiguracao);
            return await query.ToListAsync();
        }
        public async Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncById(int idConfiguracao)
        {
            IQueryable<AgendamentoConfiguracao> query = _context.AgendamentoConfiguracaos; 
            query = query.AsNoTracking().Where(a => a.IdConfiguracao == idConfiguracao);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdEspecialidade(int idEspecialidade)
        {
            IQueryable<AgendamentoConfiguracao> query = _context.AgendamentoConfiguracaos;
            query = query.AsNoTracking().Where(a => a.IdEspecialidade == idEspecialidade);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdHospital(int idHospital)
        {
            IQueryable<AgendamentoConfiguracao> query = _context.AgendamentoConfiguracaos;
            query = query.AsNoTracking().Where(a => a.IdHospital == idHospital);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdProfissional(int idProfissional)
        {
            IQueryable<AgendamentoConfiguracao> query = _context.AgendamentoConfiguracaos;
            query = query.AsNoTracking().Where(a => a.IdProfissional == idProfissional);
            return await query.FirstOrDefaultAsync();
        }
    }
}