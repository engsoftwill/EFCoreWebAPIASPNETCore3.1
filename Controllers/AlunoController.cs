using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController:ControllerBase
    {
        public AlunoController()
        {            
        }
        public List<Aluno> Alunos =    new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Ferreira",
                Telefone = "08000800"
            },
            new Aluno(){
                Id = 2,
                Nome = "Julia",
                Sobrenome = "Rocha",
                Telefone = "08007777"
            },
            new Aluno(){
                Id = 3,
                Nome = "Fernando",
                Sobrenome = "Pessoa",
                Telefone = "9999999"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");
            
        }
        
    }
}