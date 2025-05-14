using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using InkPeddler.GraphQL.API.Schema.Types;
using InkPeddler.GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InkPeddler.GraphQL.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set;  }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                    .AddEntityFrameworkSqlServer()
                    .AddDbContext<InkPeddlerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("InkPeddler")));

            services
                .AddDataLoaderRegistry()
                .AddGraphQL(sp =>
                {
                    return SchemaBuilder.New()
                        .AddQueryType<QueryType>()
                        .AddAuthorizeDirectiveType()
                        .Create();
                });

             // Adds the authorize directive and
             // enable the authorization middleware.
             //.AddAuthorizeDirectiveType()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            app
                .UseWebSockets()
                .UseGraphQL("/graphql")
                .UseGraphiQL("/graphql")
                .UsePlayground("/graphql")
                .UseVoyager("/graphql");
        }
    }
}