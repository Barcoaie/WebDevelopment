package examenWP;

import com.github.cliftonlabs.json_simple.JsonArray;
import com.github.cliftonlabs.json_simple.JsonObject;
import examenWP.domain.Document;
import examenWP.domain.Website;
import examenWP.model.DBManager;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import static java.util.Arrays.asList;

public class AssetController extends HttpServlet {

    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String action = req.getParameter("action");

        if((action!=null) && action.equals("getAllDocuments")) {
            DBManager dbManager = new DBManager();
            ArrayList<Document> allCourses = dbManager.getAllDocuments();
            JsonArray jsonValues = new JsonArray();
            for (Document participant : allCourses) {
                JsonObject jsonObject = new JsonObject();
                jsonObject.put("id", participant.getId());
                jsonObject.put("idWebSite", participant.getIdWebSite());
                jsonObject.put("name",participant.getName());
                jsonObject.put("keyword1", participant.getKeyword1());
                jsonObject.put("keyword2", participant.getKeyword2());
                jsonObject.put("keyword3", participant.getKeyword3());
                jsonObject.put("keyword4", participant.getKeyword4());
                jsonObject.put("keyword5", participant.getKeyword5());
                jsonValues.add(jsonObject);
            }
            PrintWriter out = new PrintWriter(resp.getOutputStream());
            out.println(jsonValues.toJson());
            out.flush();
        }
        if((action!=null) && action.equals("getAllWebsites")) {
            DBManager dbManager = new DBManager();
            ArrayList<Website> allCourses = dbManager.getAllWebsites();
            JsonArray jsonValues = new JsonArray();
            for (Website participant : allCourses) {
                JsonObject jsonObject = new JsonObject();
                jsonObject.put("id", participant.getId());
                jsonObject.put("url", participant.getUrl());
                ArrayList<Document> allDocs = dbManager.getAllDocuments();
                List<Document> filtered = allDocs.stream().filter(document -> document.getIdWebSite() == participant.getId()).collect(Collectors.toList());
                jsonObject.put("noOfDocs", filtered.size());
                jsonValues.add(jsonObject);
            }
            PrintWriter out = new PrintWriter(resp.getOutputStream());
            out.println(jsonValues.toJson());
            out.flush();
        }
        if((action!=null) && action.equals("updateKeywordsForDoc")) {
            String documentName = req.getParameter("documentName");
            String documentKeyword1 = req.getParameter("documentKeyword1");
            String documentKeyword2 = req.getParameter("documentKeyword2");
            String documentKeyword3 = req.getParameter("documentKeyword3");
            String documentKeyword4 = req.getParameter("documentKeyword4");
            String documentKeyword5 = req.getParameter("documentKeyword5");

            DBManager dbManager = new DBManager();
            dbManager.updateDoc(documentName, documentKeyword1, documentKeyword2, documentKeyword3, documentKeyword4, documentKeyword5);
        }
    }

    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

    }
}
