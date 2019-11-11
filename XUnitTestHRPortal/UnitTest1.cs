using System.Threading.Tasks;
using Xunit;

namespace XUnitTestHRPortal
{
    public class UnitTest1 : TestScenarioBase
    {
        [Fact]
        public async Task Get()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient().GetAsync($"api/employee");
                Assert.Equal(1, 1);
            }
        }

        [Fact]
        public async Task Get_Id()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient().GetAsync($"api/employee/1");
                Assert.Equal(1, 1);
            }
        }
        [Fact]
        public async Task Post_employee()
        {
            //Arrange
            using (var server = CreateServer())
            {
                var request = new
                {
                    Url = "api/employee",
                    Body = new
                    {
                        EmployeeId = 2,
                        FirstName = "ram",
                        LastName = "king",
                        Email = "ramking@gmail.com",
                        PhoneNumber = "7036355827",
                        Address = "Hyderabad",
                        OfficePhoneNumber = "7036355827",
                        Photo = "",
                        WebUrl = ""
                    }
                };

                //Act
                var response = await server.CreateClient().PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
                var value = await response.Content.ReadAsStringAsync();

                //Assert
                response.EnsureSuccessStatusCode();
            }

        }

        [Fact]
        public async Task Put_Id()
        {
            using (var server = CreateServer())
            {
                //Arrange
                var request = new
                {
                    Url = "api/employee/2",
                    Body = new
                    {
                        FirstName = "ram",
                        LastName = "king",
                        Email = "ramking@gmail.com",
                        PhoneNumber = "7036355827",
                        Address = "Khammam",
                        OfficePhoneNumber = "8500856743",
                        Photo = "",
                        WebUrl = ""
                    }
                };

                //Act
                var response = await server.CreateClient().PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

                //Asset
                response.EnsureSuccessStatusCode();
            }

        }

        [Fact]
        public async Task Delete_employee()
        {
            using (var server = CreateServer())
            {
                //Arrange
                var request = new
                {
                    Url = "api/employee/2",
                    Body = new
                    {
                        EmployeeId = 2,
                        FirstName = "ram",
                        LastName = "king",
                        Email = "ramking@gmail.com",
                        PhoneNumber = "7036355827",
                        Address = "Khammam",
                        OfficePhoneNumber = "8500856743",
                        Photo = "",
                        WebUrl = ""
                    }
                };
                var deleteResponse = await server.CreateClient().DeleteAsync(request.Url);

                // Assert
                deleteResponse.EnsureSuccessStatusCode();
            }
        }

    }
}