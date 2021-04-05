<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="our.ui.login" %>

<!DOCTYPE html>

<!--登录界面设计，主要是接收用户或管理员的账户名和密码；
    注册跳转到注册页面
    登录提交到用户页面
    异常：查询用户名是否存在；查询密码是否正确；用户名和密码均为字符串且非空
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>启智智能机器人系统</title>
    <link rel="shortcut icon" href="logo.ico" /> <!--设置页面标题前的logo-->
    <style type="text/css">
        a {text-decoration: none;}
        a:hover{ text-decoration:none}
    </style>
</head>

<body>
    <!--设置页面的logo图案-->
    <div class="logo" style="position:absolute;top:20px;left:30px;">
        <img src="logo.jpg" style="width:100px;height:100px;" /> 

    </div>
    <!--背景图-->
    <style type="text/css">
        body {
            background: url("ji.jpg");
            background-repeat: no-repeat;
            background-size: 697px 657px;
            background-position: right top;
        }
    </style>

    <div class="shadow" style="text-align:center">
            <!---
            <c:if test="${sessionScope.loginMsg!=null}">
                <div class="alert alert-info" role="alert">
                    ${loginMsg}
                    ${sessionScope .loginMsg=null}
                </div>
            </c:if>
                --->

            <div class="boder1">
                <style type="text/css">
                    .boder1 {
                        text-align:center;
                        left: 300px;
                        top: 80px;
                        width: 414px;
                        height: 480px;
                        border: solid rgba(110, 213, 227, 0.6) 2px;
                        background-color: rgba(231, 242, 232, 0.90);
                        position: absolute;
                    }
                </style>

                <h2 class="form-signin-heading" style="color:rgb(80, 172, 185); font-size:30px; font-weight:bold">
                    欢迎使用启智智能机器人系统!<br />
                    定制属于你的家居机器人
                </h2>
                <br />
                <h3 class="form-signin-heading" style="color:rgb(95, 95, 103); font-size:30px; font-weight:bold">------------请登录------------</h3>

                <form id="form1" method='post' action="login.aspx">
                <div class="form-group">
                    <label class="col-sm-2 control-label" style="color: #000000;font-size: 16px;font-weight:600;">用户名</label>
                    <div class="col-sm-10">
                        <input class="form-control" style="height:20px" id="focusedInput" type="text" name="username" placeholder="username" required=""/>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-sm-2 control-label" style="color:#000000; font-size:16px;font-weight:600;">密码</label>
                    <div class="col-sm-10">
                        <input type="password" style="height:20px" id="inputPassword" class="form-control" name="password" placeholder="password" required=""/>
                    </div>
                </div>
                <br />
                <button class="btn" type="submit">
                    <style type="text/css">
                        .btn{ background-color: rgba(149, 231, 242, 0.60); }
                    </style>
                    登录</button>
                <button class="btn" type="button" onclick="javascript:window.location.href='register.aspx';">注册</button>
            </form>
                </div>
        
    </div>

    <div class="myUrl"  style="position:fixed; bottom:20px;text-align:center;width:100%;line-height: 20px;text-align: center">
        <style type="text/css">
            .myUrl{
                font-weight:700;
                font-size:80%
            }

        </style>
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
