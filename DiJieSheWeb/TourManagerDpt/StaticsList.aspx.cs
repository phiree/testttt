using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_StaticsList : System.Web.UI.Page
{
    BLL.BLLDJConsumRecord bllCustomRecord = new BLL.BLLDJConsumRecord();
    public int xuhao = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null);
        IList<statics_model> sm = new List<statics_model>();
        foreach (var item in gcrlist.GroupBy(x=>x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm.Add(new statics_model() { 
                Name=item.Key,
                AdultsAmount=item.Sum(x=>x.AdultsAmount),
                ChildrenAmount=item.Sum(x=>x.ChildrenAmount),
                LiveDays=item.Sum(x=>x.LiveDay)
            });
        }
        rptGov1.DataSource = sm;
        rptGov1.DataBind();
    }

}

class statics_model
{
    public string Name { get; set; }
    public int AdultsAmount { get; set; }
    public int ChildrenAmount { get; set; }
    public int LiveDays { get; set; }
}