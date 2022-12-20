using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IAgendamentoPersist
    {
        Task<List<Agendamento>> GetAllAgendamentosAsync();
        Task<Agendamento> GetAgendamentoAsyncById(int agendamentoId);
        Task<List<Agendamento>> GetAgendamentoAsyncByBeneficiario(int idBeneficiario);
        Task<List<Agendamento>> GetAgendamentoAsyncByEspecialidade(int idEspecialidade);
        Task<List<Agendamento>> GetAgendamentoAsyncByProfissional(int idProfissional);
        Task<List<Agendamento>> GetAgendamentoAsyncByHospital(int idHospital);
        Task<List<Agendamento>> GetAgendamentoAsyncByData(DateTime agendamentoData);
    }
}
