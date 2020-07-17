using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor()
        {
        }
        
        public Professor(int professorId, string nome)
        {
            this.ProfessorId = professorId;
            this.Nome = nome;

        }
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}