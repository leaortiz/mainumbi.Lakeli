using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace mainumbi.Lakeli.Pages;

public class Index_Tests : LakeliWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
