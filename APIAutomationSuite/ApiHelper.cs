using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationSuite
{
    public static class ApiHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = "http://services.groupkt.com/state/get/USA/";

        public static RestClient SetUrl(string endpoint)
        {
            var url = baseUrl + endpoint;
            return client = new RestClient(url);
        }

        public static RestRequest CreateRequest(string stateAbbrevation)
        {
            var resource = stateAbbrevation;
            restRequest = new RestRequest(resource, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }
    }
}
