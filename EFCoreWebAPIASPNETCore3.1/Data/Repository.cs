using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        
        public Repository(SmartContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        
        public bool SaveChanges()
        {
            return  (_context.SaveChanges()>0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public Aluno[] GetAllAlunos(bool includeprofessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeprofessor)
                query = query.Include(a=> a.AlunosDisciplinas)
                            .ThenInclude(d=>d.Disciplina)
                            .ThenInclude(p=>p.Professor);

            query = query.AsNoTracking().OrderBy(a=>a.Id);
                
            return query.ToArray();
        }

        

        public Aluno GetAlunobyId(int alunoId, bool includeprofessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeprofessor)
                query = query.Include(a=> a.AlunosDisciplinas)
                            .ThenInclude(d=>d.Disciplina)
                            .ThenInclude(p=>p.Professor);

            query = query.AsNoTracking().OrderBy(a=>a.Id).Where(x=>x.Id==alunoId);
                
            return query.FirstOrDefault();
        }

        public Aluno[] GetAlunosbyDisciplina(int disciplinaId, bool includeprofessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeprofessor)
                query = query.Include(a=> a.AlunosDisciplinas)
                            .ThenInclude(d=>d.Disciplina)
                            .ThenInclude(p=>p.Professor);

            query = query.AsNoTracking().OrderBy(a=>a.Id)//a esta na tabela alunos
            .Where(x=>x.AlunosDisciplinas //seleciona a tabela intermediaria alunosdisciplinas
            .Any(ad=>ad.DisciplinaId==disciplinaId));//procura dentro de
                
            return query.ToArray();
        }

        public Professor[] GetAllProfessores(bool includealuno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includealuno)
                query = query.Include(a=> a.Disciplinas)
                            .ThenInclude(d=>d.AlunosDisciplinas)
                            .ThenInclude(ad=>ad.Aluno); //

            query = query.AsNoTracking().OrderBy(p=>p.Id); //poderia ordenar por nome
            return query.ToArray();
        }
        public Professor GetProfessorbyId(int professorId, bool includealuno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includealuno)
                query = query.Include(a=> a.Disciplinas)
                            .ThenInclude(d=>d.AlunosDisciplinas)
                            .ThenInclude(ad=>ad.Aluno); 

            query = query.AsNoTracking()
            .OrderBy(p=>p.Id)
            .Where(p => p.Id==professorId);
            
            return query.FirstOrDefault();
        }

        public Professor[] GetProfessoresbyDisciplina(int disciplinaId, bool includealuno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includealuno)
                query = query.Include(a=> a.Disciplinas)
                            .ThenInclude(d=>d.AlunosDisciplinas)
                            .ThenInclude(ad=>ad.Aluno); 

            query = query.AsNoTracking()
            .OrderBy(p=>p.Id)
            .Where(p => p.Disciplinas
            .Any(ad => ad.AlunosDisciplinas
            .Any(d=>d.DisciplinaId==disciplinaId)));   
            return query.ToArray();
        }
    }
}