using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryManager : IDomainService
    {
        Task CreateAsync(DataDictionary dict);

        Task UpdateAsync(DataDictionary dict);
    }
}