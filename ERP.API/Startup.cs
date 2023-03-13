using ERP.API.DependencyInjection;
using ERP.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ERP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDBContext>(
              options => options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));
            services.AddInfrastructure();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });

            });

            //var AppsettingsSection = Configuration.GetSection("Key");
            //services.Configure<AppKey>(AppsettingsSection);
            ////JWT Authentication
            //var appsettings = AppsettingsSection.Get<AppKey>();
            //var key = Encoding.ASCII.GetBytes(appsettings.Key);
            //services.AddAuthentication(au =>
            //{ au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;})
            //    .AddJwtBearer(jwt => {
            //        jwt.RequireHttpsMetadata = false;
            //        jwt.SaveToken = true;
            //        jwt.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "API Services"));

            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
