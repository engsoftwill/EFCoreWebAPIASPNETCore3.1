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
        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
            
        }

        // api/aluno/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");
            
        }
        // http://localhost:5000/api/aluno/byName?nome=Fernando&sobrenome=Pessoa
        [HttpGet("ByName")] 
        public IActionResult GetbyName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(x => 
            x.Nome.Contains(nome) && x.Sobrenome.Contains(Sobrenome));
            if (aluno != null)
                return Ok(aluno);
            return NotFound("Aluno Not Found");
            
        }
        
    }
}