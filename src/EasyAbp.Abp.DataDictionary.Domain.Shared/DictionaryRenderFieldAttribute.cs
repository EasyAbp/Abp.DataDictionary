using System;

namespace EasyAbp.Abp.DataDictionary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DictionaryRenderFieldAttribute : Attribute
    {
        public string DictionaryCode { get; }

        public DictionaryRenderFieldAttribute(string dictionaryCode)
        {
            DictionaryCode = dictionaryCode;
        }
    }
}