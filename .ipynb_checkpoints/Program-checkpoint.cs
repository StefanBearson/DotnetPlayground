// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.DependencyInjection;

// var host = Host.CreateDefaultBuilder(args)
// .ConfigureLogging( (context, builder) => builder.AddConsole())
// .ConfigureServices(service => {service.AddHostedService<Worker>();})
// .Build();

// await host.RunAsync();

using Constructors;

TestClass test = new TestClass();
test.TestMethod();
