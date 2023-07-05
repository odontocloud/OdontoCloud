using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Anamnese;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class AnamneseProfile : Profile
    {
        public AnamneseProfile()
        {
            CreateMap<AnamneseWriteDTO, Anamnese>();
            CreateMap<Anamnese, AnamneseWriteDTO>();
            CreateMap<Anamnese, AnamneseReadDTO>();
        }
    }
}
