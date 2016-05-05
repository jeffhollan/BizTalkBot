using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlacesAPI.Controllers
{
    public class PlacesController : ApiController
    {
        private string appKey = ConfigurationManager.AppSettings["key"];
        public HttpResponseMessage Get(string latitude, string longitude, int radius, string query, string key)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/json");
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString["location"] = latitude + "," + longitude;
                queryString["radius"] = radius.ToString();
                queryString["name"] = query;
                queryString["key"] = appKey;


                return queryString.ToString();
            }
        }
    }
}
