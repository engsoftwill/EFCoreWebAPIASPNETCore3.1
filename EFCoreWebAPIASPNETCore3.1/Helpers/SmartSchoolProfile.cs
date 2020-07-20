using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest=> dest.nomecompleto,
                    opt=>opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest=> dest.idade,
                    opt=>opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
            
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();


            CreateMap<Professor, ProfessorDto>().ForMember(
                    dest=> dest.nomecompleto,
                    opt=>opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest=> dest.idade,
                    opt=>opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
            CreateMap<Professor,ProfessorDto>().ReverseMap();

        }
    }
}