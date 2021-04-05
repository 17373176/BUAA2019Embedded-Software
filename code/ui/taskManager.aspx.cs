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
    /// 任务管理的交互类
    /// </summary>
    public partial class taskManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["user"] == null)
                {
                    Response.Redirect("login.aspx");
                }

                if (Request.HttpMethod == "GET") //the request for the origin login page
                {
                    //
                }
                else if (Request.HttpMethod == "POST")
                {
                    // 删除指定编号的任务
                    ManagerDao mana = new ManagerImp();
                    int t_no = Convert.ToInt32(Request.Form["delete"]);
                    mana.DeleteTask(t_no);
                    Response.Write("<script>alert('删除成功！')</script>");
                    Response.Write("<script>window.location ='manager.aspx'</script>");
                }
            }
        }

        public List<Task> GetAllTasks()
        {
            ManagerDao mana = new ManagerImp();
            return mana.GetAllTasks();
        }
    }
}