using Microsoft.AspNetCore.Mvc;
using ProjetoAgendamentoHospitalar.Models;
using ProjetoAgendamentoHospitalar.Service;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        public IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<ActionResult<Hospital>> Get()
        {
            try
            {
                var hospitais = await _hospitalService.GetAllHospitais();
                if (hospitais == null) return NotFound("Nenhum hospital encontrado");
                return Ok(hospitais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<Hospital>> Get(int hospitalId)
        {
            try
            {
                var hospital = await _hospitalService.GetHospitalById(hospitalId);
                if (hospital == null) return NotFound($"Hospital com id {hospitalId} não encontrado");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar hospital. Erro: {ex}");
            }
        }

        [HttpGet("cpf/{hospitalCnpj}")]
        public async Task<ActionResult<Hospital>> Get(string hospitalCnpj)
        {
            try
            {
                var hospital = await _hospitalService.GetHospitalByCnpj(hospitalCnpj);
                if (hospital == null) return NotFound($"Hospital com CNPJ {hospitalCnpj} não encontrado");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpGet("nome/{hospitalNome}")]
        public async Task<ActionResult<Hospital>> GetNome(string hospitalNome)
        {
            try
            {
                var hospital = await _hospitalService.GetHospitalByNome(hospitalNome);
                if (hospital == null) return NotFound($"Hospital com nome {hospitalNome} não encontrado");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Hospital>> Post(Hospital model)
        {
            try
            {
                var hospital = await _hospitalService.AddHospital(model);
                if (hospital == null) return BadRequest("Erro ao tentar adicionar hospital");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar hospital. Erro: {ex}");
            }
        }

        [HttpPut("{hospitalId}")]
        public async Task<ActionResult<Hospital>> Put(int hospitalId, Hospital model)
        {
            try
            {
                var hospital = await _hospitalService.UpdateHospital(model, hospitalId);
                if (hospital == null) return BadRequest("Erro ao tentar atualizar hospital");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar hospital. Erro: {ex}");
            }
        }

        [HttpDelete("{hospitalId}")]
        public async Task<ActionResult<Hospital>> Delete(int hospitalId)
        {
            try
            {
                var hospital = await _hospitalService.DeleteHospital(hospitalId);
                if (hospital == null) return BadRequest("Erro ao tentar deletar hospital");
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar hospital. Erro: {ex}");
            }
        }
    }
}