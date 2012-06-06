using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IBackManager
    {

        #region 景区相关

        /// <summary>
        /// 获得景区列表--条件
        /// </summary>
        /// <returns></returns>
        List<Model.Scenic> GetScenicList(string strCondition);
        /// <summary>
        /// 获得景区信息--分页
        /// </summary>
        /// <param name="strCondition">条件</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        List<Model.Scenic> GetScenicList(string strCondition, int pageIndex, int pageSize,out long totalRecord);
        /// <summary>
        /// 景区信息通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ScenicinfoPass(int id);

        #endregion

        #region 投票相关

        /// <summary>
        /// 获取条件选择推广列表
        /// </summary>
        /// <returns></returns>
        List<Model.PromotionStatic> GetPromList(string strCondition);

        /// <summary>
        /// 获取条件选择推广列表
        /// </summary>
        /// <param name="strCondition">条件</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalRecord">总数量</param>
        /// <returns></returns>
        List<Model.PromotionStatic> GetPromList(string strCondition, int pageIndex, int pageSize, out long totalRecord);

        /// <summary>
        /// 添加合法推广连接
        /// </summary>
        /// <param name="id"></param>
        void AddProm(Model.PromotionStatic prom);

        #endregion

    }
}
