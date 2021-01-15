<%@ page import="vapoare.domain.Game" %>
<%@ page import="vapoare.domain.User" %><%--
  Created by IntelliJ IDEA.
  User: Florinel-PC
  Date: 07-Jun-20
  Time: 4:09 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Phase 3</title>
    <style>
        #game-grid {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
            display: grid;
            grid-template-columns: auto auto auto auto auto;
            background-color: cadetblue;
            padding: 1em;
        }

        #game-grid-item {
            background-color: #00ffff;
            border: 1px solid #4682b4;
            padding: 20px;
            font-size: 30px;
            text-align: center;
        }

        #players {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }

        form {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }
    </style>
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/utils.js"></script>
</head>
<body>
<%! Game game;%>
<%! User user;%>
<%! User userToHit;%>
<%! int count;%>
<% user = (User) session.getAttribute("user");%>
<% game = (Game) session.getAttribute("game");%>
<% userToHit = game.getUserList().stream().filter(item -> item.getId() != user.getId()).findFirst().get(); %>
<% count = 0; %>
<div id="players">
    Player1: <label id="player1">
    <%

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
<form action="GameController" method="post">
    <div id="game-grid">
        <script>
            const grid = document.getElementById("game-grid");
            for (let i = 0; i < 5; i++) {
                for (let j = 0; j < 5; j++) {
                    const div_var = document.createElement("div");
                    div_var.setAttribute("value", String(i) + ',' + String(j));
                    div_var.setAttribute("id", "game-grid-item" + String(i) + String(j));
                    div_var.style.backgroundColor = "#00ffff";
                    div_var.style.border = "1px solid #4682b4";
                    div_var.style.padding = "20px";
                    div_var.style.fontSize = "30px";
                    div_var.style.textAlign = "center";
                    const context_var = document.createTextNode(String(i) + ',' + String(j));
                    div_var.appendChild(context_var);
                    grid.appendChild(div_var);
                }
            }
            for (let i = 0; i < 5; i++) {
                for (let j = 0; j < 5; j++) {
                    $("#game-grid-item" + String(i) + String(j)).click(function () {
                        $("#game-grid-item" + String(i) + String(j)).css("background-color", "red");
                        hitTarget(i, j, <%=userToHit.getId()%>);
                    });
                }
            }
        </script>
    </div>
</form>
</body>
</html>
