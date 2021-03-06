using FirstRESTful.Models;
using FirstRESTful.Reposirory;
using FirstRESTful.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTfull
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "server=127.0.0.1;user id=root;database=firstrestdb;password=0802";
            // ????????????? ???????? ??????
            
            services.AddDbContext<ProductsContext>(options => options.UseMySQL(con));

            // ????? ???????? ????????? ? ProductsService
            services.AddScoped<IProductsService, ProductsService>();

            services.AddControllers(); // ?????????? ??????????? ??? ?????????????

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // ?????????? ????????????? ?? ???????????
            });
        }
    }
}
