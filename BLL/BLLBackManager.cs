using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLBackManager : BLLMembership
    {
        IDAL.IBackManager dalbackmanager = new DAL.DALBackManager();


        #region 景区相关
        public IList<Model.Scenic> GetScenicList(string strCondition)
        {
            return dalbackmanager.GetScenicList(strCondition);    
        }
        public List<Model.Scenic> GetScenicList(string strCondition, int pageIndex, int pageSize ,out long totalRecord)
        {
            return dalbackmanager.GetScenicList( strCondition,  pageIndex,  pageSize , out totalRecord);
        }
        public bool ScenicinfoPass(int id)
        {
            return dalbackmanager.ScenicinfoPass(id);
        }
        #endregion

        #region 投票相关

        public IList<Model.PromotionStatic> GetPromList(string strCondition)
        {
            return dalbackmanager.GetPromList(strCondition);
        }

        public IList<Model.PromotionStatic> GetPromList(string strCondition, int pageIndex, int pageSize ,out long totalRecord)
        {
            return dalbackmanager.GetPromList(strCondition, pageIndex, pageSize, out totalRecord);
        }

        public void AddProm(Model.PromotionStatic prom)
        {
            dalbackmanager.AddProm(prom);
        }
        #endregion
    }
}
