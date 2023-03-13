using ERP.DataAccess;
using ERP.DataAccess.ViewModels;
using ERP.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
                        _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(_config.GetConnectionString("AppDbConnection")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDBContext>();

            services.AddMvc(options=> {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            //services.ConfigureApplicationCookie(options =>
            //options.AccessDeniedPath=new PathString("/AccessDenied"));
            services.AddAuthorization(options =>
            {
             
                //options.AddPolicy("ViewLevel1Policy",
                //  policy => policy.RequireAssertion(context => UserAccess(context,"SuperAdmin")));
                //options.AddPolicy("AddLevel1Policy",
                //    policy => policy.RequireAssertion(context =>
                //    UserAccess(context, "SuperAdmin")));
                //options.AddPolicy("EditLevel1Policy",
                //  policy => policy.RequireAssertion(context =>
                //  UserAccess(context, "SuperAdmin")));
                //options.AddPolicy("DeleteLevel1Policy",
                //  policy => policy.RequireAssertion(context =>
                //  UserAccess(context, "SuperAdmin")));

                //options.InvokeHandlersAfterFailure = false;

                //options.AddPolicy("AdminPolicy",
                //  policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

                //services.AddAuthorization(options =>
                //{
                //    options.AddPolicy("EditRolePolicy", policy =>
                //        policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));
                //});

               

            });
            services.AddInfrastructure();
            //services.AddScoped<IDataConnection, DapperORM>();
            //services.AddScoped<ILevel1Repository, SQLLevel1Repository>();
            //services.AddScoped<ILevel1Service, Level1Service>();
            //services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            //services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            //services.AddSingleton<DataProtectionPurposeStrings>();


        }
        private bool UserAccess(AuthorizationHandlerContext context,string RoleName)
        {
            if (RoleName == "SuperAdmin")
            {
                return context.User.IsInRole("SuperAdmin");
            }
            else if (RoleName == "SuperAdminOrAdmin")
            {
                return context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin");
            }
            else
            {
                return context.User.IsInRole("User");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

           

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Level1}/{action=Create}/{id?}");
            });
        }
    }
}
