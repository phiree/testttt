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
            return GetGroupsForEditor(editorName);
        }
        public IList<Model.DJ_TourGroup> GetGroupsForEditor(string editorName)
        {
            

            return Idjtourgroup.GetList(Guid.Empty, string.Empty, false, null, null, DateTime.Now, DateTime.Now.AddYears(99),editorName);
        }

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            return Idjtourgroup.GetTourGroupByGuideIdcard(idcard);
        }

        
        public IList<Model.DJ_Group_Worker> GetTourGroupByTEId(int id)
        {
            List<Model.DJ_TourGroup> listTg = Idjtourgroup.GetTourGroupByTEId(id).ToList();
            List<Model.DJ_Group_Worker> listGw = new List<Model.DJ_Group_Worker>();
            List<Model.DJ_Group_Worker> listGw2 = new List<Model.DJ_Group_Worker>();
            foreach (Model.DJ_TourGroup tg in listTg)
            {
                listGw.AddRange(tg.Workers.Where(x => x.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>());
            }
            foreach (Model.DJ_Group_Worker item in listGw)
            {
                if (listGw2.Where(x => x.IDCard == item.IDCard).Count() == 0)
                {
                    listGw2.Add(item);
                }
            }
            return listGw2;

        }
       

        /// <summary>
        /// 查找当天的团队
        /// </summary>
        /// <param name="idcard">导游身份证号</param>
        /// <param name="TE">管理部门</param>
        /// <returns></returns>
        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
        {
            List<Model.DJ_TourGroup> ListTg = Idjtourgroup.GetTgByIdcardAndTE(idcard, TE).ToList();
            List<Model.DJ_TourGroup> ListTyTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup Tg in ListTg)
            {
                DateTime dtBegin = Tg.BeginDate;
                foreach (Model.DJ_Route route in Tg.Routes)
                {
                    if (dtBegin.AddDays(route.DayNo - 1).ToShortDateString() == DateTime.Now.ToShortDateString() && route.Enterprise.Id == TE.Id)
                    {
                        ListTyTg.Add(Tg);
                    }
                }
            }
            return ListTyTg;
        }
        /// <summary>
        /// 查找当天该景区的导游信息
        /// </summary>
        /// <param name="TE"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
        {
            return Idjtourgroup.GetGuiderWorkerByTE(TE).Where(x => x.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameLike"></param>
        /// <returns></returns>
       
        public void DeleteDemoGroups(string nameLike)
        {
          IList<DJ_TourGroup> demoGroups= Idjtourgroup.GetList(Guid.Empty, nameLike, true, null, null, null, null, string.Empty);
          //DJ_TourGroup[] arrGroups = new DJ_TourGroup[] { };
          //demoGroups.CopyTo(arrGroups, 0);
          //for (int i = 0; i < arrGroups.Length;i++ )
          //{
          //    Delete(demoGroups[i]);
          //}
          foreach (DJ_TourGroup g in demoGroups)
          {
              Delete(g);
          }
        }
        public void Delete(DJ_TourGroup group)
        {
            Idjtourgroup.Delete(group);
        }
        public void Save(Model.DJ_TourGroup group)
        {
            Idjtourgroup.Save(group);
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
            string[] arrStrMember = formatedString.Split(Environment.NewLine.ToCharArray());
            IList<DJ_TourGroupMember> members = new List<DJ_TourGroupMember>();
            foreach (string s in arrStrMember)
            {
                if (string.IsNullOrEmpty(s)) continue;
                string singleErr;
                DJ_TourGroupMember newMember = SerializationModel.SerializeMember(s, out singleErr);
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
