using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

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

        public void Save(IList<string> topicname, int scenicid)
        {
            Iticket.Save(topicname, scenicid);
        }

        public IList<Model.ScenicTopic> GetScenicTopics(string areacode)
        {
            return Iticket.GetScenictopic(areacode);
        }

        public IList<Model.ScenicTopic> GetStByscid(int scid)
        {
            return Iticket.GetStByscid(scid);
        }

        public IList<Topic> GetTopicByName(string name)
        {
            return Iticket.GetTopicByName(name);
        }

        public IList<Model.Topic> GetTopicByscid(int scid)
        {
            return Iticket.GetTopicByscid(scid);
        }

        public IList<Model.Topic> GetAllTopics()
        {
            return Iticket.GetAllTopics();
        }
    }
}
