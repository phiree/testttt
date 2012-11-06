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

        public void UpdateFromFormatString(DJ_TourGroup group, string formatedString, out string errMsg)
        {
            errMsg = string.Empty;
            foreach (DJ_TourGroupMember member in group.Members)
            {
                Delete(member);
            }
            group.Members.Clear();
            string[] arrStrMember = formatedString.Split(Environment.NewLine.ToCharArray());
            //CurrentGroup.Members

            foreach (string s in arrStrMember)
            {
                if (string.IsNullOrEmpty(s)) continue;
                DJ_TourGroupMember newMember = SerializationModel.SerializeMember(s, out errMsg);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    return;
                }
                group.Members.Add(newMember);
            }
        }
    }
}
