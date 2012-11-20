using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;
using Model;
namespace DAL
{
    public class DALDJTourGroup:DalBase<Model.DJ_TourGroup>
    {
   public IList<Model.DJ_TourGroup> GetTourGroupByAll()
   {
       return GetAll<Model.DJ_TourGroup>();
      
   }

   public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
   {
       string sql = "select tg from DJ_TourGroup tg where tg.GuideIdCardNo='" + idcard + "'";
       sql += " and '"+DateTime.Now.ToString()+"' between begindate and enddate";
       IQuery query = session.CreateQuery(sql);
       return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
   }
   public Model.DJ_TourGroup GetTourGroupById(Guid id)
   {
       return GetOne(id);
   }
   public IList<Model.DJ_TourGroup> GetTourGroupByTEId(int id)
   {
       List<Model.DJ_Route> list_route = new DALDJ_Route().GetRouteByTEid(id).ToList();
       List<Model.DJ_TourGroup> ListTg = new List<Model.DJ_TourGroup>();
       foreach (Model.DJ_Route route in list_route)
       {
           if (route.DJ_TourGroup.BeginDate.AddDays(route.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString())
           {
               ListTg.Add(route.DJ_TourGroup);
           }
       }
       return ListTg;
   }
   public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
   {
       List<Model.DJ_TourGroup> ListTg = new DAL.DALDJ_Group_Worker().GetTgListByIdcard(idcard).ToList();
       List<Model.DJ_TourGroup> ListSelectTg = new List<Model.DJ_TourGroup>();
       foreach (Model.DJ_TourGroup Tgitem in ListTg)
       {
           if (Tgitem.Routes.Where(x => x.Enterprise.Id == TE.Id).Count() > 0)
           {
               ListSelectTg.Add(Tgitem);
           }
       }
       return ListSelectTg;
   }

   //todo:codeview 业务逻辑不要放在dal层. dal 只是做 单纯的 数据库操作.
   public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
   {
       DAL.DALDJ_Route route = new DALDJ_Route();
       IList<Model.DJ_Route> ListRoute= route.GetRouteByTEid(TE.Id);
       List<Model.DJ_Group_Worker> Listgw = new List<Model.DJ_Group_Worker>();
       foreach (Model.DJ_Route routeitem in ListRoute)
       {
           if (routeitem.DJ_TourGroup.BeginDate.AddDays(routeitem.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString())
           {
               Listgw.AddRange(routeitem.DJ_TourGroup.Workers);
           }
       }
       return Listgw;
   }
   public IList<DJ_TourGroup> GetList(int dijiesheId
             , string name, bool isNameLike, string editorName
       
             )
   { 
       int totalRecord;
       return GetList(dijiesheId, name, isNameLike, editorName, 0, 9999, out totalRecord);
   }
   /// <summary>
   /// 通用查询 不包含对 list子对象的查询
   /// </summary>
   /// <param name="dijiesheId">地接社ID</param>
   /// <param name="name">名称</param>
   /// <param name="isNameLike">相似名称或精确名称</param>
 
   /// <param name="editorName">地接社编辑者的帐号</param>
   /// <param name="pageIndex">分页</param>
   /// <param name="pageSize"></param>
   /// <param name="totalRecord"></param>
   /// <returns></returns>
   public IList<DJ_TourGroup> GetList(int dijiesheId
       ,string name,bool isNameLike,  string editorName
    ,int pageIndex,int pageSize,out int totalRecord
       )
   {
       string where="select TG from DJ_TourGroup as TG where 1=1 ";
       string conditions = string.Empty;
       if (dijiesheId >0)
       {
           conditions += " and TG.DJ_DijiesheInfo.Id=" + dijiesheId;
       }
       if (!string.IsNullOrEmpty(name))
       {
           if (isNameLike)
           {
               conditions += " and TG.Name like '%" + name + "%'";
           }
           else
           { 
            conditions+=" and TG.Name = '"+name+"'";
           }
       }
       
       if (!string.IsNullOrEmpty(editorName))
       {
           conditions += " and TG.DijiesheEditor.Name ='" + editorName + "'";
       }
       where=where+conditions;
       return GetList(where, pageIndex, pageSize, out totalRecord);
   }

<<<<<<< HEAD
=======
        //todo:codeview 业务逻辑不要放在dal层. dal 只是做 单纯的 数据库操作.
        public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
        {
            DAL.DALDJ_Route route = new DALDJ_Route();
            IList<Model.DJ_Route> ListRoute= route.GetRouteByTEid(TE.Id);
            List<Model.DJ_Group_Worker> Listgw = new List<Model.DJ_Group_Worker>();
            foreach (Model.DJ_Route routeitem in ListRoute)
            {
                if (routeitem.DJ_TourGroup.BeginDate.AddDays(routeitem.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    Listgw.AddRange(routeitem.DJ_TourGroup.Workers);
                }
            }
            return Listgw;
        }
        public IList<DJ_TourGroup> GetList(int dijiesheId
                  , string name, bool isNameLike, string editorName
            
                  )
        { 
            int totalRecord;
            return GetList(dijiesheId, name, isNameLike, editorName, 0, 9999, out totalRecord);
        }
        /// <summary>
        /// 通用查询 不包含对 list子对象的查询
        /// </summary>
        /// <param name="dijiesheId">地接社ID</param>
        /// <param name="name">名称</param>
        /// <param name="isNameLike">相似名称或精确名称</param>
      
        /// <param name="editorName">地接社编辑者的帐号</param>
        /// <param name="pageIndex">分页</param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        public IList<DJ_TourGroup> GetList(int dijiesheId
            ,string name,bool isNameLike,  string editorName
         ,int pageIndex,int pageSize,out int totalRecord
            )
        {
            string where="select TG from DJ_TourGroup as TG where 1=1 ";
            string conditions = string.Empty;
            if (dijiesheId >0)
            {
                conditions += " and TG.DJ_DijiesheInfo.Id=" + dijiesheId;
            }
            if (!string.IsNullOrEmpty(name))
            {
                if (isNameLike)
                {
                    conditions += " and TG.Name like '%" + name + "%'";
                }
                else
                { 
                 conditions+=" and TG.Name = '"+name+"'";
                }
            }
            
            if (!string.IsNullOrEmpty(editorName))
            {
                conditions += " and TG.DijiesheEditor.Name ='" + editorName + "'";
            }
            where=where+conditions;
            return GetList(where, pageIndex, pageSize, out totalRecord);
        }
        public override void Save(DJ_TourGroup o)
        {
             o.LastUpdateTime = DateTime.Now;
            base.Save(o);
        }
>>>>>>> 3c47c6f56428a27d52e9e0d410aede14e6057a12
    }
}
