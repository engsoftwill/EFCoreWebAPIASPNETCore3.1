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
        private readonly SmartContext _context;
        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);

        }

        // api/aluno/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");

        }
        // http://localhost:5000/api/aluno/byName?nome=Fernando&sobrenome=Pessoa
        [HttpGet("ByName")]
        public IActionResult GetbyName(string nome, string Sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(x =>
            x.Nome.Contains(nome) && x.Sobrenome.Contains(Sobrenome));
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");

        }

        [HttpPost]
        public IActionResult Post(Aluno model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno model)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                _context.Update(model);
                _context.SaveChanges();
                return Ok(_context.Alunos);
            }
            return BadRequest("id not found");
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, Aluno model)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                _context.Update(model);
                _context.SaveChanges();
                return Ok(_context.Alunos);
            }
            return BadRequest("id not found");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                _context.Remove(aluno);
                _context.SaveChanges();
                return Ok(_context.Alunos);
            }
            return BadRequest("id not found");
        }


    }
}