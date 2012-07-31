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
        ScenicTopic GetStByscid(int scid);
        IList<Topic> GetTopicByscid(int scid);
        IList<Model.Topic> GetAllTopics();
        IList<Topic> GetTopicByName(string name);
    }
}
