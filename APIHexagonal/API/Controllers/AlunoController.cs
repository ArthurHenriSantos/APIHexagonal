using APIHexagonal.Application.DTOs;
using APIHexagonal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIHexagonal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateAlunoDTO dto)
        {
            _service.Matricular(dto);
            return Ok(new { message = "Aluno matriculado com sucesso" });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _service.GetList();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var aluno = _service.GetAlunoById(id);
            return Ok(aluno);
        }

        [HttpGet("nome/{firstName}")]
        public IActionResult GetByFirstName(string firstName)
        {
            var aluno = _service.GetAlunoByFirstName(firstName);
            return Ok(aluno);
        }
    }
}