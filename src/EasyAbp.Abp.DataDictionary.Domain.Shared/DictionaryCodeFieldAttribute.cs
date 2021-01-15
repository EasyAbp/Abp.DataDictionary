using System;

namespace EasyAbp.Abp.DataDictionary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DictionaryCodeFieldAttribute : Attribute
    {
        public string DictionaryCode { get; }

        public DictionaryCodeFieldAttribute(string dictionaryCode)
        {
            DictionaryCode = dictionaryCode;
        }
    }
}