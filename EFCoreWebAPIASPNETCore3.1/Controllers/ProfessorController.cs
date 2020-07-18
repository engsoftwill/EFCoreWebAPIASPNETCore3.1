using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController:ControllerBase
    {
        public ProfessorController()
        {            
        }
        public List<Professor> Alunos =    new List<Professor>()
        {
            new Professor(){
                ProfessorId = 1,
                Nome = "Marcos",
            },
            new Professor(){
                ProfessorId = 2,
                Nome = "Julia",
            },
            new Professor(){
                ProfessorId = 1,
                Nome = "Fernando",
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Marta, Paulo, Lucas, Rafa");
            
        }
        
    }
}