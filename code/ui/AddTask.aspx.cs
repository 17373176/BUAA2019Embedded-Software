using our.webService;
using our.webService.dal;
using our.webService.dal.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace our.ui
{
    /// <summary>
    /// 任务预定数据交互类
    /// </summary>
    public partial class AddTask : System.Web.UI.Page
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
                    // POST 方法用来传输实体的主体
                    // user no
                    int no = (int)(HttpContext.Current.Session["no"]);
                    // time
                    string time = DateTime.Now.ToString();
                    Task task = new Task();
                    AccountDao acc = new AccountImp();

                    if (Request.Form["go"] != null)
                    {
                        // 执行前往导航点
                        int instr = 1;
                        acc.BookTask(no, instr, time);
                        // 调用接口
                        string goal = Request.Form["dis"];
                        string note = task.func(instr, goal, "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='user.aspx'</script>");
                    }
                    if (Request.Form["move"] != null)
                    {
                        // 执行移动
                        int instr = 2;
                        acc.BookTask(no, instr, time);
                        // 调用接口
                        string turn = Request.Form["moveInstr"];
                        string mile = Request.Form["mile"];
                        string note = task.func(instr, "?", turn, mile);

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='user.aspx'</script>");
                    }
                    if (Request.Form["capture"] != null)
                    {
                        // 执行抓取
                        int instr = 3;
                        acc.BookTask(no, instr, time);
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");
                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='user.aspx'</script>");
                    }
                    if (Request.Form["cast"] != null)
                    {
                        // 执行天气
                        int instr = 4;
                        acc.BookTask(no, instr, time);
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='user.aspx'</script>");
                    }
                    if (Request.Form["voice"] != null)
                    {
                        // 执行语音输入
                        int instr = 5;
                        acc.BookTask(no, instr, time);
                        // 调用接口
                        string note = task.func(instr, "?", "?", "?");

                        // 成功后返回
                        Response.Write("<script>alert('" + note + "')</script>");
                        Response.Write("<script>window.location ='user.aspx'</script>");
                    }

                }
                else
                {

                }

            }
        }
    }
}