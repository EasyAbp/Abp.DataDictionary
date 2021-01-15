using System.Threading.Tasks;

namespace DataDictionary.Sample.Data
{
    public interface ISampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
