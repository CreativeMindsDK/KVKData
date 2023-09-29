// See https://aka.ms/new-console-template for more information
using CreativeMinds.KVKData.RestAPI;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder()
		  .SetBasePath(Directory.GetCurrentDirectory())
		  .AddJsonFile("appsettings.json", optional: false)
		  .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true);

IConfiguration config = builder.Build();



CancellationToken cancellationToken = new CancellationToken();


CreativeMinds.KVKData.RestAPI.IKVKSearchEngine search = new KVKRestApiSearchEngine(config.GetSection("KVKData"));
var data = search.SearchForCompanyByNamesAsync("", 1, cancellationToken).Result;


String tremp = "";