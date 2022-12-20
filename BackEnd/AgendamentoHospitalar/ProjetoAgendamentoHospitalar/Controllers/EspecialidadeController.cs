using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAgendamentoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        [HttpGet]
        [Route("/ConsultarEspecialidades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Especialidade))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Models.Especialidade ConsultarEspecialidades()
        {
            return new Models.Especialidade();
        }

        [HttpGet]
        [Route("/ConsultarPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Especialidade))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Models.Especialidade ListarPorId(int id)
        {
            return new Models.Especialidade();
        }

        [HttpPost]
        [Route("/CadastrarEspecialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int CadastrarEspecialidade(Models.Especialidade model)
        {
            return 0;
        }

        [HttpDelete]
        [Route("/Deletar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int DeletarEspecialidade(Models.Especialidade model)
        {
            return 0;
        }
        [HttpPatch]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int AtualizarEspecialiade(Models.Especialidade model)
        {
            return 0;
        }
    }
}