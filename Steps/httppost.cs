using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProject1.Hooks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowProject1.Features;

[Binding]
public class httppost
{
    
    HttpClient httpClient;
    HttpResponseMessage response;
    String responsebody;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    public httppost(ISpecFlowOutputHelper _specFlowOutputHelper)
    {
        httpClient = new HttpClient();
        this._specFlowOutputHelper = _specFlowOutputHelper;
    }

    [Given(@"the user sends a post request with URL as ""([^""]*)""")]
    public async Task GivenTheUserSendsAPostRequestWithUrlAs(string uri)
    {
        postdata postData = new postdata()
        {
            name = "morpheus",
            job = "leader" }
        ;

        string data = JsonConvert.SerializeObject(postData);
        var contentdata = new StringContent(data);
        response = await httpClient.PostAsync(uri, contentdata);
      
        responsebody = await response.Content.ReadAsStringAsync();
        _specFlowOutputHelper.WriteLine("Post response is " + responsebody);
        
    }


    [Then(@"user should get a success response")]
    public void ThenUserShouldGetASuccessResponse()
    {
        Assert.True(response.IsSuccessStatusCode);
    }
}