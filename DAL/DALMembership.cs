using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALMembership : IDAL.IMembership
    {
        ISession session = new HybridSessionBuilder().GetSession();

        public int CreateUser(Model.TourMembership user)
        {
            return (int)session.Save(user);
        }

        public void CreateUpdateMember(Model.TourMembership member)
        {

            session.SaveOrUpdate(member);
            session.Flush();
        }

        public bool ValidateUser(string username, string password)
        {
            //  User user = session.QueryOver<User>(x=>x.User);
            bool result = false;
            IQuery query = session.CreateQuery("select u from TourMembership as u where u.Name='" + username + "' and u.Password='" + password + "'");
            int matchLength = query.Future<Model.TourMembership>().ToArray().Length;

            if (matchLength == 1) { result = true; }

            return result;
        }

        public Model.TourMembership GetMemberByName(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;
            IQuery query = session.CreateQuery("select m from  TourMembership as m where Name='" + username + "'");
            Model.TourMembership user = query.FutureValue<Model.TourMembership>().Value;
            return user;
        }

        public Model.TourMembership GetMemberByOpenid(string openid, Model.Opentype opentype)
        {
            IQuery query = session.CreateQuery("select m from  TourMembership as m where Openid='" + openid + "' and Opentype=" + (int)opentype);
            Model.TourMembership user = query.FutureValue<Model.TourMembership>().Value;
            return user;
        }

        public Model.TourMembership GetMemberById(Guid memberId)
        {
            IQuery query = session.CreateQuery("select m from  TourMembership as m where Id='" + memberId + "'");
            Model.TourMembership member = query.FutureValue<Model.TourMembership>().Value;
            return member;
        }

        public IList<Model.TourMembership> GetAllUsers()
        {
            IQuery query = session.CreateQuery("select u from TourMembership u ");
            return query.Future<Model.TourMembership>().ToList();
        }

        public IList<Model.TourMembership> GetAllUsers(int pageIndex, int pageSize, out long totalRecord)
        {
            IQuery qry = session.CreateQuery("select u from TourMembership u ");
            IQuery qryTotal = session.CreateQuery("select count(*) from TourMembership u ");
            List<Model.TourMembership> memList = qry.Future<Model.TourMembership>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            totalRecord = qryTotal.FutureValue<long>().Value;
            return memList;
        }

        public void UpdateScenicAdmin(Model.ScenicAdmin model)
        {
            session.SaveOrUpdate(model);
            session.Flush();
        }
        public Model.ScenicAdmin GetScenicAdmin(Guid id)
        {
            IQuery query = session.CreateQuery("select sa from ScenicAdmin sa where sa.Membership.Id='" + id + "'");
            IFutureValue<Model.ScenicAdmin> sa = query.FutureValue<Model.ScenicAdmin>();
            if (sa == null) return null;
            return sa.Value;
        }


        public IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid)
        {
            string sqlQuery = "select sa from ScenicAdmin sa ";
            if (scenicid > 0)
                sqlQuery += " where sa.Scenic.Id=" + scenicid + "and IsDisabled=0";
            IQuery query = session.CreateQuery(sqlQuery);
            return query.Future<Model.ScenicAdmin>().ToList<Model.ScenicAdmin>();
        }

        public IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid, string code)
        {
            string sqlQuery = "select sa from ScenicAdmin sa where sa.Scenic.Area.Code='" + code + "' and IsDisabled=0";
            if (scenicid > 0)
                sqlQuery += " and sa.Scenic.Id=" + scenicid;
            IQuery query = session.CreateQuery(sqlQuery);
            return query.Future<Model.ScenicAdmin>().ToList<Model.ScenicAdmin>();
        }

        public void DeleteScenicAdmin(Model.ScenicAdmin sa)
        {
            session.Delete(sa);
            session.Flush();
        }

        public void ChangePassword(Model.TourMembership member)
        {
            using (var x = session.Transaction)
            {
                x.Begin();
                session.Update(member);
                x.Commit();
            }

        }


        public void ChangeInfo(Model.TourMembership member)
        {
            using (var x = session.Transaction)
            {
                x.Begin();
                session.Update(member);
                x.Commit();
            }
        }
    }
}
