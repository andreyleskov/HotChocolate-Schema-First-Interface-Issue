using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Hosting;

namespace GraphQLServer
{
	public class Program
	{
		private const string urlsArgumentPrefix = "--urls=";

		public static void Main(string[] args)
		{
			IWebHostBuilder webHostBuilder = CreateWebHostBuilder(args);
			IWebHost webHost = webHostBuilder.Build();
			webHost.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] arguments)
		{
			IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(arguments);
			webHostBuilder.UseStartup<Startup>();

			string baseURI = GetBaseURL(arguments);

			if (null != baseURI)
			{
				UrlPrefix baseUrlPrefix = UrlPrefix.Create(baseURI);

				webHostBuilder.UseHttpSys(options =>
				{
					options.Authentication.Schemes = AuthenticationSchemes.None;
					options.Authentication.AllowAnonymous = true;
					options.UrlPrefixes.Add(baseUrlPrefix);
				});
			}

			return webHostBuilder;
		}

		private static string GetBaseURL(string[] arguments)
		{
			foreach (string argument in arguments)
			{
				if (argument.StartsWith(urlsArgumentPrefix))
				{
					return argument.Replace(urlsArgumentPrefix, "");
				}
			}

			return null;
		}
	}
}
