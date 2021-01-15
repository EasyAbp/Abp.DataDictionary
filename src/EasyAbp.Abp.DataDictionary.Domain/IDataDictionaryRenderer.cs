using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryRenderer
    {
        Task<TDto> RenderAsync<TDto>(TDto sourceDto);

        Task<List<TDto>> RenderListAsync<TDto>(IEnumerable<TDto> sourceListDto);
    }
}