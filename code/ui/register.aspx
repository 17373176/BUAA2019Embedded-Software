<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="our.ui.register" %>

<!DOCTYPE html>

<!--注册界面设计，主要是接收注册的用户的账户名、ID和密码；
    注册提交则提示成功，3秒自动跳转到登录界面
    异常：查询用户名是否存在，存在则不能注册；用户名和密码均为字符串且非空
    -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册</title>
    <link rel="shortcut icon" href="logo.ico" />
    <style type="text/css">
        a {text-decoration: none;}
        a:hover{ text-decoration:none}
    </style>
</head>

<body>
    <div class="logo" style="position:absolute;top:20px;right:30px;">
        <img src="logo.jpg" style="width:100px;height:100px;" />

    </div>

    <style type="text/css">
        body {
            background: url("xingshi.png");
            background-repeat: no-repeat;
            background-size: 397px 357px;
            background-position-y: 120px;
            
        }
    </style>

    <div class="shadow" style="text-align:center">
        <div class="boder1">
            <style type="text/css">
                .boder1 {
                    left: 400px;
                    top: 80px;
                    width: 414px;
                    height: 460px;
                    border: solid rgba(110, 213, 227, 0.6) 2px;
                    background-color: rgba(239, 238, 238, 0.80);
                    position: absolute;
                }
            </style>

            <div class="front">
                <h2 class="form-signin-heading" style="color:rgb(80, 172, 185); font-size:30px; font-weight:bold">
                    注册属于你的家居机器人
                </h2>

                <h3 class="sub-header" style="color:rgb(95, 95, 103); font-size:30px; font-weight:bold">-----------用户注册-----------</h3>
                <form class="form-horizontal" role="form" method="post" action="">

                    <div class="form-group">
                        <label class="col-sm-2 control-label" style="color:#000000; font-size:16px;font-weight:600;">用户名</label>
                        <div class="col-sm-10">
                            <input class="form-control" style="height:20px" id="focusedInput1" type="text" name="username" placeholder="username" required=""/>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="col-sm-2 control-label" style="color:#000000; font-size:16px;font-weight:600">用户ID</label>
                        <div class="col-sm-10">
                            <input class="form-control" style="height:20px" id="focusedInput2" type="text" name="user ID" placeholder="user ID" required=""/>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="col-sm-2 control-label" style="color: #000000;font-size: 16px;font-weight:600">密码</label>
                        <div class="col-sm-10">
                            <input type="password" style="height:20px" id="inputPassword" class="form-control" name="password" placeholder="password" required=""/>
                        </div>
                    </div>
                    <br />

                    <button type="submit" class="btn btn-lg btn-primary btn-success btn-block">
                        <style type="text/css">
                            .btn {
                                background-color: rgba(149, 231, 242, 0.60);
                            }
                        </style>提交
                    </button>
                </form>
            </div>
        </div>
    </div>

    <div class="myUrl" style="position: fixed;
            font-weight:700;
            font-size:80%;
            bottom: 20px;
            text-align: center;
            width: 100%;
            line-height: 20px;
            text-align: center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>