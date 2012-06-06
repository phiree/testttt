using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IScenic
    {
        IList<Scenic> GetScenic();
       Scenic GetScenicById(int scid);
        /// <summary>
        /// 通过areacode获取景区详情
        /// </summary>
        /// <param name="areacode">景区市级areacode</param>
        /// <returns></returns>
        IList<Scenic> GetScenicByAreacode(string areacode);
        Scenic GetScenicBySeoName(string seoName);
        Scenic GetScrnicByUserName(string username);
        void UpdateScenicInfo(Scenic scenic);
        void UpdateScenicInfo(List<Scenic> slist);
        void UploadContractImg(ContractImg contractimg);
        ContractImg GetContractImg(int scenicid);
        IList<Ticket> GetScenicByScenicName(string scenicname,string level,int areaid);
        IList<Ticket> GetScenicByScenicPosition(string position);

        /// <summary>
        /// 获取 scenic 某个功能模块的审核情况
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        ScenicCheckProgress GetStatus(int scenicId, ScenicModule module);
        /// <summary>
        /// 获取 scenic 所有模块的审核情况
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        IList<ScenicCheckProgress> GetStatus(int scenicId);
        /// <summary>
        /// 申请开通功能
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="module"></param>
        void SaveCheckProgress(ScenicCheckProgress progress);
        ScenicCheckProgress GetCheckProgressByscidandmouid(int scid, int module);
        /// <summary>
        /// 更新审核信息
        /// </summary>
        /// <param name="scp"></param>
        void UpdateCheckState(ScenicCheckProgress scp);
        /// <summary>
        /// 保存景区图片
        /// </summary>
        /// <param name="silist"></param>
        void SaveScenicimg(List<ScenicImg> silist);
        /// <summary>
        /// 清空景区图片数据
        /// </summary>
        void DeleteScenicimg();
    }
}
