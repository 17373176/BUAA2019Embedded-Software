<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userInform.aspx.cs" Inherits="our.ui.userInform" %>

<!DOCTYPE html>
<!--修改个人信息界面设计，主要是用户修改密码；
    用户选择历史任务按钮跳转
    显示有：任务编号，任务对应的指令，任务名称，任务是否完成
    异常：按钮服务器提交的异常，以及数据库修改异常
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改个人信息</title>
    <link rel="shortcut icon" href="logo.ico" /> <!--设置页面标题前的logo-->
    <!--引用css页面设置-->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/dashboard.css" rel="stylesheet"/>
    <script src="css/ie-emulation-modes-warning.js"></script>
    <style type="text/css">
        a {text-decoration: none;}
        a:hover{ text-decoration:none}
    </style>
</head>
<body>
    <div class="container">
        <h2 class="sub-header">修改用户信息</h2>
        <form class="form-horizontal" method='post' role="form">
            <div class="form-group">
                <%
                    int no = Convert.ToInt32(HttpContext.Current.Session["no"]);
                    string name = Convert.ToString(HttpContext.Current.Session["user"]);
                    %>
                <label for="inputPassword" class="col-sm-2 control-label">用户编号</label>
                <div class="col-sm-10">
                    <input class="form-control" id="disabledInput1" type="text" placeholder="<%=no %>" disabled name="no"/>
                </div>
            </div>

            <div class="form-group">
                <label for="inputPassword" class="col-sm-2 control-label">用户名</label>
                <div class="col-sm-10">
                    <input class="form-control" id="disabledInput2" type="text" placeholder="<%=name %>" disabled name="username"/>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">用户ID</label>
                <div class="col-sm-10">
                    <input class="form-control" id="focusedInput1" type="text" name="id" placeholder="user ID" required=""/>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">用户密码</label>
                <div class="col-sm-10">
                    <input class="form-control" id="focusedInput2" type="text" name="password" placeholder="password" required=""/>
                </div>
            </div>

            <button type="submit" class="btn" style="border-color:aquamarine;background-color:azure">提交</button>
        </form>
    </div>
    <div class="myUrl" style="position:fixed; bottom:20px;text-align:center;width:100%;line-height: 20px; text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="aspx.html" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>