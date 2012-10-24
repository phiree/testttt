using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLDJTourGroup:DalBase
    {
        IDJTourGroup Idjtourgroup = new DALDJTourGroup();

        public IList<Model.DJ_TourGroup> GetTourGroupByAll()
        {
            return Idjtourgroup.GetTourGroupByAll();
        }

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            return Idjtourgroup.GetTourGroupByGuideIdcard(idcard);
        }

        public Model.DJ_TourGroup GetTourGroupById(Guid id)
        {
            return Idjtourgroup.GetTourGroupById(id);
        }

        public IList<Model.DJ_Group_Worker> GetTourGroupByTEId(int id)
        {
            List<Model.DJ_TourGroup> listTg= Idjtourgroup.GetTourGroupByTEId(id).ToList();
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
        public Model.DJ_TourGroup GetTgByproductid(Guid proid)
        {
            return Idjtourgroup.GetTgByproductid(proid);
        }

        /// <summary>
        /// 查找当天的团队
        /// </summary>
        /// <param name="idcard">导游身份证号</param>
        /// <param name="TE">管理部门</param>
        /// <returns></returns>
        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
        {
            List<Model.DJ_TourGroup> ListTg= Idjtourgroup.GetTgByIdcardAndTE(idcard, TE).ToList();
            List<Model.DJ_TourGroup> ListTyTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup Tg in ListTg)
            {
                DateTime dtBegin = Tg.BeginDate;
                foreach (Model.DJ_Route route in Tg.Routes)
                {
                    if (dtBegin.AddDays(route.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString()&&route.Enterprise.Id==TE.Id)
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

        public void Save(Model.DJ_TourGroup group)
        {
            session.Save(group);
            session.Flush();
        }
        public Model.DJ_TourGroupMember GetMemberById(Guid id)
        {
            return session.Get<Model.DJ_TourGroupMember>(id);
        }

        /// <summary>
        /// 将游客列表生成json字符串
        /// </summary>
        /// <param name="memberList"></param>
        /// <param name="fieldsName"></param>
        /// <returns></returns>
        public static string BuildJsonForMemberList(IList<Model.DJ_TourGroupMember> memberList, string[] fieldsName)
        {
            System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
            sbJson.Append("{\\\"data\\\":[");
            foreach (Model.DJ_TourGroupMember member in memberList)
            {

                sbJson.Append("{");
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[0], memberList.IndexOf(member)));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[1], member.TouristType));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[2], member.RealName));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[3], member.PhoneNum));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[4], member.IdCardNo));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\",", fieldsName[5], member.SpecialCardNo));
                sbJson.Append(string.Format("\\\"{0}\\\":\\\"{1}\\\"", fieldsName[6], member.Id));
                sbJson.Append("}");
                if (memberList.IndexOf(member) < memberList.Count - 1)
                {
                    sbJson.Append(",");
                }
            }

            sbJson.Append("],\\\"pageInfo\\\":{\\\"totalRowNum\\\":"+memberList.Count+"},\\\"exception\\\":\\\"\\\"}");
            return sbJson.ToString();
        }

        public static string BuildJsonForMemberList(IList<Model.DJ_TourGroupMember> memberList)
        {
            System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
            sbJson.Append("[");
            foreach (Model.DJ_TourGroupMember member in memberList)
            {

             
              
                sbJson.Append("[\\\"");
                sbJson.Append(member.TouristType); sbJson.Append("\\\",\\\"");
                sbJson.Append(member.RealName); sbJson.Append("\\\",\\\"");
                sbJson.Append(member.PhoneNum); sbJson.Append("\\\",\\\"");
                sbJson.Append(member.IdCardNo); sbJson.Append("\\\",\\\"");
                sbJson.Append(member.SpecialCardNo); sbJson.Append("\\\",\\\"");
                sbJson.Append(member.Id); sbJson.Append("\\\"]");

                if (memberList.IndexOf(member) < memberList.Count - 1)
                {
                    sbJson.Append(",");
                }
            }

            sbJson.Append("]");
            return sbJson.ToString();
        }

    }
}
