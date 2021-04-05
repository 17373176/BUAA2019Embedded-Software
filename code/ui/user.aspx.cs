using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace our.ui
{
    /// <summary>
    /// 用户界面数据交互类
    /// </summary>
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["user"] == null)
                { // 如果当前登录会话结束，则返回主页
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}