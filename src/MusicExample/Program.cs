using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;

namespace Music.Web.Api
{
    public static class Program
    {
        public static void Main(string[] args) 
            => CreateWebHostBuilder(args).Build().Run();

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) 
            => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}