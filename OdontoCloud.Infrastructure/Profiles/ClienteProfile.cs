using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Cliente;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteWriteDTO, Cliente>();
            CreateMap<Cliente, ClienteWriteDTO>();
            CreateMap<Cliente, ClienteReadDTO>();
        }
    }
}
