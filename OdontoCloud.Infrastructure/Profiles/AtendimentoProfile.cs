using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Atendimento;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class AtendimentoProfile : Profile
    {
        public AtendimentoProfile()
        {
            CreateMap<AtendimentoWriteDTO, Atendimento>();
            CreateMap<Atendimento, AtendimentoWriteDTO>();
            CreateMap<Atendimento, AtendimentoReadDTO>();
        }
    }
}
