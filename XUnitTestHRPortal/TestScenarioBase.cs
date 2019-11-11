namespace XUnitTestHRPortal
{
public class TestScenarioBase
{
    private readonly HttpClient _client{get; private set;}
public TestServer CreateServer()
{
var webHostBuilder = WebHost.CreateDefaultBuilderd();
webHostBuilder.UseStartup<Startup>();
var server = new TestServer(webHostBuilder);

return server;
}
}
}