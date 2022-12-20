using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IEspecialidadePersist
    {
        Task<List<Especialidade>> GetAllEspecialidadesAsync();
        Task<Especialidade> GetEspecialidadeAsyncById(int especialidadeId);
        Task<Especialidade> GetEspecialidadeAsyncByNome(string especialidadeNome);
    }
}