using System.Threading.Tasks;
using Xunit;

namespace XUnitTestHRPortal
{
    public class UnitTest2 : TestScenarioBase
    {
        [Fact]
        public async Task Post_Register()
        {
            using (var server = CreateServer())
            {
                //Arrange
                var request = new
                {
                    Url = "api/auth",
                    Body = new
                    {
                        Email = "ramking@gmail.com",
                        Password = "saikumar"
                    }
                };
                //Act
                var response = await server.CreateClient().PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
                //Assert
                response.EnsureSuccessStatusCode();
                //var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        [Fact]
        public async Task Post_Login()
        {
            using (var server = CreateServer())
            {
                //Arrange
                var request = new
                {
                    Url = "api/auth/login",
                    Body = new
                    {
                        Username = "ramking@gmail.com",
                        Password = "saikumar"
                    }
                };
                //Act
                var response = await server.CreateClient().PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
                //Assert
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
