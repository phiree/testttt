using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupDetail : System.Web.UI.Page
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        string guid = Request.QueryString[0];
        BindData(guid);
    }

    private void BindData(string guid)
    {
        Model.DJ_TourGroup tg = blltg.GetTourGroupById(Guid.Parse(guid));
        lblGroupno.Text = tg.No;
        lblName.Text = tg.Name;
        lblDate.Text = tg.BeginDate.ToShortDateString() + "-" + tg.EndDate.ToShortDateString();
        lblDays.Text = tg.DaysAmount.ToString();
        lblPnum.Text = (tg.AdultsAmount + tg.ChildrenAmount).ToString();
        lblPadult.Text = tg.AdultsAmount.ToString();
        lblPchild.Text = tg.ChildrenAmount.ToString();
        lblForeigners.Text = tg.ForeignersAmount.ToString();
        lblGether.Text = tg.Gether;
        lblBack.Text = tg.BackPlace;

        rptMem.DataSource = tg.Members;
        rptMem.DataBind();

        rptWorkers.DataSource = tg.Workers;
        rptWorkers.DataBind();

        IList<ExcelOplib.Entity.GroupRoute> grlist = new List<ExcelOplib.Entity.GroupRoute>();
        foreach (var item in tg.Routes.GroupBy(x=>x.DayNo))
        {
            grlist.Add(new ExcelOplib.Entity.GroupRoute() { 
                RouteDate=item.First().DayNo.ToString(),
                Breakfast = item.Where(x => x.Description == "早餐").Count()>0?item.First(x => x.Description == "早餐").Enterprise.Name:string.Empty,
                Lunch = item.Where(x => x.Description == "中餐").Count() > 0 ? item.First(x => x.Description == "中餐").Enterprise.Name : string.Empty,
                Dinner = item.Where(x => x.Description == "晚餐").Count() > 0 ? item.First(x => x.Description == "晚餐").Enterprise.Name : string.Empty,
                Hotel1 = item.Where(x => x.Description == "住宿1").Count() > 0 ? item.First(x => x.Description == "住宿1").Enterprise.Name : string.Empty,
                Hotel2 = item.Where(x => x.Description == "住宿2").Count() > 0 ? item.First(x => x.Description == "住宿2").Enterprise.Name : string.Empty,
                Scenic1 = item.Where(x => x.Description == "景点1").Count() > 0 ? item.First(x => x.Description == "景点1").Enterprise.Name : string.Empty,
                Scenic2 = item.Where(x => x.Description == "景点2").Count() > 0 ? item.First(x => x.Description == "景点2").Enterprise.Name : string.Empty,
                Scenic3 = item.Where(x => x.Description == "景点3").Count() > 0 ? item.First(x => x.Description == "景点3").Enterprise.Name : string.Empty,
                Scenic4 = item.Where(x => x.Description == "景点4").Count() > 0 ? item.First(x => x.Description == "景点4").Enterprise.Name : string.Empty,
                Scenic5 = item.Where(x => x.Description == "景点5").Count() > 0 ? item.First(x => x.Description == "景点5").Enterprise.Name : string.Empty,
                Scenic6 = item.Where(x => x.Description == "景点6").Count() > 0 ? item.First(x => x.Description == "景点6").Enterprise.Name : string.Empty,
                Scenic7 = item.Where(x => x.Description == "景点7").Count() > 0 ? item.First(x => x.Description == "景点7").Enterprise.Name : string.Empty,
                Scenic8 = item.Where(x => x.Description == "景点8").Count() > 0 ? item.First(x => x.Description == "景点8").Enterprise.Name : string.Empty,
                Scenic9 = item.Where(x => x.Description == "景点9").Count() > 0 ? item.First(x => x.Description == "景点9").Enterprise.Name : string.Empty,
                Scenic10 = item.Where(x => x.Description == "景点10").Count() > 0 ? item.First(x => x.Description == "景点10").Enterprise.Name : string.Empty,
                ShoppingPoint1 = item.Where(x => x.Description == "购物点1").Count() > 0 ? item.First(x => x.Description == "购物点1").Enterprise.Name : string.Empty,
                ShoppingPoint2 = item.Where(x => x.Description == "购物点2").Count() > 0 ? item.First(x => x.Description == "购物点2").Enterprise.Name : string.Empty,
                ShoppingPoint3 = item.Where(x => x.Description == "购物点3").Count() > 0 ? item.First(x => x.Description == "购物点3").Enterprise.Name : string.Empty
            });
        }
        rptRoute.DataSource = grlist.OrderBy(x=>x.RouteDate);
        rptRoute.DataBind();
    }
}