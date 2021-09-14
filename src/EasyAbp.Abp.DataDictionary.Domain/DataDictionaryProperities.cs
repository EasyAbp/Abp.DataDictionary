namespace EasyAbp.Abp.DataDictionary
{
    public static class DataDictionaryDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpAbpDataDictionary";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpAbpDataDictionary";
    }
}