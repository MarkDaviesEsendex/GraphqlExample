using System.Reflection;
using AutoMapper;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Music.Web.Api.Data;
using Music.Web.Api.Queries;
using Music.Web.Api.Schema;
using UserApi.Data;

namespace Music.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicDbContext>(options => options.UseInMemoryDatabase("Music"));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<MusicQuery>();
            services.AddTransient<MusicSchema>();

            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddWebSockets()
                .AddDataLoader();
            services.AddAutoMapper();
            services.AddRouting();
            services.AddMediatR(Assembly.GetAssembly(typeof(Startup)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<MusicSchema>();
            app.UseGraphQL<MusicSchema>();
            app.UseGraphiQLServer(new GraphiQLOptions());
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
            app.UseMvc(builder =>
            {
                builder.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}