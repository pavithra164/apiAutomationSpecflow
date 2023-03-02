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
public class httptest11
{
    HttpClient httpClient;
    HttpResponseMessage response;
    String responsebody;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    public httptest11(ISpecFlowOutputHelper _specFlowOutputHelper)
    {
        httpClient = new HttpClient();
        this._specFlowOutputHelper = _specFlowOutputHelper;
    }


    [Given(@"the user sends a get request with URL as ""([^""]*)""")]
    public async Task GivenTheUserSendsAGetRequestWithUrlAs(string uri)
    {
        response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        responsebody = await response.Content.ReadAsStringAsync();
        _specFlowOutputHelper.WriteLine(responsebody);
        var desdata = JsonConvert.DeserializeObject<datamodel>(responsebody);
        _specFlowOutputHelper.WriteLine(desdata.page.ToString());
    }


    [Then(@"request should be a success with (.*) code")]
        public void ThenRequestShouldBeASuccessWithCode(int p0)
        {
         Assert.True(response.IsSuccessStatusCode); 
        }
    
}