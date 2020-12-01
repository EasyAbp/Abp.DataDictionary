namespace EasyAbp.Abp.DataDictionary.Permissions
{
    public class DataDictionaryPermissions
    {
        public const string GroupName = "EasyAbp.Abp.DataDictionary";

        public static class DataDictionary
        {
            public const string Default = GroupName + ".DataDictionary";
            public const string Manage = Default + ".Manage";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }
    }
}