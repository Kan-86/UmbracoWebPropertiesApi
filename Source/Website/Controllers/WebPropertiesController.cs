using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Website.Code;

namespace Website.Controllers
{
    public class WebPropertiesController : UmbracoApiController
    {

        public WebPropertiesController() { }

        /// <summary>
        /// Gets all the properties from the website using a specific Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A JSON format of all the properties</returns>
        /// <response code="400">Content not found.</response> 
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [Microsoft.AspNetCore.Mvc.Route("WebProperties/getAllWebsiteProperties")]
        public object GetAllWebsiteProperties(int id)
        {
            try
            {
                var root = Umbraco.Content(id);

                // Check if the content exists
                if (root != null)
                {
                    // Get the childre of the root, will return an array
                    var results = root.Children;

                    // A method to override JsonSerializer
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new PublishedContentContractResolver()
                    };

                    // Serialize the result with the settings to JSON then deserialize it so we can return it
                    var serialized = JsonConvert.SerializeObject(results, Formatting.Indented, settings);
                    return JsonConvert.DeserializeObject(serialized);
                }
                else
                {
                    return BadRequest("Content not found.");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}