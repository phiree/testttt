using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDijieshe
    {
        #region djs
        Guid AddDJS(string name, string address, Model.Area area, string cpn, string cpp, string phone);

        void DeleteDJS();

        void UpdateDJS();

        IList<Model.DJ_DijiesheInfo> GetDJS8All();

        IList<Model.DJ_DijiesheInfo> GetDJS8name();

        IList<Model.DJ_DijiesheInfo> GetDJS8area(int areaid);

        IList<Model.DJ_DijiesheInfo> GetDJS8type(string type);

        IList<Model.DJ_DijiesheInfo> GetDJS8name(string name);

        IList<Model.DJ_DijiesheInfo> GetDJS8Muti(int areaid, string type, string namelike);

        #endregion

        #region group

        Guid AddGroup(Model.DJ_TourGroup tg);

        void UpdateGroup(Model.DJ_TourGroup tg);

        #endregion
    }
}
