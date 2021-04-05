<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instr.aspx.cs" Inherits="our.ui.allInstr" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>指令管理</title>
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
                    <li class="active"><a href="#">指令管理<span class="sr-only">(current)</span></a></li>
                    <li><a href="slam.aspx">建图和导航</a></li>
                    
                </ul>
            </div>

            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <!--:if test="${sessionScope.airPlaneManageMsg!=null}">
			        <div class="alert alert-info" role="alert">
				    ${airPlaneManageMsg}
				    ${sessionScope.airPlaneManageMsg=null}
			        </div>
			    <-->
              <%
                    List<our.webService.Instr> instrList = GetAllInstrs();
                    int count = instrList.Count();
                %>
              <h2 class="sub-header">当前共有<%=count %>条指令</h2>
                <div class="table-responsive">
                    <table class="table table-striped">
                      <thead>
                        <tr>
                        <th>指令编号</th>
                        <th>指令对应关键词</th>
                        <th>指令内容</th>
                        </tr>
                     </thead>
                  <tbody>
                      <% foreach (var i in instrList)
                          { %>
                         <tr>
                            <td><%=i.getNo() %></td>
                            <td><%=i.getKeyWord() %></td>
                            <td><%=i.getType() %></td>
                        </tr>
                      <%} %>
                  </tbody>
                </table>
            </div>
            </div>
        </div>
     </div>

    <div class="myUrl"  style="bottom:20px;text-align:center;width:100%;line-height: 20px;text-align:center">
        <label style="">Copyright ©2020 ROS启智</label>
        <br />
        <a href="login.aspx" target="_self" style="">主页&nbsp;&nbsp;</a>
        <a href="contact.html" target="_blank"> 联系我们</a>
    </div>
</body>
</html>
