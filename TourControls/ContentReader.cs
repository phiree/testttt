using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using CommonLibrary;
namespace TourControls
{
    /// <summary>
    /// 读取html内容,展现在页面上
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WebCustomControl1 runat=server></{0}:WebCustomControl1>")]
    public class ContentReader : WebControl
    {
        //type属性表明页面的类型
        [
         Bindable(true), Category("Appearance"), DefaultValue(""), Description("页面类型"), Localizable(true)
        ]
        public virtual string type
        {
            get
            {
                string t = (string)ViewState["type"];
                return t;
            }
            set
            {
                ViewState["type"] = value;
            }
        }
        //scid属性表明景区名称
        [
         Bindable(true), Category("Appearance"), DefaultValue(""), Description("景区名称"), Localizable(true)
        ]
        public virtual string scname
        {
            get
            {
                string t = (string)ViewState["scname"];
                return t;
            }
            set
            {
                ViewState["scid"] = value;
            }
        }
        //scFuncType属性表明景区描绘的类型scFuncType
        [
         Bindable(true), Category("Appearance"), DefaultValue(""), Description("景区描述类型"), Localizable(true)
        ]
        public virtual string scFuncType
        {
            get
            {
                string t = (string)ViewState["scFuncType"];
                return t;
            }
            set
            {
                ViewState["scFuncType"] = value;
            }
        }


        
        

        protected override void Render(HtmlTextWriter output)
        {
            HTMLInfo htmlinfo = new HTMLInfo();
            output.Write(htmlinfo.GetHTMLInfo(type,scname,scFuncType));
        }
    }
}
