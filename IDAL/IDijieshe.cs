using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDijieshe
    {
        #region djs
        Guid AddDJS(Model.DJ_TourEnterprise djs);

        void DeleteDJS();

        void UpdateDJS();

        IList<Model.DJ_DijiesheInfo> GetDJS8All();

        IList<Model.DJ_DijiesheInfo> GetDJS8Muti(int areaid, string type, string id, string namelike);

        #endregion

        #region group

        Guid AddGroup(Model.DJ_TourGroup tg);

        void UpdateGroup(Model.DJ_TourGroup tg);

        Model.DJ_TourGroup GetGroup8name(string name);

        Model.DJ_TourGroup GetGroup8gid(string groupid);

        IList<Model.DJ_TourGroup> GetGroup8all();

        #endregion
    }
}
