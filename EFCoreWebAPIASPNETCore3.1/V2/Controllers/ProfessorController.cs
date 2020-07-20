using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V2.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IRepository _repo;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Getprofessor()
        {
            var professores = _repo.GetAllProfessores();
            var professoresdto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            return Ok(professoresdto);

        }

        // api/professor/id
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var professor = _repo.GetProfessorbyId(id);
            if (professor == null) return NotFound("Aluno Not Found");
            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repo.Add(professor);
            if (_repo.SaveChanges())
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            return BadRequest("Professor not added");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorbyId(id);
            if (professor != null) return BadRequest("id not found");
            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            return BadRequest("professor not update");
        }

        [HttpPatch("{id:int}")] //atualizar parcialmente o registro
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorbyId(id);
            if (professor != null) return BadRequest("id not found");
            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            return BadRequest("professor not update");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorbyId(id);
            if (professor != null)
            {
                _repo.Delete(professor);
                if (_repo.SaveChanges())
                    return Ok("professor deleted");
            }
            return BadRequest("id not found");
        }
    }
}