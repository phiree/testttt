using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ado;
using Model;
using DB.Helper;

namespace DAL.Adodal
{
    public class AdoArea
    {
        NativeSqlUtiliity sqlUtility = new NativeSqlUtiliity(null);

        public Area GetAreaBySeoName(string seoName)
        {
            string sql = "select top 1 Id,Name,SeoName,Code,AreaOrder,MetaDescription from Area a where a.seoname=:seoname";
            var ds = DBHelper.ReturnDataSet(sql);
            if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count < 1) return null;
            var dt = ds.Tables[0];
            return new Area(){
                Id = int.Parse(dt.Rows[0][0].ToString()),
                Name = dt.Rows[0][1].ToString(),
                SeoName = dt.Rows[0][2].ToString(),
                Code = dt.Rows[0][3].ToString(),
                AreaOrder = int.Parse(dt.Rows[0][4].ToString()),
                MetaDescription = dt.Rows[0][5].ToString()
            };
        }
    }
}
