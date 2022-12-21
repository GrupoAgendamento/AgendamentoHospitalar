using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoPersist _agendamentoPersist;
        private readonly IGeralPersist _geralPersist;

        public AgendamentoService(IAgendamentoPersist agendamentoPersist, IGeralPersist geralPersist)
        {
            _agendamentoPersist = agendamentoPersist;
            _geralPersist = geralPersist;
        }
        public Task<List<Agendamento>> GetAllAgendamentosAsync()
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAllAgendamentosAsync();
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<Agendamento> GetAgendamentoAsyncById(int agendamentoId)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncById(agendamentoId);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Agendamento>> GetAgendamentoAsyncByBeneficiario(int idBeneficiario)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncByBeneficiario(idBeneficiario);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Agendamento>> GetAgendamentoAsyncByEspecialidade(int idEspecialidade)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncByEspecialidade(idEspecialidade);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<List<Agendamento>> GetAgendamentoAsyncByProfissional(int idProfissional)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncByProfissional(idProfissional);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Agendamento>> GetAgendamentoAsyncByHospital(int idHospital)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncByHospital(idHospital);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Agendamento>> GetAgendamentoAsyncByData(DateTime agendamentoData)
        {
            try
            {
                var agendamento = _agendamentoPersist.GetAgendamentoAsyncByData(agendamentoData);
                if (agendamento == null) return null;
                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agendamento> AddAgendamento(Agendamento model)
        {
            try
            {
                _geralPersist.Add<Agendamento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agendamento> UpdateAgendamento(Agendamento model, int agendamentoId)
        {
            try
            {
                var agendamento = await _agendamentoPersist.GetAgendamentoAsyncById(model.IdAgendamento);
                if (agendamento == null) return null;
                model.IdAgendamento = agendamentoId;
                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _agendamentoPersist.GetAgendamentoAsyncById(model.IdHospital);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAgendamento(int idAgendamento)
        {
            try
            {
                var agendamento = await _agendamentoPersist.GetAgendamentoAsyncById(idAgendamento);
                if (agendamento == null) throw new Exception("Agendamento não encontrado");
                _geralPersist.Delete(agendamento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
