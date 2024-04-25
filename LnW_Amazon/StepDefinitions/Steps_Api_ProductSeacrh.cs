using LnW_Amazon.Hook;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.StepDefinitions
{
    [Binding]
    internal class Steps_Api_ProductSeacrh
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"I search for a phone on amazon using api")]
        public void GivenISearchForAPhoneOnAmazonUsingApi()
        {
            client = new RestClient("https://real-time-amazon-data.p.rapidapi.com/");
            request = new RestRequest("search?query=Phone&page=1&country=US&category_id=aps");
            request.AddHeader("X-RapidAPI-Key", "d08677c20emsh9a3247940a3d6acp1253acjsn175687857e8f");
            request.AddHeader("X-RapidAPI-Host", "real-time-amazon-data.p.rapidapi.com");
            response = client.Execute(request);
           
           
        }

        [When(@"I get the response success")]
        public void WhenIGetTheResponseSuccess()
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
        }

        [Then(@"I copy the product price")]
        public void ThenICopyTheProductPrice()
        {
            var content = response.Content;
            Console.WriteLine(content);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(content);
            var product = myDeserializedClass.data.products;
            //var productprice = product.

            foreach (var element in product) 
            {
                if (element.product_title.Contains("Samsung"))
                {
                    var productprice = element.product_price;


                }

            }
        }

    }
}
