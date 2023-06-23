using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.DetalheAtendimento;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class DetalheAtendimentoProfile : Profile
    {
        public DetalheAtendimentoProfile()
        {
            CreateMap<DetalheAtendimentoWriteDTO, DetalheAtendimento>();
            CreateMap<DetalheAtendimento, DetalheAtendimentoWriteDTO>();
            CreateMap<DetalheAtendimento, DetalheAtendimentoReadDTO>();
        }
    }
}
