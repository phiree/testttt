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
                ViewState["scname"] = value;
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
        //CanEdit属性表明是否可以编辑该控件
        [
         Bindable(true), Category("Appearance"), DefaultValue(false), Description("是否能编辑"), Localizable(true)
        ]
        public virtual bool CanEdit
        {
            get
            {
                if (ViewState["CanEdit"] == null)
                    ViewState["CanEdit"] = false;
                bool t = (bool)ViewState["CanEdit"];
                return t;
            }
            set
            {
                ViewState["CanEdit"] = value;
            }
        }
        //BaseData属性表明数据库数据
        [
         Bindable(true), Category("Appearance"), DefaultValue(false), Description("若没有文件数据,这个是数据库数据"), Localizable(true)
        ]
        public virtual string BaseData
        {
            get
            {
                string t = (string)ViewState["BaseData"];
                return t;
            }
            set
            {
                ViewState["BaseData"] = value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            HTMLInfo htmlinfo = new HTMLInfo();
            string outputstr = htmlinfo.GetHTMLInfo(type, scname, scFuncType);
            if (string.IsNullOrEmpty(outputstr))
            {
                outputstr = BaseData;
                htmlinfo.WriteHTMLInfo(type, scname, scFuncType, BaseData);
            }
            if (CanEdit)
            {
                output.AddAttribute("onmouseover", "EditHTMLInfo(this)");
                output.AddAttribute("onmouseout", "CancelHTMLInfo(this)");
                output.AddAttribute("ondblclick", "EditHTMLInfoBtn(this,'" + scname + "','" + scFuncType + "')");
                output.AddAttribute("class", CssClass);
                output.AddAttribute("id", ID);
                output.RenderBeginTag(HtmlTextWriterTag.Div);
                output.Write(outputstr);
                output.RenderEndTag();
            }
            else
            {
                output.AddAttribute("class", CssClass);
                output.AddAttribute("id", ID);
                output.RenderBeginTag(HtmlTextWriterTag.Div);
                output.Write(outputstr);
                output.RenderEndTag();
            }
        }
    }
}
