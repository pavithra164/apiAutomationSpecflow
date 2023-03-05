using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProject1.Hooks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowProject1;

[Binding]
public class httppatch
{
    HttpClient httpClient;
    HttpResponseMessage response;
    HttpResponseMessage response1;
    String responsebody;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    public httppatch(ISpecFlowOutputHelper _specFlowOutputHelper)
    {
        httpClient = new HttpClient();
        this._specFlowOutputHelper = _specFlowOutputHelper;
    }

    [Given(@"the user sends a patch request with URL as ""([^""]*)""")]
    public async Task GivenTheUserSendsAPatchRequestWithUrlAs(string uri)
    {
        userdata userData = new userdata()
            {
                name = "Emily"
            }
            ;

        string data = JsonConvert.SerializeObject(userData);
        var contentdata = new StringContent(data);
        response = await httpClient.PatchAsync(uri, contentdata);
        responsebody = await response.Content.ReadAsStringAsync();
        _specFlowOutputHelper.WriteLine("response is " + responsebody);
    }

    [Then(@"user should recieve a success response")]
    public void ThenUserShouldRecieveASuccessResponse()
    {
       
        Assert.True(response.IsSuccessStatusCode);
        
    }
}