using Task = our.webService.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using our.webService.dal;
using our.webService.dal.imp;

namespace our.ui
{
    /// <summary>
    /// 管理员建图和导航功能
    /// </summary>
    public partial class slam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["user"] == null)
                { // 如果当前登录会话结束，则返回主页
                    Response.Redirect("login.aspx");
                }
                if (Request.HttpMethod == "GET") //the request for the origin login page
                {
                    //
                }
                else if (Request.HttpMethod == "POST")
                {
                    ManagerDao mana = new ManagerImp();
                    Task task = new Task();

                    if (Request.Form["slam"] != null)
                    {
                        // 建图
                        int instr = 6;
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='manager.aspx'</script>");
                    }
                    if (Request.Form["saveSlam"] != null)
                    {
                        // 保存建图
                        int instr = 7;
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='manager.aspx'</script>");
                    }
                    if (Request.Form["sure_aim"] != null)
                    {
                        // 确认导航点
                        int instr = 8;
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='manager.aspx'</script>");
                    }
                    if (Request.Form["save_aim"] != null)
                    {
                        // 保存导航点
                        int instr = 9;
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='manager.aspx'</script>");
                    }
                    if (Request.Form["rename"] != null)
                    {
                        // 重命名导航点
                        int instr = 10;
                        string aim = Request.Form["aimNum"];
                        string goal = Request.Form["goal"];

                        // 调用接口
                        string note = task.func(instr, goal, aim, "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='manager.aspx'</script>");
                    }
                }
            }
        }
    }
}