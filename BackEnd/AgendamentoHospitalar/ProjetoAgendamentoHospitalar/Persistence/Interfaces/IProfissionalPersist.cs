using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IProfissionalPersist
    {
        Task<List<Profissional>> GetAllProfissionalAsync();
        Task<Profissional> GetProfissionalAsyncById(int profissionalId);
        Task<Profissional> GetProfissionalAsyncByNome(string profissionalNome);

        Task<Profissional> GetProfissionalAsyncByEndereço(string profissionalEndereço);
    }
}