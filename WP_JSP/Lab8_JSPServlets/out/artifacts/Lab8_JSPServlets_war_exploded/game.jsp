<%--
Created by IntelliJ IDEA.
User: Florinel-PC
Date: 14-May-20
Time: 6:39 PM
To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import = "java.io.*,java.util.*" %>
<%@ page import="vapoare.domain.User" %>
<%@ page import="vapoare.domain.Game" %>
<%@ page import="vapoare.model.DBManager" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Game</title>
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
<br/>
    <%! User user; %>
    <%! int count; %>
    <%! Game game = new Game(new ArrayList<>(), true, false, false, false); %>
    <%
        if (game.getUserList().size() < 2)
            response.setIntHeader("Refresh", 5);
        if (session.getAttribute("user") != null) {
            user = (User) session.getAttribute("user");
            count = (int) session.getAttribute("count");
            //out.println(user.getUsername());
            if (!game.getUserList().contains(user))
                game.getUserList().add(user);
        }
    %>
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
    <br/>
    <form action="GameController" method="post">
        <div id="game-grid">
            <script>
                <%
                    while (game.isPhase_1()) {
                %>
                        for (let i = 0; i < 5; i++) {
                            for (let j = 0; j < 5; j++) {
                                $("#game-grid-item"+String(i)+String(j)).click(function () {
                                    <%
                                        if (game.getUserList().size() == 2) {
                                            game.setPhase_1(false);
                                            game.setPhase_2(true);
                                    %>
                                    <%
                                        }
                                        else {
                                    %>
                                    alert("wait for another player to connect");
                                    <%
                                        }
                                    %>
                                });
                            }
                        }
                <%
                    }
                    if (game.isPhase_2()) {
                %>
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
                            $("#game-grid-item" + String(i) + String(j)).css("background-color", "green");
                                <%= count%> = placeVaporForUser(i,j,<%=user.getId()%>, <%=count%>, <% count++;%>)
                                <%out.println(count);%>
                                <%
                                game.setPhase_2(false);
                                game.setPhase_3(true);
                                %>
                        });
                    }
                }
                <%
                    }
                    else if (game.isPhase_3()) {
                %>
                        for (let i = 0; i < 5; i++) {
                            for (let j = 0; j < 5; j++) {
                                $("#game-grid-item" + String(i) + String(j)).click(function () {
                                    hitTarget(i,j,<%=request.getParameter("user")%>, 1,)
                                    //hitTarget(i,j,<%=request.getParameter("user")%>, 1,)
                                    $("#game-grid-item" + String(i) + String(j)).css("background-color", "red");
                                    <%
                                    game.setPhase_3(false);
                                    game.setPhase_4(true);
                                    %>
                                });
                            }
                        }
                <%
                    } else {
                %>

                <%
                    }
                %>
            </script>
        </div>
        <!--input id="ship-btn" type="submit" value="Commit" style="hidden"-->
    </form>
    <section id="game-grid-result"></section>
</body>
</html>