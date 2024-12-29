using DataDictionary.Sample;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("DataDictionary.Sample.Web.csproj");
await builder.RunAbpModuleAsync<SampleWebTestModule>(applicationName: "DataDictionary.Sample.Web" );

public partial class Program
{
}