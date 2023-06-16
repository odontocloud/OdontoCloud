using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Endereco;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoWriteDTO, Endereco>();
            CreateMap<Endereco, EnderecoWriteDTO>();
            CreateMap<Endereco, EnderecoReadDTO>();
        }
    }
}
