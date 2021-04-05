<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slam.aspx.cs" Inherits="our.ui.slam" %>

<!DOCTYPE html>
<!--管理员建图和导航界面设计，相应操作不保存在数据库
    显示按钮有：开始建图、保存地图、确认导航点、保存导航点、导航点重命名
    方框导航点1修改为导航点2
    异常：相应功能操作的异常、测试需要对按钮的正确链接进行测试
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>建图和导航</title>
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
                    <li><a href="manager.aspx">用户管理</a></li>
                    <li><a href="taskManager.aspx">任务管理</a></li>
                    <li><a href="instr.aspx">指令管理</a></li>
                    <li class="active"><a href="#">建图和导航<span class="sr-only">(current)</span></a></li>
                    
                </ul>
            </div>
            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <h1 class="page-header">建图和导航</h1>
                <form method="post">
                    <button type="submit" class="btn btn-lg btn-success" id="Button1" name="slam">开始建图</button>
                    <button type="submit" class="btn btn-lg btn-success" id="Button2" name="saveSlam">保存地图</button>
                    <button type="submit" class="btn btn-lg btn-success" id="Button3" name="sure_aim">添加导航点</button>
                    <button type="submit" class="btn btn-lg btn-success" id="Button4" name="save_aim">保存导航点</button>
                    <button type="submit" class="btn btn-lg btn-success" id="Button5" name="rename">导航点设置</button>
                    
                    <!--下拉菜单文本框-->
                    <select class="selBox" name="aimNum" id="name1" onchange="check();">
                    <option value="导航点1">导航点1</option>
                    <option value="导航点2">导航点2</option>
                    <option value="导航点3">导航点3</option>
                    <option value="导航点4">导航点4</option>
                    </select>
                    <asp:Label ID="Label1" runat="server" text="" style="font-weight:600">设置为：</asp:Label>
                    <select class="selBox" name="goal" id="name2" onchange="check();">
                    <option value="start">起点</option>
                    <option value="destination">终点</option>
                    </select>
                    <style type="text/css">
                        .selBox{
                            background-color: rgb(243, 240, 240); 
                            height: 30px;
                            font-weight:500;
                            font-size:100%;
                        }
                    </style>
                </form>
            </div>
        </div>
    </div>

    <div class="myUrl" style="position:fixed; bottom:20px;text-align:center;width:100%;line-height: 20px; text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
