package vapoare.controller;

import vapoare.model.DBManager;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;

public class GameController extends HttpServlet {
    private int count1;
    private int count2;
    private int count3;
    public GameController() { super(); count1 = 0; count2 = 0; count3 = 0;}

    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String action = req.getParameter("action");

        if ((action != null) && action.equals("placeVapor")) {
            int UID = Integer.parseInt(req.getParameter("UID"));
            DBManager dbManager = new DBManager();
            boolean res = false;
            switch (UID) {
                case 1:
                    if (count1 == 2) {
                        System.out.println("maximum nr of ships placed");
                        break;
                    }
                    count1++;
                    res = dbManager.placeVapor(Integer.parseInt(req.getParameter("i"))
                            , Integer.parseInt(req.getParameter("j"))
                            , UID
                            , count1);
                    break;
                case 2:
                    if (count2 == 2) {
                        System.out.println("maximum nr of ships placed");
                        break;
                    }
                    count2++;
                    res = dbManager.placeVapor(Integer.parseInt(req.getParameter("i"))
                            , Integer.parseInt(req.getParameter("j"))
                            , UID
                            , count2);
                    break;
                case 3:
                    if (count3 == 2) {
                        System.out.println("maximum nr of ships placed");
                        break;
                    }
                    count3++;
                    res = dbManager.placeVapor(Integer.parseInt(req.getParameter("i"))
                            , Integer.parseInt(req.getParameter("j"))
                            , UID
                            , count3);
                    break;
                default:
                    System.out.println("no user matching the requesting ID");
            }
            if (res) {
                System.out.println("ship placed");
            }
        }

        if ((action != null) && action.equals("hitVapor")) {
            DBManager dbManager = new DBManager();
            boolean res = dbManager.hitVapor(Integer.parseInt(req.getParameter("i"))
                    ,Integer.parseInt(req.getParameter("j"))
                    ,Integer.parseInt(req.getParameter("UID"))
                    );
            if (res) {
                System.out.println("ship hit");
            }
            else {
                System.out.println("ship miss");
            }
        }

        if ((action != null) && action.equals("checkPlace")) {
            DBManager dbManager = new DBManager();
            boolean res = dbManager.checkPlace(Integer.parseInt(req.getParameter("i"))
                    ,Integer.parseInt(req.getParameter("j")));
        }
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.sendRedirect("phase3.jsp");
    }
}
