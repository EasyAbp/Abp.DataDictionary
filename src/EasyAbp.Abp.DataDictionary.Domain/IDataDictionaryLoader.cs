using System.Collections.Generic;
using System.Reflection;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryLoader
    {
        List<DataDictionaryRule> ScanRules(Assembly assembly = null);
    }
}