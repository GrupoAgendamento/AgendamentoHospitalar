using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IAgendamentoService
    {
        Task<List<Agendamento>> GetAllAgendamentosAsync();
        Task<Agendamento> GetAgendamentoAsyncById(int agendamentoId);
        Task<List<Agendamento>> GetAgendamentoAsyncByBeneficiario(int idBeneficiario);
        Task<List<Agendamento>> GetAgendamentoAsyncByEspecialidade(int idEspecialidade);
        Task<List<Agendamento>> GetAgendamentoAsyncByProfissional(int idProfissional);
        Task<List<Agendamento>> GetAgendamentoAsyncByHospital(int idHospital);
        Task<List<Agendamento>> GetAgendamentoAsyncByData(DateTime agendamentoData);
        Task<Agendamento> AddAgendamento(Agendamento agendamento);
        Task<Agendamento> UpdateAgendamento(Agendamento model, int agendamentoId);
        Task<bool> DeleteAgendamento(int agendamentoId);
    }
}