using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestHRPortal{
    public class UnitTest1 : TestScenarioBase
    {
        [Fact]
        public async Task Get()
        {
        //Given
        
        //When
        using (var server = CreateServer())
            {
                var response = await server.CreateClient().GetAsync($"api/employee");
                Assert.Equal(1,1);
            }
        //Then
        }
        
    }
}