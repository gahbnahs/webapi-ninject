using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace countingksps
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "Food",
                routeTemplate: "api/nutrition/foods/{foodId}",
                defaults: new {controller="foods", foodId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "Measures",
               routeTemplate: "api/nutrition/foods/{foodId}/measures/{id}",
               defaults: new { controller = "measures", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
            name: "Diaries",
            routeTemplate: "api/user/diaries/{diaryId}",
            defaults: new { controller = "diaries", diaryId = RouteParameter.Optional }
        );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var formatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
