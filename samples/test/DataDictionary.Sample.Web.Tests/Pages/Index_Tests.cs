﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DataDictionary.Sample.Pages
{
    public class Index_Tests : SampleWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
