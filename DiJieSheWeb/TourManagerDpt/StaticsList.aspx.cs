using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_StaticsList : System.Web.UI.Page
{
    BLL.BLLDJConsumRecord bllCustomRecord = new BLL.BLLDJConsumRecord();
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();
    public int xuhao_orig = 1;
    public int xuhao_1 = 1;
    public int xuhao_2 = 1;
    public int xuhao_3 = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        //原数据
        rptOrigin.DataSource = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        rptOrigin.DataBind();

        //整理后数据Gov1
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        IList<statics_model> sm1 = new List<statics_model>();
        foreach (var item in gcrlist.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm1.Add(new statics_model()
            {
                Name = item.Key,
                AdultsAmount = item.Sum(x => x.AdultsAmount),
                ChildrenAmount = item.Sum(x => x.ChildrenAmount),
                LiveDays = item.Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay),
                Playnums = item.Sum(x => x.AdultsAmount + x.ChildrenAmount)
            });
        }
        rptGov1.DataSource = sm1;
        rptGov1.DataBind();

        //整理后数据Gov2
        IList<statics_Gov2> sm2 = new List<statics_Gov2>();
        foreach (var item2 in gcrlist.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm2.Add(new statics_Gov2()
            {
                Name = item2.Key,
                AdultsAmount_pre = item2.Sum(x => x.Route.DJ_TourGroup.AdultsAmount),
                ChildrenAmount_pre = item2.Sum(x => x.Route.DJ_TourGroup.ChildrenAmount),
                AdultsAmount_act = item2.Sum(x => x.AdultsAmount),
                ChildrenAmount_act = item2.Sum(x => x.ChildrenAmount)

            });
        }
        rptGov2.DataSource = sm2;
        rptGov2.DataBind();

        //整理后数据Gov3
        IList<Model.DJ_TourGroup> tglist=blltg.GetTourGroupByAll();
        IList<statics_Gov3> sm3 = new List<statics_Gov3>();
        foreach (var item3 in tglist)
        {
            sm3.Add(new statics_Gov3()
            {
                Name = item3.DJ_DijiesheInfo.Name,
                Gname=item3.Name,
                GId=item3.Id.ToString()
            });
        }
        rptGov3.DataSource = sm3;
        rptGov3.DataBind();
    }
}

class statics_model
{
    public string Name { get; set; }
    public int AdultsAmount { get; set; }
    public int ChildrenAmount { get; set; }
    public int LiveDays { get; set; }
    public int Playnums { get; set; }
}

class statics_Gov2
{
    public string Name { get; set; }
    public int AdultsAmount_pre { get; set; }
    public int ChildrenAmount_pre { get; set; }
    public int AdultsAmount_act { get; set; }
    public int ChildrenAmount_act { get; set; }
}

class statics_Gov3
{
    public string Name { get; set; }//地接社名称
    public string GId { get; set; }
    public string Gname { get; set; }//团队名称
    public string Playinfo { get; set; }
}