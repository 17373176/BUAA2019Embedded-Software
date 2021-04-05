<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="our.ui.AddTask" %>

<!DOCTYPE html>
<!--预定任务界面设计，主要是用户预定相应的任务，机器识别任务指令后执行；
    用户选择预定任务按钮跳转
    显示按钮有：天气预报、目标导航、控制移动、抓取东西
    异常：相应功能操作的异常、测试需要对按钮的正确链接进行测试
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>任务预订</title>
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
            <form id="formadd" method='post'>
                <div class="col-sm-3 col-md-2 sidebar">
                    <ul class="nav nav-sidebar">
                        <li><a href="user.aspx">主页 </a></li>
                        <li class="active"><a href="#">任务预订<span class="sr-only">(current)</span></a></li>
                        <li><a href="myTask.aspx">历史任务</a></li>
                        <li><a href="userInform.aspx">修改账户</a></li>
                    </ul>
                </div>
                <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                    <h1 class="page-header">任务预订</h1>
                    <button type="submit" class="btn btn-lg btn-success" runat="server" id="Button1" name="capture">抓取东西</button>
                    <button type="submit" class="btn btn-lg btn-success" runat="server" id="Button2" name="cast">天气播报</button>
                    <br /><br />
                    <asp:Label ID="Label5" runat="server" text="" style="font-weight:600; font-size:120%">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;导航和移动</asp:Label>
                    <br /><br />
                    <!--下拉菜单文本框-->
                    <asp:Label ID="Label1" runat="server" text="" style="font-weight:600">选择导航目标：</asp:Label>
                    <select class="selBox" name="dis" id="name1" onchange="check();">
                        <option value="1">起点</option>
                        <option value="2">终点</option>
                    </select>
                    <button type="submit" class="btn btn-lg btn-success" runat="server" id="Button4" name="go">前往导航点</button>
                    <br /><br />
                    <asp:Label ID="Label2" runat="server" text="" style="font-weight:600">选择移动指令：</asp:Label>
                    <select class="selBox" name="moveInstr" id="turn" onchange="check();">
                        <option value="forward">forward</option>
                        <option value="left">逆时针</option>
                        <option value="right">顺时针</option>
                    </select>
                    <asp:Label ID="Label3" runat="server" text="" style="font-weight:600">距离或角度：</asp:Label>
                    <select class="selBox" name="mile" id="name3" onchange="check();">
                        <option value="1">1m</option>
                        <option value="2">2m</option>
                        <option value="3">3m</option>
                        <option value="4">0度</option>
                        <option value="5">30度</option>
                        <option value="6">60度</option>
                        <option value="7">90度</option>
                    </select>
                    <!---<asp:Label ID="Label4" runat="server" text="" style="font-weight:600">角度：</asp:Label>
                    <select class="selBox" name="pi" id="name4" onchange="check();">
                        <option value="1">0°</option>
                        <option value="2">30°</option>
                        <option value="3">60°</option>
                    </select>
                    -->
                    <button type="submit" class="btn btn-lg btn-success" runat="server" id="Button5" name="move">移动</button>
                    <br /><br />
                    <button type="submit" class="btn btn-lg btn-success" runat="server" id="Button6" name="voice">语音输入命令</button>
                
                    <style type="text/css">
                        .selBox{
                             background-color: rgb(243, 240, 240); 
                             height: 30px;
                             font-weight:500;
                             font-size:100%;
                        }
                    </style>
                </div>
            </form>
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
