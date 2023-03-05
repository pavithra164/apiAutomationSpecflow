using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProject1.Hooks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowProject1.Steps;

[Binding]
public sealed class httpput
{

    HttpClient httpClient;
        HttpResponseMessage response;
        HttpResponseMessage response1;
        String responsebody;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    public httpput(ISpecFlowOutputHelper _specFlowOutputHelper)
    {
        httpClient = new HttpClient();
        this._specFlowOutputHelper = _specFlowOutputHelper;
    }

    [Given(@"the user sends a put request with URL as ""([^""]*)""")]
    public async Task GivenTheUserSendsAPutRequestWithUrlAs(string uri)
    {
        userdata userData = new userdata()
            {
                name = "morpheus",
                job = "leader"
            }
            ;

        string data = JsonConvert.SerializeObject(userData);
        var contentdata = new StringContent(data);
        response = await httpClient.PutAsync(uri, contentdata);
        responsebody = await response.Content.ReadAsStringAsync();
        _specFlowOutputHelper.WriteLine(" Response is " + responsebody);
    }

    [Then(@"user should recieve response with success status code")]
    public void ThenUserShouldRecieveResponseWithSuccessStatusCode()
    {

        Assert.True(response.IsSuccessStatusCode);

    }
}