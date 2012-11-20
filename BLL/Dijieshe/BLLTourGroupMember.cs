using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    public class BLLTourGroupMember
    {
        private DALDJTourGroupMember dalMember;
        public DALDJTourGroupMember DalMember
        {
            get
            {
                if (dalMember == null)
                {
                    dalMember = new DALDJTourGroupMember();
                }
                return dalMember;
            }
            set { dalMember = value; }
        }

        public void SaveOrUpdate(Model.DJ_TourGroupMember member)
        {
            DalMember.SaveOrUpdate(member);
        }
        public Model.DJ_TourGroupMember GetOne(Guid id)
        {
            return DalMember.GetOne(id);
        }
        public void Delete(Model.DJ_TourGroupMember member)
        {
            DalMember.Delete(member);
        }

        /// <summary>
        /// 对象生成字符串,用于直接录入.
        /// </summary>
        /// <param name="members"></param>
        public string GenerateSimpleStrings(IList<DJ_TourGroupMember> members)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Model.DJ_TourGroupMember member in members)
            {
                string singleString = GenerateSimpleString(member);

                sb.AppendLine(singleString);
            }
         return sb.ToString();
        }

        private string GenerateSimpleString( DJ_TourGroupMember member)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(member.MemberType);
            sb.Append("\\");
            sb.Append(member.RealName);
            sb.Append("\\");

            if (!string.IsNullOrEmpty(member.IdCardNo))
            {
                sb.Append(member.IdCardNo);
                sb.Append("\\");
            }
            if (!string.IsNullOrEmpty(member.SpecialCardNo))
            {
                sb.Append(member.SpecialCardNo);

                sb.Append("\\");
            }
            sb.Append(member.PhoneNum);

            return sb.ToString();
            
        }
    }
}
