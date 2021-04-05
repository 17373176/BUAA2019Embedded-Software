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
    /// 用户信息修改交互类
    /// </summary>
    public partial class userInform : System.Web.UI.Page
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
                    // 得到前端输入
                    string Id = Request.Form["id"];
                    string Password = Request.Form["password"];

                    // 获取当前登录用户的编号
                    int no = Convert.ToInt32(HttpContext.Current.Session["no"]);

                    // 调用更新接口
                    UserDao userDao = new UserImp();
                    userDao.UpDateUser(no, Password, Id);

                    // 修改成功跳转到主页
                    Response.Write("<script>alert('修改成功！')</script>");
                    Response.Write("<script>window.location ='user.aspx'</script>");

                    //Response.Redirect("user.aspx");
                }
                else
                {

                }
            }
        }

    }
}