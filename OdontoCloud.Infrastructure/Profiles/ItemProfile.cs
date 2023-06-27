using AutoMapper;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Item;

namespace OdontoCloud.Infrastructure.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemWriteDTO, Item>();
            CreateMap<Item, ItemWriteDTO>();
            CreateMap<Item, ItemReadDTO>();
        }
    }
}
