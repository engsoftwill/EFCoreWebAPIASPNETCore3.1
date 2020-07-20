using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoDto
    {
        public AlunoDto()
        {
        }

        
        public AlunoDto(int id, int matricula, string nome, string telefone, DateTime dataNasc)
        {
            this.Id = id;
            this.Matricula = matricula;
            this.nomecompleto = nome;
            this.Telefone = telefone;
            this.DataNasc = dataNasc;

        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string nomecompleto { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; } 
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; } = true;
        public int idade { get; set; }
    }
}