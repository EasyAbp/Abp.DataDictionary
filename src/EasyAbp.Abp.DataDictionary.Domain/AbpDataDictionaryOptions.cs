using System.Collections.Generic;

namespace EasyAbp.Abp.DataDictionary
{
    public class AbpDataDictionaryOptions
    {
        public List<DataDictionaryRule> Rules { get; set; }

        public AbpDataDictionaryOptions()
        {
            Rules = new List<DataDictionaryRule>();
        }
    }
}