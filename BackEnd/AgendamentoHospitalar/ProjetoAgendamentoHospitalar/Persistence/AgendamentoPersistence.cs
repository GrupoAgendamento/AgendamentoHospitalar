using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class AgendamentoPersistence : IAgendamentoPersist
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoPersistence(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> GetAllAgendamentosAsync()
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdBeneficiario);

            return await query.ToListAsync();
        }

        public async Task<Agendamento> GetAgendamentoAsyncById(int agendamentoId)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdAgendamento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Agendamento>> GetAgendamentoAsyncByBeneficiario(int idBeneficiario)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdBeneficiario);

            return await query.Where(qr => qr.IdBeneficiario.Equals(idBeneficiario)).ToListAsync();
        }

        public async Task<List<Agendamento>> GetAgendamentoAsyncByEspecialidade(int idEspecialidade)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdEspecialidade);

            return await query.Where(qr => qr.IdEspecialidade.Equals(idEspecialidade)).ToListAsync();
        }

        public async Task<List<Agendamento>> GetAgendamentoAsyncByProfissional(int idProfissional)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdProfissional);

            return await query.Where(qr => qr.IdProfissional.Equals(idProfissional)).ToListAsync();
        }

        public async Task<List<Agendamento>> GetAgendamentoAsyncByHospital(int idHospital)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.IdHospital);

            return await query.Where(qr => qr.IdHospital.Equals(idHospital)).ToListAsync();
        }

        public async Task<List<Agendamento>> GetAgendamentoAsyncByData(DateTime agendamentoData)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.OrderBy(b => b.DataHoraAgendamento);

            return await query.Where(qr => qr.DataHoraAgendamento.Equals(agendamentoData)).ToListAsync();
        }
    }
}
