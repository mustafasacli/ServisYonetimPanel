﻿namespace ServisYonetimPanel.Api.ConsoleApp
{
    using Owin;
    using System;
    using System.Web.Http;

    public class Startup
    {
        // Write to Package Manager Console "Install-Package Microsoft.AspNet.WebApi.OwinSelfHost"

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host.
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
            appBuilder.Run(context =>
            {
                string t = DateTime.Now.Millisecond.ToString();
                return context.Response.WriteAsync(t + " Test OWIN App " + context.Request?.RemoteIpAddress);
            });
        }
    }
}