
using ERP.Data.Interfaces.Accounts;
using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.DataAccess.ViewModels.ChartOfAccountsVM;
using ERP.Interface.IService.Accounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Accounts
{
    public class Level4Service : ILevel4Service
    {
        #region Implementing-Interface-ILevel4service-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ILevel4Repository _Level4Repository;
        private readonly ILevel1Service level1Service;
        private readonly ILevel2Service level2Service;
        private readonly ILevel3Service level3Service;
        List<LevelsVM> objlevels;
        public Level4Service(ILevel4Repository  Level4Repository, ILevel1Service _Level1Service
            , ILevel2Service _Level2Service, ILevel3Service _Level3Service)
        {
            this._Level4Repository = Level4Repository;
            level1Service = _Level1Service;
            level2Service = _Level2Service;
            level3Service = _Level3Service;
        }

        public async Task<bool> Add(Level4 _Model)
        {
            return await _Level4Repository.Add(_Model);
        }
        public async Task<bool> Update(Level4 _Model)
        {
            return await _Level4Repository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _Level4Repository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Level4>> GetAll()
        {
            return await _Level4Repository.GetAll();
        }

        public async Task<Level4> GetByID(int id)
        {
            return await _Level4Repository.GetByID(id);
        }

       
        public async Task<IEnumerable<Level4>> GetLevel4ByLevel1and2and3(int level1id, int Level2Id, int Level3Id)
        {
            IEnumerable<Level4> Objlvl4 = await _Level4Repository.GetAll();
            return Objlvl4.Where(a => a.Level1ID == level1id && a.Level2ID == Level2Id && a.Level3ID == Level3Id);
        }
        public async Task<List<LevelsVM>> GetLevels()
        {
            objlevels = new List<LevelsVM>();
            IEnumerable<Level1> lvl1;
            lvl1 = await level1Service.GetAll();
            LevelsVM level1;
            foreach (Level1 item in lvl1)
            {
                level1 = new LevelsVM();
                level1.Level1ID = item.Level1ID;
                level1.Description = item.Level1Desc;
                objlevels.Add(level1);
                await GetChildLevels(2, item.Level1ID, 0, 0);
            }
            return objlevels.OrderBy(x => x.Level1ID).ThenBy(x => x.Level2ID).ThenBy(x => x.Level3ID).ThenBy(x => x.Level4ID).ToList();

        }
        #endregion
        #region private-methods
        private async Task GetChildLevels(int Level, int Level1id, int Level2id, int Level3id)
        {
            if (Level == 2)
            {
                IEnumerable<Level2> lvl2;
                lvl2 = await level2Service.GetLevel2ByLevel1(Level1id);
                LevelsVM level2;
                foreach (Level2 item in lvl2)
                {
                    level2 = new LevelsVM();
                    level2.Level1ID = item.Level1ID;
                    level2.Level2ID = item.Level2ID;
                    level2.Description = item.Level2Desc;
                    objlevels.Add(level2);
                    await GetChildLevels(3, item.Level1ID, item.Level2ID, 0);
                }
            }
            else if (Level == 3)
            {
                IEnumerable<Level3> lvl3;
                lvl3 = await level3Service.GetLevel3ByLevel1and2(Level1id, Level2id);
                LevelsVM level3;
                foreach (Level3 item in lvl3)
                {
                    level3 = new LevelsVM();
                    level3.Level1ID = item.Level1ID;
                    level3.Level2ID = item.Level2ID;
                    level3.Level3ID = item.Level3ID;
                    level3.Description = item.Level3Desc;
                    objlevels.Add(level3);
                    await GetChildLevels(4, item.Level1ID, item.Level2ID, item.Level3ID);
                }
            }
            else if (Level == 4)
            {
                IEnumerable<Level4> lvl4;
                lvl4 = await GetLevel4ByLevel1and2and3(Level1id, Level2id, Level3id);
                LevelsVM level4;
                foreach (Level4 item in lvl4)
                {
                    level4 = new LevelsVM();
                    level4.Level1ID = item.Level1ID;
                    level4.Level2ID = item.Level2ID;
                    level4.Level3ID = item.Level3ID;
                    level4.Level4ID = item.Level4ID;
                    level4.Description = item.Level4Desc;
                    objlevels.Add(level4);
                }
            }
        }

        //private async Task GetLevels()
        //{
        //    List<LevelsVM> levelsVMs = new List<LevelsVM>();

        //    IEnumerable<Level1> lvl1;
        //    lvl1 = await level1Service.GetAll();
        //    LevelsVM level1;
        //    foreach (Level1 item in lvl1)
        //    {
        //        level1 = new LevelsVM();
        //        level1.Level1ID = item.Level1ID;
        //        level1.Description = item.Level1Desc;
        //        levelsVMs.Add(level1);
        //        await GetChildLevels(2, item.Level1ID, 0, 0);
        //    }

        //}

        #endregion
    }
}
