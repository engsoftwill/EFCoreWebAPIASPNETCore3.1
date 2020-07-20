using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor()
        {
        }

        public Professor(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;

        }
        public Professor(int id, int registo, string nome, string sobrenome)
        {
            this.Id = id;
            this.Registo = registo;
            this.Nome = nome;
            this.Sobrenome = sobrenome;

        }
        public int Id { get; set; }
        public int Registo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;

        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}