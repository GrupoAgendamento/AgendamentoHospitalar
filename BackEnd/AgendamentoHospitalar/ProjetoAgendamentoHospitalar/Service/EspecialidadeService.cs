using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadePersist _especialidadePersist;
        private readonly IGeralPersist _geralPersist;

        public EspecialidadeService(IEspecialidadePersist especialidadePersist, IGeralPersist geralPersist)
        {
            _especialidadePersist = especialidadePersist;
            _geralPersist = geralPersist;
        }
        public Task<List<Especialidade>> GetAllEspecialidades()
        {
            try
            {
                var especialidade = _especialidadePersist.GetAllEspecialidadesAsync();
                if (especialidade == null) return null;
                return especialidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
        public Task<Especialidade> GetEspecialidadeById(int idEspecialidade)
        {
            try
            {
                var especialidade = _especialidadePersist.GetEspecialidadeAsyncById(idEspecialidade);
                if (especialidade == null) return null;
                return especialidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Especialidade> GetEspecialidadeByNome(string especialidadeNome)
        {
            try
            {
                var especialidade = _especialidadePersist.GetEspecialidadeAsyncByNome(especialidadeNome);
                if (especialidade == null) return null;
                return especialidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Especialidade> AddEspecialidade(Especialidade model)
        {
            try
            {
                _geralPersist.Add<Especialidade>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _especialidadePersist.GetEspecialidadeAsyncById(model.IdEspecialidade);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Especialidade> UpdateEspecialidade(Especialidade model, int especialidadeId)
        {
            try
            {
                var especialidade = await _especialidadePersist.GetEspecialidadeAsyncById(model.IdEspecialidade);
                if (especialidade == null) return null;
                model.IdEspecialidade = especialidadeId;
                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _especialidadePersist.GetEspecialidadeAsyncById(model.IdEspecialidade);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEspecialidade(int idEspecialidade)
        {
            try
            {
                var especialidade = await _especialidadePersist.GetEspecialidadeAsyncById(idEspecialidade);
                if (especialidade == null) throw new Exception("Especialidade não encontrada");
                _geralPersist.Delete(especialidade);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    

