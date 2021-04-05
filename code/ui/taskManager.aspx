<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskManager.aspx.cs" Inherits="our.ui.taskManager" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<!DOCTYPE html>
<!--管理员界面设计，主要是查看任务数据；
    异常：相应功能操作的异常、测试需要对按钮的正确链接进行测试
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>任务管理</title>
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
        <form method="post" >
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar">
                <ul class="nav nav-sidebar">
                    <li><a href="manager.aspx">用户管理</a></li>
                    <li class="active"><a href="#">任务管理<span class="sr-only">(current)</span></a></li>
                    <li><a href="instr.aspx">指令管理</a></li>
                    <li><a href="slam.aspx">建图和导航</a></li>
                    
                </ul>
            </div>

            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
              
                <%
                    List<our.webService.Task> taskList = GetAllTasks();
                    int count = taskList.Count();
                %>
                <h2 class="sub-header">当前共有<%=count %>条任务</h2>
                  <div class="table-responsive">
                    <table class="table table-striped">
                      <thead>
                        <tr>
                        <th>任务编号</th>
                        <th>任务指令</th>
                        <th>任务是否完成</th>
                        <th>任务执行时间</th>
                        <th>操作</th>
                        </tr>
                     </thead>
                  <tbody>
                      <% foreach (var t in taskList)
                          { %>
                         <tr>
                            <td><%=t.getNo() %></td>
                            <td><%=t.getInstrNo() %></td>
                            <td><%=t.getIsFinished() %></td>
                            <td><%=t.getTime() %></td>
                            <td>
                                <button type="submit" class="btn btn-xs btn-danger" name="delete" value="<%=t.getNo() %>" onclick="Delete" >删除</button>
                            </td>
                        </tr>
                      <%} %>
                  </tbody>
                </table>
            </div>
            </div>
        </div>
            </form>
    </div>

    <div class="myUrl" style="bottom:20px;text-align:center;width:100%;line-height: 20px;text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
