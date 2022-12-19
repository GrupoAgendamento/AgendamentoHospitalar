using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiarioController : ControllerBase
    {
        public IBeneficiarioService _beneficiarioService;

        public BeneficiarioController(IBeneficiarioService beneficiarioService)
        {
            _beneficiarioService = beneficiarioService;
        }

        [HttpGet]
        public async Task<ActionResult<Beneficiario>> Get()
        {
            try
            {
                var beneficiarios = await _beneficiarioService.GetAllBeneficiarios();
                if(beneficiarios == null) return NotFound("Nenhum beneficiário encontrado");
                return Ok(beneficiarios);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar beneficiario. Erro: {ex}");
            }
        }

        [HttpGet("{beneficiarioId}")]
        public async Task<ActionResult<Beneficiario>> Get(int beneficiarioId)
        {
            try
            {
                var beneficiario = await _beneficiarioService.GetBeneficiarioById(beneficiarioId);
                if(beneficiario == null) return NotFound($"Beneficiário com id {beneficiarioId} não encontrado");
                return Ok(beneficiario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar beneficiario. Erro: {ex}");
            }
        }

        [HttpGet("cpf/{beneficiarioCpf}")]
        public async Task<ActionResult<Beneficiario>> Get(string beneficiarioCpf)
        {
            try
            {
                var beneficiario = await _beneficiarioService.GetBeneficiarioByCpf(beneficiarioCpf);
                if(beneficiario == null) return NotFound($"Beneficiário com CPF {beneficiarioCpf} não encontrado");
                return Ok(beneficiario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("nome/{beneficiarioNome}")]
        public async Task<ActionResult<Beneficiario>> GetNome(string beneficiarioNome)
        {
            try
            {
                var beneficiario = await _beneficiarioService.GetBeneficiarioByNome(beneficiarioNome);
                if(beneficiario == null) return NotFound($"Beneficiário com nome {beneficiarioNome} não encontrado");
                return Ok(beneficiario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Beneficiario>> Post(Beneficiario model)
        {
            try
            {
                var beneficario = await _beneficiarioService.AddBeneficiario(model);
                if(beneficario == null) return BadRequest("Erro ao tentar adicionar beneficiário");
                return Ok(beneficario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar beneficiário. Erro: {ex}");
            }
        }

        [HttpPut("{beneficiarioId}")]
        public async Task<ActionResult<Beneficiario>> Put(int beneficiarioId, Beneficiario model)
        {
            try
            {
                var beneficiario = await _beneficiarioService.UpdateBeneficiario(model, beneficiarioId);
                if(beneficiario == null) return BadRequest("Erro ao tentar atualizar beneficiário");
                return Ok(beneficiario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar beneficiário. Erro: {ex}");
            }
        }

        [HttpDelete("{beneficiarioId}")]
        public async Task<ActionResult<Beneficiario>> Delete(int beneficiarioId)
        {
            try
            {
                var beneficiario = await _beneficiarioService.DeleteBeneficiario(beneficiarioId);
                if(beneficiario == null) return BadRequest("Erro ao tentar deletar beneficiário");
                return Ok(beneficiario);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar beneficiário. Erro: {ex}");
            }
        }
    }
}