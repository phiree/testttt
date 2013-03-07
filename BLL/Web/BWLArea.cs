using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Web
{
    public class BWLArea
    {
        DAL.Adodal.AdoArea iarea;

        public DAL.Adodal.AdoArea DalArea
        {
            get
            {
                if (iarea == null)
                {
                    iarea = new DAL.Adodal.AdoArea();
                }
                return iarea;
            }
            set { iarea = value; }
        }

        /// <summary>
        /// 根据seoname查询area
        /// </summary>
        /// <param name="seoName">seoname</param>
        /// <returns>area实体</returns>
        public Model.Area GetAreaBySeoName(string seoName)
        {
            return DalArea.GetAreaBySeoName(seoName);
        }
    }
}
