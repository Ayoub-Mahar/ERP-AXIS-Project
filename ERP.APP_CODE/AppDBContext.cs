using ERP.DataAccess.Models;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DataAccess
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
     
    }
}
