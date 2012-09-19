using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDijieshe : DalBase,IDAL.IDijieshe
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_DijiesheInfo> GetDJS8All()
        {
            string sql = "select D from DJ_DijiesheInfo D";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_DijiesheInfo>().ToList<Model.DJ_DijiesheInfo>();
        }


        public IList<Model.DJ_DijiesheInfo> GetDJS8name()
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_DijiesheInfo> GetDJS8area(int areaid)
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_DijiesheInfo> GetDJS8type(string type)
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_DijiesheInfo> GetDJS8name(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_DijiesheInfo> GetDJS8Muti(int areaid, string type, string namelike)
        {
            string sql = "select D from DJ_DijiesheInfo D where ";
            if (areaid != 0)
            {
                sql += "D.Area.Id=" + areaid + " and ";
            }
            if (string.IsNullOrEmpty(type))
            {
                sql += "D.";
            }
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_DijiesheInfo>().ToList<Model.DJ_DijiesheInfo>();
        }
    }
}
