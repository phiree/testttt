using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_StaticsDetail : System.Web.UI.Page
{
    string enterp_name = string.Empty;
    BLL.BLLDJConsumRecord bllrecord = new BLL.BLLDJConsumRecord();
    BLL.BLLDJEnterprise bllenterp = new BLL.BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
        enterp_name = Request.QueryString[0] == null ? string.Empty : Request.QueryString[0];
        BindData();
    }

    private void BindData()
    {
        IList<Model.DJ_GroupConsumRecord> recordList = bllrecord.GetGCR8Multi(null, enterp_name, null, null);
        IList<statics_detail> sdlist = new List<statics_detail>();
        statics_detail sd = null;
        IList<statics_enterpeople> hotellist = new List<statics_enterpeople>();
        IList<statics_enterpeople> sceniclist = new List<statics_enterpeople>();

        foreach (var item in recordList.GroupBy(x=>(x.ConsumeTime.Year.ToString()+
            x.ConsumeTime.Month.ToString()+
            x.ConsumeTime.Day.ToString())))
        {
            sd = new statics_detail();
            sd.ConsumeDate = item.Key;
            //添加宾馆
            foreach (var item2 in item
                .Where(x=>x.Enterprise.Type==Model.EnterpriseType.宾馆)
                .GroupBy(y=>y.Enterprise.Name))
            {
                sd.HotelList.Add(new statics_enterpeople() {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                });
            }
            //添加景区

            foreach (var item2 in item
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
                .GroupBy(y => y.Enterprise.Name))
            {
                sd.HotelList.Add(new statics_enterpeople()
                {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                });
            }
        }
        //绑定数据
       
    }
}

class statics_detail
{
    public string ConsumeDate { get; set; }
    public IList<statics_enterpeople> HotelList { get; set; }
    public IList<statics_enterpeople> ScenicList { get; set; }
}

class statics_enterpeople
{
    public Model.DJ_TourEnterprise Enterprice { get; set; }
    public int Peoplenum { get; set; }
}