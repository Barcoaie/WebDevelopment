<%@ page import="vapoare.domain.User" %>
<%--
  Created by IntelliJ IDEA.
  User: Florinel-PC
  Date: 14-May-20
  Time: 6:39 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import = "java.io.*,java.util.*" %>
<%@ page import="vapoare.domain.Game" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Title</title>
    <style>
    </style>
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/utils.js"></script>
</head>
<body>
<%! Game game; %>
<% game = (Game) session.getAttribute("game");%>
<%
    game.setPhase_1(true);
    response.sendRedirect("phase1.jsp");
%>

</body>
</html>
