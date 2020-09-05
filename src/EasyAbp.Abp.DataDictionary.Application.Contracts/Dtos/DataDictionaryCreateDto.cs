namespace EasyAbp.Abp.DataDictionary.Dtos
{
    public class DataDictionaryCreateDto : DataDictionaryCreateOrUpdateBaseDto
    {
        public string Code { get; set; }

        public bool IsSystem { get; set; }
    }
}