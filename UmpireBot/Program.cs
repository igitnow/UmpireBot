using System;
using Microsoft.Extensions.DependencyInjection;
using UmpireBot.Services.Simulation;
using UmpireBot.Services;
using UmpireBot.Misc;
using UmpireBot.Services.Peer;
using Microsoft.Extensions.Hosting;

namespace UmpireBot
{
    class Program
    {
        static void Main(string[] args)
        {
           (new AppExceptionHandler()).Start();

            Intro.Cast();

            Console.WriteLine("\nChecking config...\n");

            FileChecker.Evaluate(new Config());

            Console.WriteLine("\nRunning service...\n");

            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((_, services) =>
                        services.AddHostedService<Peer>()
                                .AddScoped<ISimulatable<MatchString>, TennisSimulator>());

    }
}
