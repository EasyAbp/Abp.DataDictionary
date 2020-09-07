using System.Threading.Tasks;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryRenderer
    {
        Task<TDto> RenderAsync<TDto>(TDto sourceDto);
    }
}