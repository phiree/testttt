using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
public partial class Manager_TourActivity_ImportForUserTicket : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnViewExcel_Click(object sender, EventArgs e)
    { 
       //将文件上传到服务器临时文件夹

        rptExcel.DataSource = GetList();
        rptExcel.DataBind();

       
    }
    BLL.BLLTicket bllTicket = new BLL.BLLTicket();

    private IList<UserTicketTable> GetList()
    {
     
        if (fuExcel.FileContent.Length == 0)
        {
            CommonLibrary.Notification.Show(this, "", "请选择文件", null);
            return null;
        }
        lblSelectedFileName.Text = fuExcel.FileName;
        IWorkbook excelbook = new HSSFWorkbook(fuExcel.FileContent);
        List<UserTicketTable> users = Convert(excelbook);
        return users;
    }

    private List<UserTicketTable> Convert(IWorkbook excelbook)
    { 
     List<UserTicketTable> usertickets = new List<UserTicketTable>();
        System.Collections.IEnumerator rowEnumerator = excelbook.GetSheetAt(0).GetRowEnumerator();
        var sht = excelbook.GetSheetAt(0);
        int rowCount = sht.PhysicalNumberOfRows;
        int currentIndex = 0;
        while (rowEnumerator.MoveNext())
        {
            currentIndex++;
            if (currentIndex == 1) { continue; }
            HSSFRow row = rowEnumerator.Current as HSSFRow;
            if (row.Cells[0].CellType== CellType.BLANK) break;
            UserTicketTable userticket = new UserTicketTable();
            userticket.gdate = DateTime.Now;
          string productCode=row.Cells[1].StringCellValue;
          Model.Ticket t = bllTicket.GetByProductCode(productCode);
          if (t == null)
          {
              throw new Exception("没有参加活动的门票:" +productCode );
          }
          userticket.gid = productCode;
          string mobile = string.Empty;
            if(row.GetCell(4)!=null)
            {
                userticket.mobile = row.GetCell(4).ToString().Trim();
            }
            userticket.orderfrom = tbxPartnerCode.Text.Trim();
            userticket.postcode = row.Cells[3].StringCellValue.Trim();
            userticket.syncState = 0;
            userticket.truename = row.Cells[2].StringCellValue.Trim();
            userticket.type =tbxActivityCode.Text.Trim()=="suichang2013"? 2:tbxActivityCode.Text.Trim()=="quzhouspring"?1:0;

            usertickets.Add(userticket);

            
        }
        return usertickets;
    }
    BLL.BLLActivityServiceImpl bllService = new BLL.BLLActivityServiceImpl();
    DAL.ado.NativeSqlUtiliity dalNative = new DAL.ado.NativeSqlUtiliity(SiteConfig.SyncServerConnection);
    protected void btnImport_Click(object sender, EventArgs e)
    {
        string errMsg = string.Empty;
        foreach (UserTicketTable user in GetList())
        {
         int existsRecordCount=  dalNative.ExecuteScalarInt(string.Format(@"select count(*) from  "+SiteConfig.SyncTableName+@"
            where postcode='{0}' and gid='{1}'",user.postcode,user.gid));
         if (existsRecordCount >= 1)
         {
             errMsg += "该记录已经导入:postcode:" + user.gid + "_gid:" + user.gid;
             continue;
         }

            dalNative.ExecuteNonResult(string.Format(@"
                insert into "+SiteConfig.SyncTableName+"({8},{9},{10},{11},{12},{13},{14},{15})  values('{0}','{1}',{2},'{3}','{4}',{5},'{6}','{7}')"
                ,user.postcode,user.gdate,user.type,user.gid,user.orderfrom,user.syncState,user.mobile,user.truename
                //columnnames
                ,"postcode","gdate","typeid","gid","orderfrom","syncstate","mobile","truename"
                ));

        //errMsg+= bllService.buyProduct(tbxActivityCode.Text.Trim(), null, tbxPartnerCode.Text.Trim(),
              //  user.postcode, user.truename, user.mobile, user.gid, 1)+Environment.NewLine;
        }
        CommonLibrary.Notification.Show(this,"","导入结果:"+errMsg,"",false,0);
    }
    class UserTicketTable
    {
        public string postcode { get; set; }
        public DateTime gdate { get; set; }
        public int type { get; set; }
        public string gid { get; set; }
        public string orderfrom { get; set; }
        public int syncState { get; set; }
        public string mobile { get; set; }
        public string truename { get; set; }
    }
    
}