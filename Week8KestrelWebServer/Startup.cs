/*
 * Copyright 2016-2019 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan Khanna
 * Date: 2019-3-3
 */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week8KestrelWebServer.Data;
using Week8KestrelWebServer.Logging;
using Week8KestrelWebServer.Services;

namespace Week8KestrelWebServer
{
	/// <summary>
	/// Represents application startup.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// The configuration
		/// </summary>
		private readonly IConfiguration configuration;

		/// <summary>
		/// The hosting environment.
		/// </summary>
		private readonly IHostingEnvironment hostingEnvironment;

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup" /> class.
		/// </summary>
		public Startup(IHostingEnvironment hostingEnvironment)
		{
			var workingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			Directory.SetCurrentDirectory(workingDirectory);

			this.configuration = new ConfigurationBuilder().SetBasePath(workingDirectory)
														   .AddXmlFile($"{workingDirectory}\\app.config", false, true)
														   .Build();

			this.hostingEnvironment = hostingEnvironment;

			var environment = this.configuration.GetValue<string>("environment:value")?.ToLowerInvariant();

			switch (environment)
			{
				case "development":
				case "staging":
				case "production":
					this.hostingEnvironment.EnvironmentName = environment;
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(environment), $"Invalid environment: {environment}. Valid values are: Development, Staging, Production");
			}
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		public void Configure(IApplicationBuilder app)
		{
			if (this.hostingEnvironment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else if (this.hostingEnvironment.IsStaging() || this.hostingEnvironment.IsProduction())
			{
				app.UseExceptionHandler("/Error/Index");
			}

			app.UseHsts();

			app.Use(async (context, next) =>
			{
				context.Response.OnStarting((state) =>
				{
					context.Response.Headers["Content-Type"] = "text/xml";
					context.Response.Headers["X-Frame-Options"] = "deny";
					context.Response.Headers["X-Content-Type-Options"] = "nosniff";
					context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
					context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
					context.Response.Headers["Pragma"] = "no-cache";

					return Task.CompletedTask;
				}, context);

				await next.Invoke();
			});

			// TODO: add request log middleware

			// TODO: implement Map, MapWhen

			// TODO: show app.run to handle extra requests
		}

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(logging =>
			{
				logging.ClearProviders();
				logging.AddConsole();

				logging.SetMinimumLevel(Enum.Parse<LogLevel>(this.configuration.GetValue<string>("logging:minimumLevel")));

				logging.AddFile(options =>
				{
					options.FileLogSwitches = this.configuration.GetSection("logging:switches:switch").GetChildren().Select(c => new FileLogSwitch(c.Key, Enum.Parse<LogLevel>(c.Value)));
					options.FilePath = this.configuration.GetValue<string>("logging:path");
				});
			});

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseInMemoryDatabase("Week8Db");
			});

			services.AddTransient<IPersonService, PersonService>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}
	}
}