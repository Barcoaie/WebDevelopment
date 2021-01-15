<%@ page import="vapoare.domain.Game" %><%--
  Created by IntelliJ IDEA.
  User: Florinel-PC
  Date: 07-Jun-20
  Time: 12:33 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Phase 1</title>
</head>
<body>
<%! Game game;%>
<% game = (Game) session.getAttribute("game");%>
    <div id="players">
        Player1: <label id="player1">
        <%
            if (game.getUserList().size() < 2)
                response.setIntHeader("Refresh", 5);
            out.println(game.getUserList().get(0).getUsername());
        %>
    </label>
        Player2: <label id="player2">
        <%
            if (game.getUserList().size() > 1) {
                out.println(game.getUserList().get(1).getUsername());
            }
        %>
    </label>
    </div>
<%
    if (game.getUserList().size() == 2) {
        game.setPhase_1(false);
        game.setPhase_2(true);
        session.setAttribute("count1", 0);
        session.setAttribute("count2", 0);
        response.sendRedirect("phase2.jsp");
    }
%>
</body>
</html>
