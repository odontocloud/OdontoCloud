using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Funcionario;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioWriteDTO, Funcionario>();
            CreateMap<Funcionario, FuncionarioWriteDTO>();
            CreateMap<Funcionario, FuncionarioReadDTO>();
        }
    }
}
