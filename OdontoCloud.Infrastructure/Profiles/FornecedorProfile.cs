using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Fornecedor;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<FornecedorWriteDTO, Fornecedor>();
            CreateMap<Fornecedor, FornecedorWriteDTO>();
            CreateMap<Fornecedor, FornecedorReadDTO>();
        }
    }
}
