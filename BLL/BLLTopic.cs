using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLTopic
    {
        private IDAL.ITopic itopic;
        public IDAL.ITopic Iticket
        {
            get
            {
                if (itopic == null)
                {
                    itopic = new DAL.DALTopic();
                }
                return itopic;
            }
            set { itopic = value; }
        }

        public IList<Model.ScenicTopic> GetScenicTopics(string areacode)
        {
            return itopic.GetScenictopic(areacode);
        }
    }
}
