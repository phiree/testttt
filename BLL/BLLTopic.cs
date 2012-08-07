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

        public void SaveTopic(string topicname)
        {
            Iticket.SaveTopic(topicname);
        }

        public void SaveScenictopic(IList<string> topicname, int scenicid)
        {
            Scenic s = new BLL.BLLScenic().GetScenicById(scenicid);
            Iticket.SaveScenictopic(topicname, s);
        }

        public void UpdateTopic(Topic topic)
        {
            Iticket.UpdateTopic(topic);
        }

        public IList<Model.ScenicTopic> GetScenicTopics(string areacode)
        {
            return Iticket.GetScenictopic(areacode);
        }

        public IList<Model.ScenicTopic> GetStByscid(int scid)
        {
            return Iticket.GetStByscid(scid);
        }

        public Topic GetTopicByName(string name)
        {
            return Iticket.GetTopicByName(name);
        }

        public Topic GetTopicBySeoname(string seoname)
        {
            return Iticket.GetTopicBySeoname(seoname);
        }

        public IList<Model.Topic> GetTopicByscid(int scid)
        {
            return Iticket.GetTopicByscid(scid);
        }

        public IList<Model.Topic> GetAllTopics()
        {
            return Iticket.GetAllTopics();
        }
        public IList<ScenicTopic> GetStByTopicid(Guid topid)
        {
            return Iticket.GetStByTopicid(topid);
        }
        public void DelTopic(Topic topic)
        {
            Iticket.DelTopic(topic);
        }
    }
}
