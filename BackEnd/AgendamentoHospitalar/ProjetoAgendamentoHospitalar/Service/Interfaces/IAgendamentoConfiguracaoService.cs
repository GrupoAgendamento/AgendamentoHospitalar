using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IAgendamentoConfiguracaoService
    {
        Task<AgendamentoConfiguracao> AddAgendamentoConfiguracao(AgendamentoConfiguracao model);
        Task<AgendamentoConfiguracao> UpdateAgendamentoConfiguracao(AgendamentoConfiguracao model, int idConfiguracao);
        Task<bool> DeleteAgendamentoConfiguracao(int idConfiguracao);
        Task<List<AgendamentoConfiguracao>> GetAllAgendamentoConfiguracoes();
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoById(int idConfiguracao);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdEspecialidade(int idEspecialidade);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdHospital(int idHospital);
        Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdProfissional(int idProfissional);
    }
}