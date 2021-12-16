using GraphQLServer.Data;
using GraphQLServer.Data.Models;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace GraphQLServer
{
    public class Startup
    {
        private const string schemaResourceName = "GraphQLServer.Schema.Schema.graphql";
        private const string graphQLPath = "/graphql";

        public void ConfigureServices(IServiceCollection services)
        {
            string graphQLSchemaText = LoadSchema();

            services.AddRouting()
                .AddGraphQLServer()
                    .AddDocumentFromString(graphQLSchemaText)

                    .AddResolver<Query>()
                    .BindRuntimeType<SimpleObject>()
            ;
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment()) { application.UseDeveloperExceptionPage(); }

            application.UseRouting();

            application.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapGraphQL(graphQLPath);
            });
        }

        public static string LoadSchema()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            using (Stream schemaStream = thisAssembly.GetManifestResourceStream(schemaResourceName))
            using (StreamReader schemaReader = new StreamReader(schemaStream))
            {
                return schemaReader.ReadToEnd();
            };
        }
    }
}
