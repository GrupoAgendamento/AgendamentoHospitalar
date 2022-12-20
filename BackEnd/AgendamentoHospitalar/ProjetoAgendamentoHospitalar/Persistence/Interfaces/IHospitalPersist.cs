using ProjetoAgendamentoHospitalar.Models;

namespace ProjetoAgendamentoHospitalar.Persistence.Interfaces
{
    public interface IHospitalPersist
    {
        Task<List<Hospital>> GetAllHospitaisAsync();
        Task<Hospital> GetHospitalAsyncById(int hospitalId);
        Task<Hospital> GetHospitalAsyncByCnpj(string hospitalCnpj);
        Task<Hospital> GetHospitalAsyncByNome(string hospitalNome);
    }
}