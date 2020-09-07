using System;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryRule
    {
        public Type DtoType { get; set; }

        public string DictionaryCode { get; set; }

        public Type RenderFieldProperty { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DictionaryCodeFieldAttribute : Attribute
    {
        public string DictionaryCode { get; }

        public DictionaryCodeFieldAttribute(string dictionaryCode)
        {
            DictionaryCode = dictionaryCode;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DictionaryRenderFieldAttribute : Attribute
    {
    }
}