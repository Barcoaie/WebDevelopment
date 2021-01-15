package vapoare.controller;

import vapoare.domain.Game;
import vapoare.domain.User;
import vapoare.model.DBManager;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.util.ArrayList;

public class LoginController extends HttpServlet {
    private int i;
    private Game game;
    public LoginController() {
        super();
        game = new Game(new ArrayList<>(), false, false, false, false);
    }

    protected void doPost(HttpServletRequest request,
                          HttpServletResponse response) throws ServletException, IOException {
        String username = request.getParameter("username");
        String password = request.getParameter("password");
        RequestDispatcher dispatcher = null;

        DBManager dbManager = new DBManager();
        User user = dbManager.authenticate(username, password);
        if (user != null && i < 2) {
            dispatcher = request.getRequestDispatcher("/success.jsp");
            HttpSession session = request.getSession();
            System.out.println(session.getId());
            this.i++;
            game.getUserList().add(user);
            session.setAttribute("game", game);
            session.setAttribute("user", user);
            System.out.println(session.getAttribute("user"));
        } else {
            dispatcher = request.getRequestDispatcher("/error.jsp");
        }
        dispatcher.forward(request, response);
    }
}
