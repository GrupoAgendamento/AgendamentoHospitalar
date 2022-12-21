using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{

    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalPersist _profissionalPersist;
        private readonly IGeralPersist _geralPersist;

        public ProfissionalService(IProfissionalPersist profissionalPersist, IGeralPersist geralPersist)
        {
            _profissionalPersist = profissionalPersist;
            _geralPersist = geralPersist;
        }
        public Task<List<Profissional>> GetAllProfissional()
        {
            try
            {
                var profissional = _profissionalPersist.GetAllProfissionalAsync();
                if (profissional == null) return null;
                return profissional;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<Profissional> GetProfissionalByEndereço(string profissionalEndereço)
        {
            try
            {
                var profissional = _profissionalPersist.GetProfissionalAsyncByEndereço(profissionalEndereço);
                if (profissional == null) return null;
                return profissional;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Profissional> GetProfissionalById(int idProfissional)
        {
            try
            {
                var profissional = _profissionalPersist.GetProfissionalAsyncById(idProfissional);
                if (profissional == null) return null;
                return profissional;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Profissional> GetProfissionalByNome(string profissionalNome)
        {
            try
            {
                var profissional = _profissionalPersist.GetProfissionalAsyncByNome(profissionalNome);
                if (profissional == null) return null;
                return profissional;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Profissional> AddProfissional(Profissional model)
        {
            try
            {
                _geralPersist.Add<Profissional>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _profissionalPersist.GetProfissionalAsyncById(model.IdProfissional);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Profissional> UpdateProfissional(Profissional model, int profissionalId)
        {
            try
            {
                var profissional = await _profissionalPersist.GetProfissionalAsyncById(model.IdProfissional);
                if (profissional == null) return null;
                model.IdProfissional = profissionalId;
                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _profissionalPersist.GetProfissionalAsyncById(model.IdProfissional);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProfissional(int idProfissional)
        {
            try
            {
                var profissional = await _profissionalPersist.GetProfissionalAsyncById(idProfissional);
                if (profissional == null) throw new Exception("Profissional não encontrado");
                _geralPersist.Delete(profissional);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}