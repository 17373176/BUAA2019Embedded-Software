<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myTask.aspx.cs" Inherits="our.ui.myTask" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<!DOCTYPE html>
<!--历史任务界面设计，主要是用户查看历史任务；
    用户选择历史任务按钮跳转
    显示有：任务编号，任务对应的指令，任务名称，任务是否完成
    异常：查询操作的异常
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>历史任务</title>
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
    <form id="form1" method="post">
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
                        <li><a href="user.aspx">主页 </a></li>
                        <li><a href="AddTask.aspx">任务预订</a></li>
                        <li class="active"><a href="#">历史任务<span class="sr-only">(current)</span></a></li>
                        <li><a href="userInform.aspx">修改账户</a></li>
                    </ul>

                </div>
                <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                    <!--<c:if test="${sessionScope.myOrderMsg!=null}">
                        <div class="alert alert-info" role="alert">
                            ${myOrderMsg}
                            ${sessionScope.myOrderMsg=null}
                        </div>
                    </c:if>
                    -->
                    <%
                        List<our.webService.Task> taskList = GetAllTasks();
                        int count = taskList.Count(); 
                    %>
                    <h2 class="sub-header">你有如下<%=count %>条历史任务</h2>
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
                                <% foreach (var o in taskList) { %>
                                    <tr>
                                        <!--表达式前面加等号，后面不加分号，语句需要加-->
                                        <td><%=o.no %></td>
                                        <td><%=o.instr_no %></td>
                                        <td>
                                            <%if (o.isFinished == true) { %>
                                                <%="是"%>
                                            <%}%>
                                            <%if (o.isFinished == false) { %>
                                                <% = "否"%>
                                            <%}%>
                                        </td>
                                        <td><%= o.time %></td>
                                        <td>
                                            <button type="submit" class="btn btn-xs btn-danger" name="delete" value="<%=o.getNo() %>" onclick="Delete" >删除</button>
                                        </td>
                                    </tr>
                                <% }%>

                            </tbody>
                        </table>

                    </div>

                </div>
            </div>
        </div>


    </form>
    <div class="myUrl" style="bottom:20px;text-align:center;width:100%;line-height: 20px; text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
