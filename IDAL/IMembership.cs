using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IMembership
    {
        //创建用户
        int CreateUser(Model.User user);

        //验证用户
        bool ValidateUser(string username, string password);
       
        //创建更新membership
        void CreateUpdateMember(Model.TourMembership member);
       
        //获得所有的membership
        IList<Model.TourMembership> GetAllUsers();

        //分页获得所有的membership
        IList<Model.TourMembership> GetAllUsers(int pageIndex,int pageSize,out long totalRecord);

        //通过usertype获得membership
      
        //通过username获取membership
        Model.TourMembership GetMemberByName(string username);
        
        //通过openid和opentype获取membership
        Model.TourMembership GetMemberByOpenid(string openid,Model.Opentype opentype);

        //通过guid获取membership
        Model.TourMembership GetMemberById(Guid memberId);

        //更新景区管理员
        void UpdateScenicAdmin(Model.ScenicAdmin model);

        Model.ScenicAdmin GetScenicAdmin(Guid id);
        IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid);
        IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid,string code);
        void DeleteScenicAdmin(Model.ScenicAdmin sa);
        
        //更改密码
        void ChangePassword(Model.TourMembership member);
        //更改信息
        void ChangeInfo(Model.TourMembership member);
    }
}
