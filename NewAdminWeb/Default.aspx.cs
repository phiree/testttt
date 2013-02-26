using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    #region 参数
    string pageUrl;
    #endregion
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            
            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(mainTabStrip);
            if (Request.Cookies["MenuType"]!=null&&Request.Cookies["MenuType"].Value == "accordion")
            {
                Accordion accordion = InitAccordionMenu();
                ids.Add("mainMenu", accordion.ClientID);
                ids.Add("menuType", "accordion");
            }
            else
            {
                Tree tree = InitTreeMenu();
                ids.Add("mainMenu", tree.ClientID);
                ids.Add("menuType", "menu");
            }
            
            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "s", idsScriptStr, true);
            if (Request.Cookies["Theme"]!=null)
                ddlTheme.SelectedValue = Request.Cookies["Theme"].Value.ToString().ToLower();
            if (Request.Cookies["menuType"]!=null)
                ddlMenuType.SelectedValue = Request.Cookies["menuType"].Value.ToString().ToLower();
        }
    }

    private Accordion InitAccordionMenu()
    {
        Accordion accordionMenu = new Accordion();
        accordionMenu.ID = "accordionMenu";
        accordionMenu.EnableFill = true;
        accordionMenu.ShowBorder = false;
        accordionMenu.ShowHeader = false;
        Region2.Items.Add(accordionMenu);
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
        XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
        int accordionIndex = 0;
        int activeIndex = 0;
        foreach (XmlNode xmlNode in xmlNodes)
        {
            if (xmlNode.HasChildNodes)
            {
                AccordionPane accordionPane = new AccordionPane();
                accordionPane.Title = xmlNode.Attributes["Text"].Value;
                accordionPane.Layout = Layout.Fit;
                accordionPane.ShowBorder = false;
                accordionPane.BodyPadding = "2px 0 0 0";
                accordionPane.RowHeight = "40px";
                accordionMenu.Items.Add(accordionPane);
                Tree innerTree = new Tree();
                innerTree.EnableArrows = true;
                innerTree.ShowBorder = false;
                innerTree.ShowHeader = false;
                innerTree.EnableIcons = false;
                innerTree.AutoScroll = false;
                innerTree.Layout = Layout.Fit;
                accordionPane.Items.Add(innerTree);
                XmlDocument innerXmlDoc = new XmlDocument();
                innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));
                //绑定AccordionPane内部的树控件
                innerTree.DataSource = innerXmlDoc;
                innerTree.DataBind();
                foreach (var node in innerTree.Nodes)
                {
                    if (Request.Cookies["tabUrl"] != null)
                    {
                        string taburl = Server.UrlDecode(Request.Cookies["tabUrl"].Value);
                        if (taburl != "" && node.NavigateUrl == taburl)
                        {
                            //accordionMenu.ActiveIndex = accordionIndex;
                            Tab tab = new Tab();
                            tab.EnableIFrame = true;
                            tab.EnableClose = true;
                            tab.Title = node.Text;
                            tab.Icon = Icon.Page;
                            tab.IFrameUrl = node.NavigateUrl;
                            mainTabStrip.Tabs.Add(tab);
                            mainTabStrip.ActiveTabIndex = 1;
                            activeIndex = accordionIndex;
                        }
                    }
                    node.IconUrl = "/icon/vs_aspx.png";
                    node.EnablePostBack = false;
                    node.NavigateUrl = node.NavigateUrl;
                    string tabinfo = node.Text + "_" + node.NavigateUrl;
                    //node.OnClientClick = "AddTab('" + tabinfo + "','" + accordionIndex + "')";
                }
            }
            accordionIndex++;
        }
        return accordionMenu;
    }

    private FineUI.Tree InitTreeMenu()
    {
        FineUI.Tree treeMenu = new FineUI.Tree();
        treeMenu.ID = "treeMenu";
        treeMenu.EnableArrows = true;
        treeMenu.ShowBorder = false;
        treeMenu.ShowHeader = false;
        treeMenu.EnableIcons = false;
        treeMenu.AutoScroll = true;
        Region2.Items.Add(treeMenu);
        treeMenu.DataSource = XmlDataSource1;
        treeMenu.DataBind();
        foreach (var node in treeMenu.Nodes)
        {
            node.IconUrl = "/icon/vs_aspx.png";
        }
        return treeMenu;
    }


    private JObject GetClientIDS(params ControlBase[] ctrls)
    {
        JObject jo = new JObject();
        foreach (ControlBase ctrl in ctrls)
        {
            jo.Add(ctrl.ID, ctrl.ClientID);
        }

        return jo;
    }
    #endregion


    #region event
    /// <summary>
    /// 修改样式
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie themeCookie = new HttpCookie("Theme", ddlTheme.SelectedValue);
        themeCookie.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(themeCookie);
        PageContext.Refresh();
    }
    protected void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie themeCookie = new HttpCookie("MenuType", ddlMenuType.SelectedValue);
        themeCookie.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(themeCookie);
        PageContext.Refresh();
    }


    #endregion
}