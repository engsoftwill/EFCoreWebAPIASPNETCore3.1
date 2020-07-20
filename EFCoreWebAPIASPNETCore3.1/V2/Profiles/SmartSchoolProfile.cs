using AutoMapper;
using SmartSchool.WebAPI.V2.Dtos;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V2.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
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