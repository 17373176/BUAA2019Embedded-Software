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
    /// 管理员初始界面（用户管理界面）数据交互类
    /// </summary>
    public partial class manager : System.Web.UI.Page
    {
        ManagerDao mana = new ManagerImp();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["user"] == null)
                { // 如果当前登录会话结束，则返回主页
                    Response.Redirect("login.aspx");
                }
                // 标记管理员实例
                HttpContext.Current.Session["manager"] = mana;

                if (Request.HttpMethod == "GET") //the request for the origin login page
                {
                    //
                }
                else if (Request.HttpMethod == "POST")
                {
                    // 删除指定编号的用户
                    int user_no = Convert.ToInt32(Request.Form["delete"]);
                    mana.DeleteUser(user_no);
                    Response.Write("<script>alert('删除成功！')</script>");
                    Response.Write("<script>window.location ='manager.aspx'</script>");
                }
            }

        }

        /// <summary>
        /// 获得所有注册的用户
        /// </summary>
        /// <returns>list</returns>
        public List<User> GetAllUsers()
        {
            return mana.GetAllUsers();
        }
        /// <summary>
        /// 删除指定编号的用户
        /// </summary>
        /// <param name="user_no"></param>
        
        /*protected void DeleteUser(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET") //the request for the origin login page
            {
                //
            }
            else if (Request.HttpMethod == "POST")
            {
                int user_no = Convert.ToInt32(Request.Form["delete"]);
                mana.DeleteUser(user_no);
                Response.Write("<script>alert('删除成功！')</script>");
                Response.Write("<script>window.location ='manager.aspx'</script>");
            }
        }*/
    }
}