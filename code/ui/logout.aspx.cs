using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace our.ui
{
    /// <summary>
    /// 退出账户的登录，user=null，跳转到登录界面
    /// </summary>
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["user"] = null;
            Response.Write("<script>alert('已登出！')</script>");
            Response.Write("<script>window.location ='login.aspx'</script>");
        }
    }
}