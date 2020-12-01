using System;
using System.Reflection;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryRule
    {
        public Type DtoType { get; set; }

        public string DictionaryCode { get; set; }

        public PropertyInfo DictionaryCodeProperty { get; set; }

        public PropertyInfo RenderFieldProperty { get; set; }
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
        public string DictionaryCode { get; }

        public DictionaryRenderFieldAttribute(string dictionaryCode)
        {
            DictionaryCode = dictionaryCode;
        }
    }
}