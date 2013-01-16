using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
public partial class Manager_QuZhouSpring_ClientEditor : basepage
{
    bool isNew = true;
    QZSpringPartner qzclient;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["Id"]))
        {
            isNew = false;
        }
        if (!IsPostBack)
        {
            if (!isNew)
            {
                //todo
                LoadForm();
            }
            else
            {
                qzclient = new QZSpringPartner();
            }
        }
    }

    private void LoadForm()
    {
        tbxClientName.Text = qzclient.Name;
        tbxFriendlyId.Text = qzclient.FriendlyId;
        tbxRequestSource.Text = qzclient.RequestSource;
        cbxEnable.Checked = qzclient.Enable;
    }
    private void UpdateForm()
    {
        qzclient.Enable = cbxEnable.Checked;
        qzclient.FriendlyId = tbxFriendlyId.Text;
        qzclient.Name = tbxClientName.Text;
        qzclient.RequestSource = tbxRequestSource.Text;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateForm();
        //todo save
    }
}