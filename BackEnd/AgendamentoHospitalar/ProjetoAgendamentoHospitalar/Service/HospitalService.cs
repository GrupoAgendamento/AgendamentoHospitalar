using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalPersist _hospitalPersist;
        private readonly IGeralPersist _geralPersist;

        public HospitalService(IHospitalPersist hospitalPersist, IGeralPersist geralPersist)
        {
            _hospitalPersist = hospitalPersist;
            _geralPersist = geralPersist;
        }
        public Task<List<Hospital>> GetAllHospitais()
        {
            try
            {
                var hospital = _hospitalPersist.GetAllHospitaisAsync();
                if (hospital == null) return null;
                return hospital;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<Hospital> GetHospitalByCnpj(string hospitalCnpj)
        {
            try
            {
                var hospital = _hospitalPersist.GetHospitalAsyncByCnpj(hospitalCnpj);
                if (hospital == null) return null;
                return hospital;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Hospital> GetHospitalById(int idHospital)
        {
            try
            {
                var hospital = _hospitalPersist.GetHospitalAsyncById(idHospital);
                if (hospital == null) return null;
                return hospital;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Hospital> GetHospitalByNome(string hospitalNome)
        {
            try
            {
                var hospital = _hospitalPersist.GetHospitalAsyncByNome(hospitalNome);
                if (hospital == null) return null;
                return hospital;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Hospital> AddHospital(Hospital model)
        {
            try
            {
                _geralPersist.Add<Hospital>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _hospitalPersist.GetHospitalAsyncById(model.IdHospital);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital> UpdateHospital(Hospital model, int hospitalId)
        {
            try
            {
                var hospital = await _hospitalPersist.GetHospitalAsyncById(model.IdHospital);
                if (hospital == null) return null;
                model.IdHospital = hospitalId;
                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _hospitalPersist.GetHospitalAsyncById(model.IdHospital);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteHospital(int idHospital)
        {
            try
            {
                var hospital = await _hospitalPersist.GetHospitalAsyncById(idHospital);
                if (hospital == null) throw new Exception("Hospital não encontrado");
                _geralPersist.Delete(hospital);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}