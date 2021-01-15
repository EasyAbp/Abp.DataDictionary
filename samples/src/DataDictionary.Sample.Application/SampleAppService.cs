using DataDictionary.Sample.Localization;
using Volo.Abp.Application.Services;

namespace DataDictionary.Sample
{
    /* Inherit your application services from this class.
     */
    public abstract class SampleAppService : ApplicationService
    {
        protected SampleAppService()
        {
            LocalizationResource = typeof(SampleResource);
        }
    }
}