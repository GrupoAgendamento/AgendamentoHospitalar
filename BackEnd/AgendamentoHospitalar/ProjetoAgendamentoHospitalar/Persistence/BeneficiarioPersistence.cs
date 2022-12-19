using Microsoft.EntityFrameworkCore;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class BeneficiarioPersistence : IBeneficiarioPersist
    {
        private readonly ApplicationDbContext _context;

        public BeneficiarioPersistence(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Beneficiario>> GetAllBeneficiariosAsync()
        {
            IQueryable<Beneficiario> query = _context.Beneficiarios;
            query = query.OrderBy(b => b.IdBeneficiario);
           
           return await query.ToListAsync();
        }

        public async Task<Beneficiario> GetBeneficiarioAsyncByCpf(string beneficiarioCpf)
        {
            IQueryable<Beneficiario> query = _context.Beneficiarios;
            query = query.AsNoTracking().Where(b => b.Cpf == beneficiarioCpf);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Beneficiario> GetBeneficiarioAsyncById(int beneficiarioId)
        {
            IQueryable<Beneficiario> query = _context.Beneficiarios;
            query = query.AsNoTracking().Where(b => b.IdBeneficiario == beneficiarioId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Beneficiario> GetBeneficiarioAsyncByNome(string beneficiarioNome)
        {
            IQueryable<Beneficiario> query =  _context.Beneficiarios;
            query = query.AsNoTracking().Where(b => b.Nome.ToLower().Contains(beneficiarioNome.ToLower())).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}