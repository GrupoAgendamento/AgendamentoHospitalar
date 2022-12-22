using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IBeneficiarioService
    {
        Task<Beneficiario> AddBeneficiario(Beneficiario model);
        Task<Beneficiario> UpdateBeneficiario(Beneficiario model, int idBeneficiario);
        Task<bool> DeleteBeneficiario(int idBeneficiario);
        Task<Beneficiario> GetBeneficiarioById(int idBeneficiario);
        Task<List<Beneficiario>> GetAllBeneficiarios();
        Task<Beneficiario> GetBeneficiarioByCpf(string beneficiarioCpf);
        Task<Beneficiario> GetBeneficiarioByNome(string beneficiarioNome);
    }
}