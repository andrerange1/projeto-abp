using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Abp.Countries.Pages;

public class Index_Tests : CountriesWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
