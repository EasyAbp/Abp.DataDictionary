using System;
using EasyAbp.Abp.DataDictionary.EntityFrameworkCore;

namespace EasyAbp.Abp.DataDictionary.Application.Tests
{
    public class AbpDataDictionaryApplicationTestBase : AbpDataDictionaryTestBase<AbpDataDictionaryApplicationTestsModule>
    {
        protected virtual void UsingDbContext(Action<IDataDictionaryDbContext> action)
        {
            using (var dbContext = GetRequiredService<IDataDictionaryDbContext>())
            {
                action.Invoke(dbContext);
            }
        }
    }
}