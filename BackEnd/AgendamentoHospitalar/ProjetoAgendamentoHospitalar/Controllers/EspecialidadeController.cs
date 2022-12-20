using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        public IEspecialidadeService _especialidadeService;
        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<Especialidade>> Get()
        {
            try
            {
                var especialidades = await _especialidadeService.GetAllEspecialidades();
                if (especialidades == null) return NotFound("Nenhuma especialidade encontrada");
                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar especialidade. Erro: {ex}");
            }
        }

        [HttpGet("{especialidadeId}")]
        public async Task<ActionResult<Especialidade>> Get(int especialidadeId)
        {
            try
            {
                var especialidade = await _especialidadeService.GetEspecialidadeById(especialidadeId);
                if (especialidade == null) return NotFound($"Especialidade com id {especialidadeId} não encontrada");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar especialidade. Erro: {ex}");
            }
        }

        [HttpGet("nome/{especialidadeNome}")]
        public async Task<ActionResult<Especialidade>> GetNome(string especialidadeNome)
        {
            try
            {
                var especialidade = await _especialidadeService.GetEspecialidadeByNome(especialidadeNome);
                if (especialidade == null) return NotFound($"Especialidade  {especialidadeNome} não encontrada");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Nome. Erro: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Especialidade>> Post(Especialidade model)
        {
            try
            {
                var especialidade = await _especialidadeService.AddEspecialidade(model);
                if (especialidade == null) return BadRequest("Erro ao adicionar especialidade");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar especialidade. Erro: {ex}");
            }
        }

        [HttpPut("{especialidade}")]
        public async Task<ActionResult<Especialidade>> Put(int especialidadeId, Especialidade model)
        {
            try
            {
                var especialidade = await _especialidadeService.UpdateEspecialidade(model, especialidadeId);
                if (especialidade == null) return BadRequest("Erro ao atualizar especialidade");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar especialidade. Erro: {ex}");
            }
        }

        [HttpDelete("{especialidadeId}")]
        public async Task<ActionResult<Especialidade>> Delete(int especialidadeId)
        {
            try
            {
                var especialidade = await _especialidadeService.DeleteEspecialidade(especialidadeId);
                if (especialidade == null) return BadRequest("Erro ao  deletar especialidade");
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao deletar especialidade. Erro: {ex}");
            }
        }
    }
}
