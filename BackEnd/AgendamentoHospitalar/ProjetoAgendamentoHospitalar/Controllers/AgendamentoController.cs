using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service;
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
        //consultar
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("api/agendamento/{idAgendamento}")]
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("api/agendamento/beneficiario/{idBeneficiario}")]
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("api/agendamento/especialidade/{idEspecialidade}")]
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("api/agendamento/profissional/{idProfissional}")]
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("api/agendamento/hospital/{idHospital}")]
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
                return this.StatusCode(StatusCodes.Status404NotFound,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }
        //agendar
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Agendamento model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _agendamentoService.AddAgendamento(model);
                    if (postId != null)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
        //atualizar
        [HttpPut("{agendamentoId}")]
        public async Task<ActionResult<Agendamento>> Put(int agendamentoId, Agendamento model)
        {
            try
            {
                var agendamento = await _agendamentoService.UpdateAgendamento(model, agendamentoId);
                if (agendamento == null) return BadRequest("Erro ao tentar atualizar agendamento");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar agendamento. Erro: {ex}");
            }
        }

        //deletar
        [HttpDelete("{agendamentoId}")]
        public async Task<ActionResult<Agendamento>> Delete(int agendamentoId)
        {
            try
            {
                var agendamento = await _agendamentoService.DeleteAgendamento(agendamentoId);
                if (agendamento == null) return BadRequest("Erro ao tentar deletar hospital");
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar hospital. Erro: {ex}");
            }
        }
    }
}
