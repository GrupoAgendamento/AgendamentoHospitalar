using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AgendamentoController : ControllerBase
    {
        public IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<Agendamento>> Get()
        {
            try
            {
                var agendamento = await _agendamentoService.GetAllAgendamentosAsync();
                if (agendamento == null) return NotFound("Nenhum agendamento encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("{idAgendamento}")]
        public async Task<ActionResult<Agendamento>> GetById(int agendamentoId)
        {
            try
            {
                var agendamento = await _agendamentoService.GetAgendamentoAsyncById(agendamentoId);
                if (agendamento == null) return NotFound($"Agendamento com id {agendamentoId} não encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("{idBeneficiario}")]
        public async Task<ActionResult<Agendamento>> GetByBeneficiario(int idBeneficiario)
        {
            try
            {
                var agendamento = await _agendamentoService.GetAgendamentoAsyncByBeneficiario(idBeneficiario);
                if (agendamento == null) return NotFound($"Agendamento para {idBeneficiario} não encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("{idEspecialidade}")]
        public async Task<ActionResult<Agendamento>> GetByEspecialidade(int idEspecialidade)
        {
            try
            {
                var agendamento = await _agendamentoService.GetAgendamentoAsyncByEspecialidade(idEspecialidade);
                if (agendamento == null) return NotFound($"Agendamento para especialidade {idEspecialidade} não encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("{idProfissional}")]
        public async Task<ActionResult<Agendamento>> GetByProfissional(int idProfissional)
        {
            try
            {
                var agendamento = await _agendamentoService.GetAgendamentoAsyncByProfissional(idProfissional);
                if (agendamento == null) return NotFound($"Hospital com CNPJ {idProfissional} não encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("{idHospital}")]
        public async Task<ActionResult<Agendamento>> GetByHospital(int idHospital)
        {
            try
            {
                var agendamento = await _agendamentoService.GetAgendamentoAsyncByHospital(idHospital);
                if (agendamento == null) return NotFound($"Hospital com CNPJ {idHospital} não encontrado");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        
    }
}
