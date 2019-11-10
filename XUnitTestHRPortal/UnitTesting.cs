namespace XUnitTestHRPortal
{
    public class UnitTesting : TestScenarioBase
    {
        [Fact]
        public void TestName()
        {
        //Given
        
        //When
        using (var server = CreateServer())
            {
                var response = await server.CreateClient().GetAsync($"api/values");
                Assert.Equal(1,1);
            }
        //Then
        }
    }
}