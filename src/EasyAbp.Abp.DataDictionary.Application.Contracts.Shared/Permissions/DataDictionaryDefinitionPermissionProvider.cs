using EasyAbp.Abp.DataDictionary.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DataDictionary.Permissions
{
    public class DataDictionaryDefinitionPermissionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var dataDictionaryGroup = context.AddGroup(DataDictionaryPermissions.GroupName, L("Permission:DataDictionary"));

            var dataDictionary = dataDictionaryGroup.AddPermission(DataDictionaryPermissions.DataDictionary.Default, L("Permission:DataDictionary"));
            dataDictionary.AddChild(DataDictionaryPermissions.DataDictionary.Create, L("Permission:Create"));
            dataDictionary.AddChild(DataDictionaryPermissions.DataDictionary.Update, L("Permission:Edit"));
            dataDictionary.AddChild(DataDictionaryPermissions.DataDictionary.Delete, L("Permission:Delete"));
            dataDictionary.AddChild(DataDictionaryPermissions.DataDictionary.Management, L("Permission:Management"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DataDictionaryResource>(name);
        }
    }
}