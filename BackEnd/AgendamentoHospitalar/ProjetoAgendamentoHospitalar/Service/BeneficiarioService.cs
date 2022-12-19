using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioPersist _beneficiarioPersist;
        private readonly IGeralPersist _geralPersist;

        public BeneficiarioService(IBeneficiarioPersist beneficiarioPersist, IGeralPersist geralPersist)
        {
            _beneficiarioPersist = beneficiarioPersist;
            _geralPersist = geralPersist;
        }
        public Task<List<Beneficiario>> GetAllBeneficiarios()
        {
            try
            {
                var beneficiario =_beneficiarioPersist.GetAllBeneficiariosAsync();
                if (beneficiario == null) return null;
                return beneficiario;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<Beneficiario> GetBeneficiarioByCpf(string beneficiarioCpf)
        {
            try
            {
                var beneficiario =_beneficiarioPersist.GetBeneficiarioAsyncByCpf(beneficiarioCpf);
                if(beneficiario == null) return null;
                return beneficiario;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Beneficiario> GetBeneficiarioById(int idBeneficiario)
        {
            try
            {
                var beneficiario = _beneficiarioPersist.GetBeneficiarioAsyncById(idBeneficiario);
                if(beneficiario == null) return null;
                return beneficiario;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Beneficiario> GetBeneficiarioByNome(string beneficiarioNome)
        {
            try
            {
                var beneficiario = _beneficiarioPersist.GetBeneficiarioAsyncByNome(beneficiarioNome);
                if(beneficiario == null) return null;
                return beneficiario;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Beneficiario> AddBeneficiario(Beneficiario model)
        {
            try
            {
                _geralPersist.Add<Beneficiario>(model);
                if( await _geralPersist.SaveChangesAsync())
                {
                    return await _beneficiarioPersist.GetBeneficiarioAsyncById(model.IdBeneficiario);
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Beneficiario> UpdateBeneficiario(Beneficiario model, int beneficarioId)
        {
            try
            {
                var beneficiario = await _beneficiarioPersist.GetBeneficiarioAsyncById(model.IdBeneficiario);
                if(beneficiario == null) return null;
                model.IdBeneficiario = beneficarioId;
                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _beneficiarioPersist.GetBeneficiarioAsyncById(model.IdBeneficiario);
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteBeneficiario(int idBeneficiario)
        {
            try
            {
                var beneficario = await _beneficiarioPersist.GetBeneficiarioAsyncById(idBeneficiario);
                if(beneficario == null) throw new Exception("Beneficiario não encontrado");
                _geralPersist.Delete(beneficario);
                return await _geralPersist.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}