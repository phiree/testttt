using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDJEnterprise
    {
        #region djs
        int AddDJS(Model.DJ_TourEnterprise djs);

        void DeleteDJS();

        void UpdateDJS();

        IList<Model.DJ_TourEnterprise> GetDJS8All();

        IList<Model.DJ_TourEnterprise> GetDJS8Muti(int areaid, string type, string id, string namelike);
        IList<Model.DJ_TourEnterprise> GetDJSInAreas(string areaids);
        #endregion

        #region group

        string AddGroup(Model.DJ_TourGroup tg,out string id);

        void UpdateGroup(Model.DJ_TourGroup tg);

        Model.DJ_TourGroup GetGroup8name(string name);

        Model.DJ_TourGroup GetGroup8gid(string groupid);

        IList<Model.DJ_TourGroup> GetGroup8all();

        #endregion

        #region groupmem

        void UpdateGuide(Model.DJ_Group_Worker gg);

        void UpdateDriver(Model.DJ_Group_Worker gd);

        IList<Model.DJ_Group_Worker> GetGroupmem8epid(string id);

        IList<Model.DJ_Group_Worker> GetGuide8id(string id);

        IList<Model.DJ_Group_Worker> GetDriver8id(string id);
        #endregion
    }
}
