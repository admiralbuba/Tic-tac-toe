using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using API.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPITicTacToe.Models;
using Microsoft.AspNetCore.SignalR;

namespace WebAPITicTacToe
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        readonly string MyPolicy = "_myPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MapContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TurnsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<WinnersCountContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<GameStateHub>("/gamestate", options => {
                options.ApplicationMaxBufferSize = 64;
                options.TransportMaxBufferSize = 64;
                options.LongPolling.PollTimeout = System.TimeSpan.FromMinutes(1);
                options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;});
                endpoints.MapControllers().RequireCors(MyPolicy);
            });
        }
    }
}
