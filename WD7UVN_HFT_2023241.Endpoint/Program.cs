using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WD7UVN_HFT_2023241.Repository;

namespace WD7UVN_HFT_2023241.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            Database.Context = new();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
