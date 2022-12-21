using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoConfiguracaoController : ControllerBase
    {
        public IAgendamentoConfiguracaoService _agendamentoConfiguracaoService;

        public AgendamentoConfiguracaoController(IAgendamentoConfiguracaoService agendamentoConfiguracaoService)
        {
            _agendamentoConfiguracaoService = agendamentoConfiguracaoService;
        }

        [HttpGet]
        public async Task<ActionResult<AgendamentoConfiguracao>> Get()
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoService.GetAllAgendamentoConfiguracoes();
                if(agendamentoConfiguracao == null) return NotFound("Nenhuma configuração de agendamento encontrada");
                return Ok(agendamentoConfiguracao);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar configuração de agendamento. Erro: {ex}");
            }
        }

        [HttpGet("{agendaConfiguracaoId}")]
        public async Task<ActionResult<AgendamentoConfiguracao>> GetById(int idConfiguracao)
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoService.GetAgendamentoConfiguracaoById(idConfiguracao);
                if(agendamentoConfiguracao == null) return NotFound($"Nenhuma configuração de agendamento encontrada para o id {idConfiguracao}");
                return Ok(agendamentoConfiguracao);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar configuração de agendamento. Erro: {ex}");
            }
        }

        [HttpGet("idHospital/{idHospital}")]
        public async Task<ActionResult<AgendamentoConfiguracao>> GetByHospital(int idHospital)
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoService.GetAgendamentoConfiguracaoByIdHospital(idHospital);
                if(agendamentoConfiguracao == null) return NotFound($"Nenhuma configuração de agendamento encontrada para o id {idHospital}");
                return Ok(agendamentoConfiguracao);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar configuração de agendamento. Erro: {ex}");
            }
        }

        [HttpGet("idEspecialidade/{idEspecialidade}")]
        public async Task<ActionResult<AgendamentoConfiguracao>> GetByEspecialidade(int idEspecialidade)
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoService.GetAgendamentoConfiguracaoByIdEspecialidade(idEspecialidade);
                if(agendamentoConfiguracao == null) return NotFound($"Nenhuma configuração de agendamento encontrada para o id {idEspecialidade}");
                return Ok(agendamentoConfiguracao);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar configuração de agendamento. Erro: {ex}");
            }
        }

        [HttpGet("idProfissional/{idProfissional}")]
        public async Task<ActionResult<AgendamentoConfiguracao>> GetByMedico(int idProfissional)
        {
            try
            {
                var agendamentoConfiguracao = await _agendamentoConfiguracaoService.GetAgendamentoConfiguracaoByIdProfissional(idProfissional);
                if(agendamentoConfiguracao == null) return NotFound($"Nenhuma configuração de agendamento encontrada para o id {idProfissional}");
                return Ok(agendamentoConfiguracao);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar configuração de agendamento. Erro: {ex}");
            }
        }
       
    }
}