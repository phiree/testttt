using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ITopic
    {
        IList<Model.ScenicTopic> GetScenictopic(string areacode);
        void SaveTopic(string topicname);
        void SaveTopic(List<string> topicnames);
        void UpdateTopic(Topic topic);
        void SaveScenictopic(IList<string> topicname, Scenic scenic);
        IList<ScenicTopic> GetStByscid(int scid);
        IList<Topic> GetTopicByscid(int scid);
        IList<Model.Topic> GetAllTopics();
        Topic GetTopicByName(string name);
        Topic GetTopicBySeoname(string seoname);
        IList<ScenicTopic> GetStByTopicid(Guid topid);
        void DelTopic(Topic topic);
    }
}
