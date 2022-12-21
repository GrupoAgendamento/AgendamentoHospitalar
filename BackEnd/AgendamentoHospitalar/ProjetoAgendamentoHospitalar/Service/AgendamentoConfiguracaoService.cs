using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Service
{
    public class AgendamentoConfiguracaoService : IAgendamentoConfiguracaoService
    {
        private readonly IAgendamentoConfiguracaoPersist _agendamentoConfiguracaoPersist;
        private readonly IGeralPersist _geralPersist;

        public AgendamentoConfiguracaoService(IAgendamentoConfiguracaoPersist agendamentoConfiguracaoPersist, IGeralPersist geralPersist)
        {
            _agendamentoConfiguracaoPersist = agendamentoConfiguracaoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<AgendamentoConfiguracao> AddAgendamentoConfiguracao(AgendamentoConfiguracao model)
        {
            try
            {
                _geralPersist.Add<AgendamentoConfiguracao>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncById(model.IdConfiguracao);
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAgendamentoConfiguracao(int idConfiguracao)
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncById(idConfiguracao);
                if(agendamentoConfiguracao == null) throw new Exception("Agendamento Configuração não encontrado");
                _geralPersist.Delete<AgendamentoConfiguracao>(agendamentoConfiguracao);
                return await _geralPersist.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<AgendamentoConfiguracao> UpdateAgendamentoConfiguracao(AgendamentoConfiguracao model, int idConfiguracao)
        {
            try
            {
                var agendamentoConfiguracao = _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncById(idConfiguracao);
                if(agendamentoConfiguracao == null) return null;
                model.IdConfiguracao = idConfiguracao;
                _geralPersist.Update<AgendamentoConfiguracao>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncById(idConfiguracao);
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<List<AgendamentoConfiguracao>> GetAllAgendamentoConfiguracoes()
        {
            try
            {
                var agendamentoConfiguracoes = await _agendamentoConfiguracaoPersist.GetAllAgendamentoConfiguracaosAsync();
                if(agendamentoConfiguracoes == null) return null;
                return agendamentoConfiguracoes.ToList();
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoById(int idConfiguracao)
        {
            try
            {
                var agendamentoConfiguracao = _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncById(idConfiguracao);
                if(agendamentoConfiguracao == null) return null;
                return agendamentoConfiguracao;
            }catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdEspecialidade(int idEspecialidade)
        {
            try
            {
                var agendamentoConfiguracao = _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncByIdEspecialidade(idEspecialidade);
                if(agendamentoConfiguracao == null) return null;
                return agendamentoConfiguracao;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdHospital(int idHospital)
        {
            try
            {
                var agendamentoConfiguracao = _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncByIdHospital(idHospital);
                if(agendamentoConfiguracao == null) return null;
                return agendamentoConfiguracao;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public Task<AgendamentoConfiguracao> GetAgendamentoConfiguracaoByIdProfissional(int idProfissional)
        {
            try
            {
                var agendamentoConfiguracao = _agendamentoConfiguracaoPersist.GetAgendamentoConfiguracaoAsyncByIdProfissional(idProfissional);
                if(agendamentoConfiguracao == null) return null;
                return agendamentoConfiguracao;
            }catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}