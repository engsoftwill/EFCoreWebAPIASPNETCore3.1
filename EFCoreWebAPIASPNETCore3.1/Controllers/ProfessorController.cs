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
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Getprofessor()
        {
            return Ok(_context.Professores);

        }

        // api/professor/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.ProfessorId == id);
            if (professor != null)
                return Ok(professor);
            return NotFound("Aluno Not Found");

        }
        // http://localhost:5000/api/professor/byName?nome=Fernando&sobrenome=Pessoa
        [HttpGet("ByName")]
        public IActionResult GetbyName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(x =>
            x.Nome.Contains(nome));
            if (professor != null)
                return Ok(professor);
            return NotFound("professor Not Found");

        }

        [HttpPost]
        public IActionResult Post(Professor model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno model)
        {
            var aluno = _context.Professores.AsNoTracking().FirstOrDefault(a => a.ProfessorId == id);
            if (aluno != null)
            {
                _context.Update(model);
                _context.SaveChanges();
                return Ok(_context.Professores);
            }
            return BadRequest("id not found");
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, Professor model)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.ProfessorId == id);
            if (professor != null)
            {
                _context.Update(model);
                _context.SaveChanges();
                return Ok(_context.Professores);
            }
            return BadRequest("id not found");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.ProfessorId == id);
            if (professor != null)
            {
                _context.Remove(professor);
                _context.SaveChanges();
                return Ok(_context.Professores);
            }
            return BadRequest("id not found");
        }


    }
}