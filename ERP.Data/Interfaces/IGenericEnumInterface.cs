
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Data.Interfaces
{
    public interface IGenericEnumInterface<T> where T : Enum
    {
        #region making-same-name-methods-as-initial-IEnumRepository-repository-and-implementation-and-making-own-business-logic-interface-here
     
        int GetIDByString(string enumname);
        string GetStringById(int enumid);
        #endregion
    }
}
