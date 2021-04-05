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
    /// 指令管理数据交互类
    /// </summary>
    public partial class allInstr : System.Web.UI.Page
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

        protected List<Instr> GetAllInstrs()
        {
            ManagerDao mana = new ManagerImp();
            return mana.GetAllInstrs();
        }
    }
}