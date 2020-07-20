using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            var alunosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);
            return Ok(alunosDto);

        }

        // api/aluno/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno == null)
                return NotFound("aluno not Found");
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);

        }
        // http://localhost:5000/api/aluno/byName?nome=Fernando&sobrenome=Pessoa
        /*[HttpGet("ByName")]
        public IActionResult GetbyName(string nome, string Sobrenome)
        {
            var aluno =  _context.Alunos.FirstOrDefault(x =>
            x.Nome.Contains(nome) && x.Sobrenome.Contains(Sobrenome));
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");

        }
        */

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repo.Add(aluno);
            if (!_repo.SaveChanges())
                return BadRequest("aluno not Created");
            return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno == null) return NotFound("id not found");
            _mapper.Map(model, aluno);
                _repo.Update(aluno);
            if (!_repo.SaveChanges())
                return BadRequest("aluno not updated");
            var alunos = _repo.GetAllAlunos(true);
            var alunosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);
            return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno == null) return NotFound("id not found");
            _mapper.Map(model, aluno);
                _repo.Update(aluno);
            if (!_repo.SaveChanges())
                return BadRequest("aluno not patched");
            var alunos = _repo.GetAllAlunos(true);
            var alunosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);
            return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno == null) return NotFound("id not found");
                _repo.Delete(aluno);
            if (!_repo.SaveChanges())
                return BadRequest("aluno not Deleted");
            return Ok("aluno deleted");

        }
    }
}