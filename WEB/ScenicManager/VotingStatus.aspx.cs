using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenticManager_VotingStatus : basepage
{
    BLL.BLLVote bllVote = new BLL.BLLVote();
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.ScenicAdmin user = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Scenic scenic = user.Scenic;
        long getvote=bllVote.GetVoteAmount(scenic.Id);
        voteGet.Text = getvote.ToString();
        voteRank.Text=bllVote.GetScenicVoteRank("33", scenic.Id).ToString();
    }
}