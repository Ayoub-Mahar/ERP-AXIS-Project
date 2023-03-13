using ERP.DataAccess.Models.ChartOfAccounts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataAccess.Models
{
    public class SQLLOneRepository 
    {

        private readonly AppDBContext context;
        public SQLLOneRepository(AppDBContext _context)
        {
            context = _context;
        }
        public Level1 AddLevel1(Level1 _level1)
        {
            context.Level1.Add(_level1);
            context.SaveChanges();
            return _level1;
        }
        public Level1 UpdateLevel1(Level1 _level1Changes)
        {
           var level1 = context.Level1.Attach(_level1Changes);
            level1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return _level1Changes;
        }
        public Level1 DeleteLevel1(int id)
        {
            Level1 objlvl1 = context.Level1.Find(id);
            if (objlvl1 != null)
            {
                context.Level1.Remove(objlvl1);
                context.SaveChanges();
            }
            return objlvl1;
        }

        public IEnumerable<Level1> GetAllLevel1()
        {
            return context.Level1;
        }

        public Level1 GetLevel1ByID(int id)
        {
            return context.Level1.Find(id);
        }

        public async Task<Level1> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Add(Level1 _Model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(Level1 _Model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Level1>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
