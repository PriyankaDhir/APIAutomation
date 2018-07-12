using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAutomationSuite.Steps
{
    [Binding]
    public sealed class APIApplication
    {
        [Given(@"I have a endpoint (.*)")]
        public void GivenIHaveAEndpointEndpoint(string endpoint)
        {
            ApiHelper.SetUrl(endpoint);
        }

        [When(@"I call get method to get state details using (.*)")]
        public void WhenICallGetMethodToGetStateDetailsUsingStateAbbrevation(string stateAbbrevation)
        {
            ApiHelper.CreateRequest(stateAbbrevation);
        }

        [Then(@"I get state information in response")]
        public void ThenIGetStateInformationInResponse()
        {
            var response = ApiHelper.GetResponse();
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "200 status code not received");
            dynamic response2 = JsonConvert.DeserializeObject(response.Content);
            Assert.That(response2.RestResponse.result.largest_city, Is.EqualTo("Birmingham"),"Largest City of state doesnot match");
            Assert.That(response2.RestResponse.result.capital, Is.EqualTo("Montgomery"),"Capital of state doesnot match");
        }
    }
}
