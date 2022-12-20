using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<List<Especialidade>> GetAllEspecialidades();
        Task<Especialidade> GetEspecialidadeById(int idEspecialidade);
        Task<Especialidade> GetEspecialidadeByNome(string especialidadeNome);
        Task<Especialidade> AddEspecialidade(Especialidade model);
        Task<Especialidade> UpdateEspecialidade(Especialidade model, int idEspecialidade);
        Task<bool> DeleteEspecialidade(int idEspecialidade);
    }
}
