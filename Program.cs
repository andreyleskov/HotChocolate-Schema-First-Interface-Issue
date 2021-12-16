
using System;
using GraphQLServer;
using GraphQLServer.Data;
using GraphQLServer.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddWebSockets(op => { op.KeepAliveInterval = TimeSpan.FromSeconds(30); });

var graphQLSchemaText = Startup.LoadSchema();

builder.Services
    .AddGraphQLServer()
    .AddDocumentFromString(graphQLSchemaText)
    .AddResolver<Query>()
    .BindRuntimeType<SimpleObject>();

var application = builder.Build();
if (application.Environment.IsDevelopment()) { application.UseDeveloperExceptionPage(); }

application.UseRouting();

application.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapGraphQL();
});


application.Run();

// using System;
// using Microsoft.AspNetCore;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Server.HttpSys;
// using Microsoft.Extensions.Hosting;
//
// namespace GraphQLServer
// {
// 	public class Program
// 	{
// 		private const string urlsArgumentPrefix = "--urls=";
//
// 		public static void Main(string[] args)
// 		{
// 			IWebHostBuilder webHostBuilder = CreateWebHostBuilder(args);
// 			IWebHost webHost = webHostBuilder.Build();
// 			webHost.Run();
// 		}
//
// 		public static IWebHostBuilder CreateWebHostBuilder(string[] arguments)
// 		{
// 			IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(arguments);
// 			webHostBuilder.UseStartup<Startup>();
//
// 			string baseURI = GetBaseURL(arguments);
//
// 			if (null != baseURI)
// 			{
// 				UrlPrefix baseUrlPrefix = UrlPrefix.Create(baseURI);
//
// 				webHostBuilder.UseHttpSys(options =>
// 				{
// 					options.Authentication.Schemes = AuthenticationSchemes.None;
// 					options.Authentication.AllowAnonymous = true;
// 					options.UrlPrefixes.Add(baseUrlPrefix);
// 				});
// 			}
//
// 			return webHostBuilder;
// 		}
//
// 		private static string GetBaseURL(string[] arguments)
// 		{
// 			foreach (string argument in arguments)
// 			{
// 				if (argument.StartsWith(urlsArgumentPrefix))
// 				{
// 					return argument.Replace(urlsArgumentPrefix, "");
// 				}
// 			}
//
// 			return null;
// 		}
// 	}
// }
//
//
// using HotChocolate;
// using Microsoft.AspNetCore.WebSockets;
// using OpenDomain.Asp;
// using OpenDomain.ClearScript.Conventional;
// using OpenDomain.ClearScript.Conventional.TypeDefinition.CommonAggregate.Exceptions;
// using ProductBuilder.Application;
// using ProductBuilder.Schema;
// using Serilog;
//
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddRouting();
// builder.Services.AddWebSockets(op => { op.KeepAliveInterval = TimeSpan.FromSeconds(30); });
// builder.Logging.AddSerilog(LoggerDefaultConfiguration.BuildLogger());
//
// var config = new OpenDomainConfiguration();
// builder.Configuration.Bind(config);
// config.Load<Program>();
//
// //builder.AddOpenDomain(config);
//
//
// var schema = await typeof(Types).Assembly.LoadTextFromEmbeddedResource("testSchema.graphqls");
// builder.Services.AddGraphQLServer()
// 	.AddDocumentFromString(schema)
// 	//.BindRuntimeType<Query>("Query")
// 	// .BindRuntimeType<Types.Language>()
// 	// .BindRuntimeType<Types.Expression>()
// 	.AddResolver<Query>()
// 	// .BindRuntimeType<Types.Language>()
// 	// .BindRuntimeType<Types.Expression>()
// 	//  .AddResolver("Query", "Evaluate", async c => await new Query().Evaluate(c.ArgumentValue<Types.Expression>("expression")));
// 	// .AddResolver<TestQuery>("Query");
// 	;
//
//
// var app = builder.Build();
//
// //await app.InitializeOpenDomain();
//
// if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
// app.UseRouting();
// app.UseWebSockets();
// //app.UseOpenDomainDefaults();
//
// app.UseEndpoints(endpoints => endpoints.MapGraphQL());
//
// app.Run();
//
// public class TestQuery
// {
// 	public Task<string> EvaluateTest() => Task.FromResult("");
// }