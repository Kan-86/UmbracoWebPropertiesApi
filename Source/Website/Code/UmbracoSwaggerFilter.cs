using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace Website.Code
{
    public class UmbracoSwaggerFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (var apiDescription in apiExplorer.ApiDescriptions)
            {
                var matchingApiRoutes = swaggerDoc.paths.Where(x => x.Key.Contains("WebProperties"));
                var swaggerRoutes = new Dictionary<string, PathItem>();
                foreach (var route in matchingApiRoutes)
                {
                    swaggerRoutes.Add(route.Key, route.Value);
                }
                swaggerDoc.paths = swaggerRoutes;
            }
        }
    }
}