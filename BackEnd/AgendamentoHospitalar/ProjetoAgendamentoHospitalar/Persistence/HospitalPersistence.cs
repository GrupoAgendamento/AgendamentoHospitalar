using Microsoft.EntityFrameworkCore;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class HospitalPersistence : IHospitalPersist
    {
        private readonly ApplicationDbContext _context;

        public HospitalPersistence(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hospital>> GetAllHospitaisAsync()
        {
            IQueryable<Hospital> query = _context.Hospitals;
            query = query.OrderBy(b => b.IdHospital);

            return await query.ToListAsync();
        }

        public async Task<Hospital> GetHospitalAsyncByCnpj(string hospitalCnpj)
        {
            IQueryable<Hospital> query = _context.Hospitals;
            query = query.AsNoTracking().Where(b => b.Cnpj == hospitalCnpj);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Hospital> GetHospitalAsyncById(int hospitalId)
        {
            IQueryable<Hospital> query = _context.Hospitals;
            query = query.AsNoTracking().Where(b => b.IdHospital == hospitalId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Hospital> GetHospitalAsyncByNome(string hospitalNome)
        {
            IQueryable<Hospital> query = _context.Hospitals;
            query = query.AsNoTracking().Where(b => b.Nome.ToLower().Contains(hospitalNome.ToLower())).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}