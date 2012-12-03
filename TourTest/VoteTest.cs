using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model;
using BLL;
namespace TourTest
{
[TestFixture]
public class VoteTest
{
    DAL.DALVote dalVote =new  DAL.DALVote();
    IDAL.IUserVoteAmount dalUserVoteAmount = new DAL.DALUserVoteAmount();
    Guid memberId = new Guid("98A2FB80-3F7A-420D-89C0-A02000E258A9");
    Model.Scenic scenic = new Model.Scenic()
    {
        Id = 83,
        Name = "雁荡山风景区",
        Address = "浙江省温州市永嘉县",
        Level = "5A",
        Photo = "",
        ScenicOrder = 1,
        
        //ActiveTime = "9:00-18:00"
    };
          

    /// <summary>
    /// 获取选票
    /// </summary>
    //[Test]
    public void EarnVotes()
    {
            
        long votesAmount1 = dalUserVoteAmount.GetTotalAmount(memberId);
        TourMembership u = new TourMembership();
        u.Id = memberId;

        //1 赢得选票
        UserVoteAmount uservote = new UserVoteAmount();
        uservote.Amount = 4;
        uservote.EarnDate = DateTime.Now;
        uservote.EarnWay = EarnWay.BuyDigitalCard;
        uservote.User = u;
        dalUserVoteAmount.EarnVote(uservote);

        //2 获得总票数
        long votesAmount2 = dalUserVoteAmount.GetTotalAmount(memberId);
        Assert.AreEqual(votesAmount1 + 4, votesAmount2);

        
    }

    [Test]
    public void Vote()
    {
           
           
        //给景点投票

        Vote vote = new Vote();
        vote.IdCard = "1234";
        vote.Num = 15;
        vote.Scenic = scenic;
        vote.Time = DateTime.Now;
        vote.TourMembershipId = memberId;
        vote.Type = "网站投票";

        //拥有的总票数
        long usertotalvotes = dalUserVoteAmount.GetTotalAmount(memberId);
        Console.WriteLine("用户拥有的总票数"+usertotalvotes);

        long usertotalvotes_used = dalVote.GetVotedAmount(memberId);
        Console.WriteLine("用户已经投掉的票数" + usertotalvotes_used);
       
           

        dalVote.SaveVote(vote);
        Console.WriteLine("投票");
        long usertotalvotes_used2 = dalVote.GetVotedAmount(memberId);
        Console.WriteLine("用户已经投掉的票数" + usertotalvotes_used2);



            

    }
    //正常情况下的投票
    //[Test]
    public void VoteWithLimited()
    {
        BLL.BLLVote bllVote = new BLLVote();
        bllVote.Vote(memberId, "123", scenic, 1, "votetype", DateTime.Now, "我喜欢这个地方", true);
    }
    //[Test]
    public void GetVoteAmount()
    {
        long amount = dalVote.GetScenicVoteAmount(83, true);
        Assert.AreEqual(3, amount);
        amount = dalVote.GetScenicVoteAmount(83, false);
        Assert.AreEqual(3, amount);
    }
    [Test]
    public void GetHotvote()
    {
        dalVote.GetScenicsByVote("33");//浙江省
    }
    [Test]
    public void GetTotalAmount()
    {
        dalUserVoteAmount.GetTotalAmount(new Guid("6db916d9-43fe-42d6-93c1-a03701209f0d"));
    }
    [Test]
    public void GetVoteSource()
    { 
        int totalRecord;
        dalUserVoteAmount.GetVoteSource(new Guid("98A2FB80-3F7A-420D-89C0-A02000E258A9"), 1, 10, out totalRecord);
    }
}
}

