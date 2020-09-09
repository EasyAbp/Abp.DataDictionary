using System.Threading.Tasks;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryValueProvider
    {
        Task<string> GetValueAsync(string dictCode, string itemCode);
    }
}