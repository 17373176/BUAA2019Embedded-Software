<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="our.ui.user" %>

<!DOCTYPE html>
<!--用户界面设计，主要是用户信息，用户一些功能和操作；
    用户登录后提交到该用户页面
    可进行任务预定、查看历史任务、修改个人信息
    异常：相应功能操作的异常、测试需要对按钮的正确链接进行测试
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>启智机器人系统</title>
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

    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="http://v3.bootcss.com/examples/dashboard/#">启智机器人系统</a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="logout.aspx" style="color:lightcyan">退出</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar">
                <ul class="nav nav-sidebar">
                    <li class="active"><a href="#">主页 <span class="sr-only">(current)</span></a></li>
                    <li><a href="AddTask.aspx">任务预订</a></li>
                    <li><a href="myTask.aspx">历史任务</a></li>
                    <li><a href="userInform.aspx">修改账户</a></li>
                   
                </ul>

            </div>
            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <%string username = (string)HttpContext.Current.Session["user"]; %>
                <h1 class="page-header">你好,<%=username %>！</h1>
                
            </div>
        </div>
    </div>

    <script src="css/jquery.min.js"></script>
    <script src="css/bootstrap.min.js"></script>
    <script src="css/holder.min.js"></script>
    <script src="css/ie10-viewport-bug-workaround.js"></script>

    <div class="myUrl" style="position:fixed; bottom:20px;text-align:center;width:100%;line-height: 20px; text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
