using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NHibernate;
namespace DAL
{
    public class DALOperationLog : DalBase<OperationLog>
    {


        const string whereBegin = "select ol from OperationLog ol where 1=1 ";
        /// <summary>
        /// 容纳所有条件的查询, 其余的简单查询都应使用此方法.
        /// </summary>
        /// <returns></returns>
        public IList<OperationLog> GetList(OperationType? type, TourMembership member, string targetid,
            DateTime? beginTime, DateTime? endTime, string content, bool needPaging, int pageIndex, int pageSize, out int totalRecords
            )
        {
            string condtions = string.Empty;

            if (type.HasValue)
            {
                condtions += " and ol.OprationType=" + (int)type.Value;
            }
            if (member!=null)
            {
                condtions += " and ol.Member.Id='" + member.Id + "'";
            }
            if (!string.IsNullOrEmpty(targetid))
            {
                condtions += " and ol.TargetId='" + targetid + "'";
            }
            if (beginTime.HasValue)
            {
                condtions += " and ol.OperationTime>=" + beginTime.Value;
            }
            if (endTime.HasValue)
            {
                condtions += " and ol.OperationTime<=" + endTime.Value;
            }
            if (!string.IsNullOrEmpty(content))
            {
                condtions += " and ol.content='" + content + "'";
            }


            return GetList(BuildWhere(condtions), needPaging, pageIndex, pageSize, out totalRecords);

        }

        public IList<OperationLog> GetList_DptOprationForEnt(int enterpriseId)
        {
            int totalRecords;
            return GetList(OperationType.管理部门管理纳入企业,
                null, enterpriseId.ToString(), null, null,
                null, false, 0, 0, out totalRecords);

        }





        private string BuildWhere(string condtions)
        {
            return whereBegin + condtions;
        }
    }
}
