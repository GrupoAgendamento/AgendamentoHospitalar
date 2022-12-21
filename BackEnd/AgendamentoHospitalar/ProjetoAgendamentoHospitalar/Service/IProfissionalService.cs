using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IProfissionalService
    {
        Task<Profissional> AddProfissional(Profissional model);
        Task<Profissional> UpdateProfissional(Profissional model, int idProfissional);
        Task<bool> DeleteProfissional(int idProfissional);
        Task<Profissional> GetProfissionalById(int idProfissional);
        Task<List<Profissional>> GetAllProfissional();
        Task<Profissional> GetProfissionalByEndereço(string profissionalEndereço);
        Task<Profissional> GetProfissionalByNome(string profissionalNome);
    }
}