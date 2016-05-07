using PlacesAPI.Models;
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
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, Type = typeof(PlacesResponse))]
        public async System.Threading.Tasks.Task<HttpResponseMessage> Get(string latitude, string longitude, int radius, string query, string key)
        {
            using (var client = new HttpClient())
            {
                var url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString["location"] = latitude + "," + longitude;
                queryString["radius"] = radius.ToString();
                queryString["name"] = query;
                queryString["key"] = key;

                url = url + queryString.ToString();

                return await client.GetAsync(url);

            }
        }
    }
}
