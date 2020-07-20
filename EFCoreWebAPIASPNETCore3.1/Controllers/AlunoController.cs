using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));

        }

        // api/aluno/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");

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
        public IActionResult Post(Aluno model)
        {
            _repo.Add(model);
            if(_repo.SaveChanges())
                return Ok(model);
            return BadRequest("aluno not added");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno model)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno != null)
            {
                _repo.Update(model);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllAlunos(true));
                return BadRequest("aluno not implemented");
            }
            return NotFound("id not found");
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, Aluno model)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno != null)
            {
                _repo.Update(model);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllAlunos(true));
                return BadRequest("aluno not implemented");
            }
            return BadRequest("id not found");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunobyId(id);
            if (aluno != null)
            {
                _repo.Delete(aluno);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllAlunos(true));
                return BadRequest("aluno not deleted");
            }
            return BadRequest("id not found");
        }
    }
}