using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ICommonUser
    {
        CommonUser GetCommonUserByUserIdandidcard(Guid userid, string idcard);
        IList<CommonUser> GetCommonUserByUserIdandidcard(Guid userid);
        void SaveCommonUser(CommonUser commonuser);
        CommonUser Get(Guid userid, string name, string idcard);
        IList<CommonUser> SearchCommonUser(string name);
        void deleteCommonUser(int id);
        CommonUser GetCommonUserByid(int id);
        void updatecu(CommonUser cu);
        IList<CommonUser> GetCommonUserByIdCard(string idcard);
    }
}
