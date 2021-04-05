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
    public partial class register : System.Web.UI.Page
    {
        /// <summary>
        /// 后端与前端数据交互-注册界面接收到用户名、ID和密码
        /// 查询数据库是否存在，存在则不允许注册
        /// 数据库默认添加了管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.HttpMethod == "GET") //the request for the origin login page
                {
                    // 获得服务器响应前端的内容
                }
                else if (Request.HttpMethod == "POST")
                {
                    // POST 方法用来传输实体的主体
                    string Username = Request.Form["username"];
                    string Password = Request.Form["password"];
                    string ID = Request.Form["user ID"];

                    UserDao userInter = new UserImp();
                    User user = userInter.Login(Username, Password);
                    // 检查用户名是否存在数据库里
                    if (user != null)
                    {
                        //存在，请登录
                        Response.Write("<script>alert('用户名已存在，请登录！')</script>");
                        Response.Write("<script>window.location ='login.aspx'</script>");
                        return;
                    }

                    // 不存在，插入数据库，返回登录
                    user = new User(); // 实例化
                    user.setUsername(Username);
                    user.setPassword(Password);
                    user.setID(ID);
                    user.setType(false); // 注册都是用户
                    userInter.InsertUser(user);
                    Response.Write("<script>alert('注册成功，请登录！')</script>");
                    Response.Write("<script>window.location ='user.aspx'</script>");
                }
                else
                {
                    //
                }

            }
        }
    }
}