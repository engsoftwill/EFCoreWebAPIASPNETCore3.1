using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorRegistrarDto
    {
        public int Id { get; set; }
        public int Registo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}