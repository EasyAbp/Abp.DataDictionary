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
}