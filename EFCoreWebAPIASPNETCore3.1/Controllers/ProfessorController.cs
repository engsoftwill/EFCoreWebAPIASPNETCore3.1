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
        
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Getprofessor()
        {
            return Ok(_repo.GetAllProfessores());

        }

        // api/professor/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var professor = _repo.GetProfessorbyId(id);
            if (professor != null)
                return Ok(professor);
            return NotFound("Aluno Not Found");

        }
        // http://localhost:5000/api/professor/byName?nome=Fernando&sobrenome=Pessoa
        /*[HttpGet("ByName")]
        public IActionResult GetbyName(string nome)
        {
            var professor = _repo.GetProfessorbyId(id)
            if (professor != null)
                return Ok(professor);
            return NotFound("professor Not Found");

        }
        */

        [HttpPost]
        public IActionResult Post(Professor model)
        {
            _repo.Add(model);
            if(_repo.SaveChanges())
                return Ok(model);
            return BadRequest("Professor not added");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno model)
        {
            var aluno = _repo.GetProfessorbyId(id);
            if (aluno != null)
            {
                _repo.Update(model);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllProfessores());
            }
            return BadRequest("id not found");
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, Professor model)
        {
            var aluno = _repo.GetProfessorbyId(id);
            if (aluno != null)
            {
                _repo.Update(model);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllProfessores());
            }
            return BadRequest("id not found");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetProfessorbyId(id);
            if (aluno != null)
            {
                _repo.Delete(aluno);
                if(_repo.SaveChanges())
                    return Ok(_repo.GetAllProfessores());
            }
            return BadRequest("id not found");
        }


    }
}