using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        bool SaveChanges();
        Aluno[] GetAllAlunos(bool includeprofessor = false);
        Aluno[] GetAlunosbyDisciplina(int disciplinaId, bool includeprofessor = false);
        Aluno GetAlunobyId(int alunoId, bool includeprofessor = false);
        Professor[] GetAllProfessores(bool includealuno = false);
        Professor[] GetProfessoresbyDisciplina(int disciplinaId, bool includealuno = false);
        Professor GetProfessorbyId(int professorId, bool includealuno = false );

         
    }
}