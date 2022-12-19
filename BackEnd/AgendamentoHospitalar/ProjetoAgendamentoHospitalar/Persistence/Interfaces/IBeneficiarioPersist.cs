using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IBeneficiarioPersist
    {
        Task<List<Beneficiario>> GetAllBeneficiariosAsync();
        Task<Beneficiario> GetBeneficiarioAsyncById(int beneficiarioId);
        Task<Beneficiario> GetBeneficiarioAsyncByCpf(string beneficiarioCpf);
        Task<Beneficiario> GetBeneficiarioAsyncByNome(string beneficiarioNome);
    }
}