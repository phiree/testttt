using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
namespace BLL
{
    public class BLLDJTourGroup
    {
      public  DALDJTourGroup Idjtourgroup = new DALDJTourGroup();

        public IList<Model.DJ_TourGroup> GetTourGroupByAll()
        {
            return Idjtourgroup.GetTourGroupByAll();
        }
        public IList<DJ_TourGroup> GetGroupsForDjsAdmin(DJ_User_TourEnterprise djsUser)
        {
            string editorName = djsUser.Name;
            if (djsUser.PermissionType ==( PermissionType.报表查看员 | PermissionType.团队录入员 | PermissionType.信息编辑员 | PermissionType.用户管理员))
            {
                editorName = string.Empty;
            }
            return GetGroupsForEditor(djsUser.Enterprise.Id, editorName);
        }
        public IList<Model.DJ_TourGroup> GetGroupsForEditor(int djsId, string editorName)
        {
            

            return Idjtourgroup.GetList(djsId,string.Empty, false,editorName);
        }

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            return Idjtourgroup.GetTourGroupByGuideIdcard(idcard);
        }


        public IList<Model.DJ_Workers> GetTourGroupByTeId(int id)
        {
            var listTg = Idjtourgroup.GetTourGroupByTEId(id).ToList();
            var listGw = new List<Model.DJ_Group_Worker>();
            var listGw2 = new List<Model.DJ_Group_Worker>();
            List<DJ_Workers> Listdw = new List<DJ_Workers>();
            foreach (var tg in listTg)
            {
                listGw.AddRange(tg.Workers.Where(x => x.DJ_Workers.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>());
            }
            foreach (var item in listGw)
            {
                if (listGw2.Count(x => x.DJ_Workers.IDCard == item.DJ_Workers.IDCard) == 0)
                {
                    listGw2.Add(item);
                }
            }
            foreach (var item in listGw2)
            {
                Listdw.Add(item.DJ_Workers);
            }
            return Listdw;

        }
       

        /// <summary>
        /// 查找当天的团队
        /// </summary>
        /// <param name="idcard">导游身份证号</param>
        /// <param name="te">管理部门</param>
        /// <returns></returns>
        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTe(string idcard, Model.DJ_TourEnterprise te)
        {
            if (te == null) throw new ArgumentNullException("te");
            var listTg = Idjtourgroup.GetTgByIdcardAndTE(idcard, te).ToList();
            var listTyTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup tg in listTg)
            {
                var dtBegin = tg.BeginDate;
                foreach (Model.DJ_Route route in tg.Routes)
                {
                    if (dtBegin.AddDays(route.DayNo - 1).ToShortDateString() == DateTime.Now.ToShortDateString() && route.Enterprise.Id == te.Id)
                    {
                        listTyTg.Add(tg);
                    }
                }
            }
            return listTyTg;
        }
        /// <summary>
        /// 查找当天该景区的导游信息
        /// </summary>
        /// <param name="TE"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
        {
            return Idjtourgroup.GetGuiderWorkerByTE(TE).Where(x => x.DJ_Workers.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>();
        }
        /// <summary>
        /// 删除demo测试数据
        /// </summary>
        /// <param name="nameLike"></param>
        /// <returns></returns>
        BLLDJGroup_Worker bllGW = new BLLDJGroup_Worker();
        public void DeleteDemoGroups(string nameLike)
        {
          var demoGroups= Idjtourgroup.GetList(0, nameLike, true, string.Empty);
          foreach (var g in demoGroups)
          {
              bllGW.DeleteFromGroup(g);
              Delete(g);
          }
        }
        public void Delete(DJ_TourGroup group)
        {
            Idjtourgroup.Delete(group);
        }
        public void Save(Model.DJ_TourGroup group)
        {
            group.LastUpdateTime = DateTime.Now;
            group.EndDate = group.BeginDate.AddDays(group.DaysAmount - 1);
            Idjtourgroup.Save(group);
        }
        BLLDJGroup_Worker bllGroupWorker = new BLLDJGroup_Worker();
        BLLWorker bllWorker = new BLLWorker();
        public bool UpdateForm(DJ_TourGroup CurrentGroup,string groupName,string beginDate,
            string daysAmount, DJ_DijiesheInfo CurrentDJS, DJ_User_TourEnterprise CurrentMember,IList<string> workerIds, out string errMsg)
        {
            errMsg = string.Empty;
            CurrentGroup.Name = groupName;
            CurrentGroup.BeginDate = Convert.ToDateTime(beginDate);
            if (CurrentGroup.BeginDate.DayOfYear < DateTime.Now.DayOfYear)
            {
                errMsg = "开始时间不能小于当天时间";
                return false;
            }
            int iDayAmount=Convert.ToInt32(daysAmount);
            //if (CurrentGroup.DaysAmount>iDayAmount)
            //{
            //    errMsg = string.Format("操作无法完成:当前输入的天数({1})小于已录入行程的天数({0}).为保证数据安全,输入天数应该大于等于已录入行程天数.请修改数字,或者在行程编辑页面删除部分行程.", CurrentGroup.DaysAmount, iDayAmount);
            //    return false;
            //}
            //for (int i = 0; i < iDayAmount; i++)
            //{
                
            //    DJ_Route r = new DJ_Route();
            //    r.DayNo = i + 1;
            //    r.DJ_TourGroup = CurrentGroup;
            //    CurrentGroup.Routes.Add(r);
            //}

            CurrentGroup.DaysAmount = iDayAmount;
            CurrentGroup.EndDate = CurrentGroup.BeginDate.AddDays(CurrentGroup.DaysAmount - 1);
            CurrentGroup.DJ_DijiesheInfo = CurrentDJS;
            CurrentGroup.DijiesheEditor = (DJ_User_TourEnterprise)CurrentMember;
            ///司机和导游
            bool hasSelectGuide = false;
            bool hasSelectDriver = false;
            bllGroupWorker.DeleteFromGroup(CurrentGroup);
            IList<DJ_Workers> workers = new List<DJ_Workers>();
            foreach(string workerId in workerIds)
            {
               
                    Model.DJ_Group_Worker gw = new DJ_Group_Worker();
                    hasSelectGuide = true;
                    DJ_Workers worker = bllWorker.GetOne(new Guid(workerId));
                    if (worker.WorkerType == DJ_GroupWorkerType.司机) { hasSelectDriver = true; }
                    if (worker.WorkerType == DJ_GroupWorkerType.导游) { hasSelectGuide = true; }
                    gw.DJ_Workers = worker;
                    gw.DJ_TourGroup = CurrentGroup;

                    gw.RD_WorkerName = worker.Name;
                    gw.RD_WorkerIdCard = worker.IDCard;
                    gw.RD_Phone = worker.Phone;

                    bllGroupWorker.Save(gw);
            }
           
            if (!hasSelectGuide)
            {
                errMsg = "必须指定导游";

                return false;
            }
            if (!hasSelectDriver)
            {
                errMsg = "必须指定司机";

                return false;
            }
            //路线信息

            return true;
        }
        public DJ_TourGroup GetOne(Guid id)
        {
            return Idjtourgroup.GetOne(id);
        }

        public void UpdateMembersFromFormatedString(DJ_TourGroup group, string formatedString,out string totalErrMsg)
        {
            group.Members = GetMemberListFromFormatString(formatedString,out totalErrMsg);
            Save(group);
        }

        public IList<DJ_TourGroupMember> GetMemberListFromFormatString(string formatedString, out string totalErrMsg)
        {
            totalErrMsg = string.Empty;
            var arrStrMember = formatedString.Split(Environment.NewLine.ToCharArray());
            IList<DJ_TourGroupMember> members = new List<DJ_TourGroupMember>();
            foreach (var s in arrStrMember.Where(s => !string.IsNullOrEmpty(s)))
            {
                string singleErr;
                var newMember = SerializationModel.SerializeMember(s, out singleErr);
                if (!string.IsNullOrEmpty(singleErr))
                {
                    totalErrMsg += singleErr + Environment.NewLine;
                    continue;
                }
                members.Add(newMember);
            }
            return members;
        }

        /// <summary>
        /// 将游客列表生成json字符串
        /// </summary>
        /// <param name="memberList"></param>
        /// <param name="fieldsName"></param>
        /// <returns></returns>

        

        

    }
}
