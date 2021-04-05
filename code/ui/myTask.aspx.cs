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
    /// 历史任务数据交互类
    /// </summary>
    public partial class myTask : System.Web.UI.Page
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
                    // 删除该用户指定编号的任务
                    int u_no = Convert.ToInt32(HttpContext.Current.Session["no"]);
                    AccountDao acc = new AccountImp();
                    int t_no = Convert.ToInt32(Request.Form["delete"]);
                    acc.DeleteTask(t_no, u_no);
                    Response.Write("<script>alert('删除成功！')</script>");
                    Response.Write("<script>window.location ='user.aspx'</script>");
                }
            }
        }

        public List<Task> GetAllTasks()
        {
            AccountDao acc = new AccountImp();
            
            int no = Convert.ToInt32(HttpContext.Current.Session["no"]);
            return acc.GetTaskList(no);
        }
    }
}