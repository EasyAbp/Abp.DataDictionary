using DataDictionary.Sample;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<SampleWebTestModule>();

public partial class Program
{
}