using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 投票情况查看
/// 自己所投景区的当前票数 以及最终结果.
/// </summary>
public partial class UserCenter_MyVote : basepage
{
    BLLVote bllVote = new BLLVote();
    BLLUserVoteAmount bllVoteamount = new BLLUserVoteAmount();
    public Vote VoteInfo;
    public long TotalVotes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVoted();
            BindGot();
        }
    }

    private void BindGot()
    {
        int pageIndex = GetGotPageIndex();
        int totalRecord;
        IList<UserVoteAmount> gots = bllVoteamount.GetVoteSource(new Guid(CurrentUser.ProviderUserKey.ToString()), pageIndex, 10, out totalRecord);
        pagerGot.RecordCount = totalRecord;
        rptGot.DataSource = gots;
        rptGot.DataBind();
    }

    private int GetGotPageIndex()
    {
        string paramPageIndex = Request[pagerGot.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }

    private void BindVoted()
    {
        int pageIndex = GetVotedPageIndex();
        int totalRecord;
        IList<Vote> votes = bllVote.GetUserVote(new Guid(CurrentUser.ProviderUserKey.ToString()),pageIndex,10,out totalRecord);
        pagerVoted.RecordCount = totalRecord;
        rptVoted.DataSource = votes;
        rptVoted.DataBind();
        lblTotalVotes.Text = bllVote.GetUserTotalAmount(new Guid(CurrentUser.ProviderUserKey.ToString())).ToString();
        lblUsedVotes.Text = bllVote.GetUserVotedAmount(new Guid(CurrentUser.ProviderUserKey.ToString())).ToString();
    }

    private int GetVotedPageIndex()
    {
        string paramPageIndex = Request[pagerVoted.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
}
