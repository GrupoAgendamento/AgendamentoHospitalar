using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IAgendamentoConfiguracaoPersist
    {
        Task<List<AgendamentoConfiguracao>> GetAllAgendamentoConfiguracaosAsync();
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncById(int idConfiguracao);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdHospital(int idHospital);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdEspecialidade(int idEspecialidade);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoAsyncByIdProfissional(int idProfissional);
        
    }
}