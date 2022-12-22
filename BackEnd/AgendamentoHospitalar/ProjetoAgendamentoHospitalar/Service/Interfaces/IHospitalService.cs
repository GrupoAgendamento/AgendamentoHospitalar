using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Service.Interfaces
{
    public interface IHospitalService
    {
        Task<Hospital> AddHospital(Hospital model);
        Task<Hospital> UpdateHospital(Hospital model, int IdHospital);
        Task<bool> DeleteHospital(int IdHospital);
        Task<Hospital> GetHospitalById(int IdHospital);
        Task<List<Hospital>> GetAllHospitais();
        Task<Hospital> GetHospitalByCnpj(string hospitalCnpj);
        Task<Hospital> GetHospitalByNome(string hospitalNome);
    }
}