using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        public IProfissionalService _profissionalService;

        public ProfissionalController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        [HttpGet]
        public async Task<ActionResult<Profissional>> Get()
        {
            try
            {
                var profissional = await _profissionalService.GetAllProfissional();
                if (profissional == null) return NotFound("Nenhum profissional encontrado");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar profissional. Erro: {ex}");
            }
        }

        [HttpGet("{profissionalId}")]
        public async Task<ActionResult<Profissional>> Get(int profissionalId)
        {
            try
            {
                var profissional = await _profissionalService.GetProfissionalById(profissionalId);
                if (profissional == null) return NotFound($"Profissional com id {profissionalId} não encontrado");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar profissional. Erro: {ex}");
            }
        }

        [HttpGet("endereço/{profissionalEndereço}")]
        public async Task<ActionResult<Profissional>> Get(string profissionalEndereço)
        {
            try
            {
                var profissional = await _profissionalService.GetProfissionalByEndereço(profissionalEndereço);
                if (profissional == null) return NotFound($"Profissional com endereço {profissionalEndereço} não encontrado");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("nome/{profissionalNome}")]
        public async Task<ActionResult<Profissional>> GetNome(string profissionalNome)
        {
            try
            {
                var profissional = await _profissionalService.GetProfissionalByNome(profissionalNome);
                if (profissional == null) return NotFound($"Profissional com nome {profissionalNome} não encontrado");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Profissional>> Post(Profissional model)
        {
            try
            {
                var profissional = await _profissionalService.AddProfissional(model);
                if (profissional == null) return BadRequest("Erro ao tentar adicionar Profissional");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar profissional. Erro: {ex}");
            }
        }

        [HttpPut("{profissionalId}")]
        public async Task<ActionResult<Profissional>> Put(int profissionalId, Profissional model)
        {
            try
            {
                var profissional = await _profissionalService.UpdateProfissional(model, profissionalId);
                if (profissional == null) return BadRequest("Erro ao tentar atualizar profissional");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar profissional. Erro: {ex}");
            }
        }

        [HttpDelete("{profissionalId}")]
        public async Task<ActionResult<Profissional>> Delete(int profissionalId)
        {
            try
            {
                var profissional = await _profissionalService.DeleteProfissional(profissionalId);
                if (profissional == null) return BadRequest("Erro ao tentar deletar profissional");
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar profissional. Erro: {ex}");
            }
        }
    }
}