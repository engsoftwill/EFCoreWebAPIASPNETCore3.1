using System;

namespace SmartSchool.WebAPI.V2.Dtos
{
    public class ProfessorDto
    {
    public ProfessorDto()
    {

    }

    public ProfessorDto(int id, int registo, string nome, string telefone, DateTime dataNasc)
    {
        this.Id = id;
        this.Registo = registo;
        this.nomecompleto = nome;
        this.Telefone = telefone;
        this.DataNasc = dataNasc;
    }

    public int Id { get; set; }
    public int Registo { get; set; }
    public string nomecompleto { get; set; }
    public int idade { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNasc { get; set; }
    public DateTime DataIni { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; } = null;
    public bool Ativo { get; set; } = true;
    }
}