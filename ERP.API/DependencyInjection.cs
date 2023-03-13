using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Accounts;
using ERP.Data.Interfaces.Administration;
using ERP.Data.Interfaces.Configuration;
using ERP.Data.Repositories.Accounts;
using ERP.Data.Repositories.Administration;
using ERP.Data.Repositories.Configuration;
using ERP.DataAccess.Security;
using ERP.Interface.IService.Accounts;
using ERP.Interface.IService.Administration;
using ERP.Interface.IService.Configuration;
using ERP.Services.Service.Accounts;
using ERP.Services.Service.Administration;
using ERP.Services.Service.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;


namespace ERP.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region First-is-the-interface-only-methods-and-second-is-its-implementation
            services.AddScoped<IDataConnection, DapperORM>();
            services.AddScoped<ILevel1Repository, SQLLevel1Repository>();
            services.AddScoped<ILevel2Repository, SQLLevel2Repository>();
            services.AddScoped<ILevel3Repository, SQLLevel3Repository>();
            services.AddScoped<ILevel4Repository, SQLLevel4Repository>();

            services.AddScoped<ICompanyRepository, SQLCompanyRepository>();
            services.AddScoped<ILocationRepository, SQLLocationRepository>();
            services.AddScoped<IBranchRepository, SQLBranchRepository>();
            services.AddScoped<IBankRepository, SQLBankRepository>();
            services.AddScoped<IBankDetailRepository, SQLBankDetailRepository>();

            services.AddScoped<IChequebookMstRepository, SQLChequebookMstRepository>();
            services.AddScoped<IFiscalYearRepository, SQLFiscalYearRepository>();

            services.AddScoped<ILevel1Service, Level1Service>();
            services.AddScoped<ILevel2Service, Level2Service>();
            services.AddScoped<ILevel3Service, Level3Service>();
            services.AddScoped<ILevel4Service, Level4Service>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankDetailService, BankDetailService>();

            services.AddScoped<IChequebookMstService, ChequebookMstService>();
            services.AddScoped<IFiscalYearService, FiscalYearService>();

            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            services.AddSingleton<DataProtectionPurposeStrings>();
            return services;
            #endregion 
        }
    }
}
