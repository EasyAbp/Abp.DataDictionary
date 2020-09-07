using System.Threading.Tasks;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryRenderValueProvider
    {
        Task<string> GetValueAsync(string dictCode, string itemCode);
    }
}