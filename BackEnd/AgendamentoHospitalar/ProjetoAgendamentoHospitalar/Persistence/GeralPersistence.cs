using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;

namespace ProjetoAgendamentoHospitalar.Persistence
{
    public class GeralPersistence : IGeralPersist
    {
        private readonly ApplicationDbContext _context;
        public GeralPersistence(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

      
    }
}