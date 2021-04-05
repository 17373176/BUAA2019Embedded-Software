using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace our.src.exception
{
    /**
     * 基于网页显示错误弹框
     */
    public class MessageShow
    {
        public MessageShow() { }
        public void ErrorShow(string strMsg)
        {
            //Response.Write("<script>alert('用户名不存在或密码错误！')</script>");
            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + strMsg + "');", true);
        }
    }
}