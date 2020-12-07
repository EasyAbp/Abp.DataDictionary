using AutoMapper;
using EasyAbp.Abp.DataDictionary.Dtos;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryAutoMapperProfile : Profile
    {
        public DataDictionaryAutoMapperProfile()
        {
            CreateMap<DataDictionary, DataDictionaryDto>();
            CreateMap<DataDictionaryItem, DataDictionaryItemDto>().ReverseMap();
        }
    }
}