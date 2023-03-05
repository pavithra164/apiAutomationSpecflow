using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProject1.Hooks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowProject1.Steps;

[Binding]
public class httpget
{
    HttpClient httpClient;
    HttpResponseMessage response;
    String responsebody;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    public httpget(ISpecFlowOutputHelper _specFlowOutputHelper)
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
      
    }


    [Then(@"request should be a success with (.*) code")]
        public void ThenRequestShouldBeASuccessWithCode(int p0)
        {
        //Assert.True(response.IsSuccessStatusCode);
        
        if( p0 == (int)response.StatusCode)
        {
            Console.WriteLine("test passed");
            _specFlowOutputHelper.WriteLine(responsebody);
            var desdata = JsonConvert.DeserializeObject<datamodel>(responsebody);
            _specFlowOutputHelper.WriteLine("page number is " + desdata.total_pages.ToString());
            
        }
        else {Console.WriteLine("test failed");
        }
       
        }
        
        
        [Given(@"the user sends a get request as ""([^""]*)""")]
        public async Task GivenTheUserSendsAGetRequestAs(string uri)
        {
            response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            responsebody = await response.Content.ReadAsStringAsync();
        }


        [Then(@"request2 should be a success with (.*) code")]
        public void ThenRequest2ShouldBeASuccessWithCode(int p0)
        {
            //Assert.True(response.IsSuccessStatusCode);
        
            if( p0 == (int)response.StatusCode)
            {
                Console.WriteLine("test passed");
            
            }
            else {Console.WriteLine("test failed");
            }
       
        }
}