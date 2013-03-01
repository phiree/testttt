using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL.ado;
using DB.Helper;

namespace DAL.Adodal
{
    public class AdoTopic
    {
        NativeSqlUtiliity sqlUtility = new NativeSqlUtiliity(null);

        public Topic GetTopicBySeoname(string seoname)
        {
            string sql = "select top 1 id,name,seoname from Topic t where t.seoname=:seoname";
            var ds = DBHelper.ReturnDataSet(sql);
            if (ds.Tables.Count < 1 ||ds.Tables[0].Rows.Count<1) return null;
            var dt = ds.Tables[0];
            return new Topic() {
                Id = Guid.Parse(dt.Rows[0][0].ToString()),
                Name = dt.Rows[0][1].ToString(),
                seoname = dt.Rows[0][2].ToString()
            };
        }
    }
}
