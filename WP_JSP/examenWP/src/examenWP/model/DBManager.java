package examenWP.model;

import examenWP.domain.Document;
import examenWP.domain.Website;

import java.sql.*;
import java.util.ArrayList;

public class DBManager {
    private Statement stmt;

    public DBManager() {
        connect();
    }

    private void connect() {
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/exam","root","");
            stmt = connection.createStatement();
        } catch (Exception ex) {
            System.out.println("Connection error: " + ex.toString());
            ex.printStackTrace();
        }
    }

    public ArrayList<Document> getAllDocuments() {
        ResultSet resultSet;
        ArrayList<Document> courses = new ArrayList<>();
        try {
            resultSet = stmt.executeQuery("select * from documents");
            while (resultSet.next()) {
                courses.add(new Document(resultSet.getInt("id"), resultSet.getInt("idWebSite"), resultSet.getString("name"),
                        resultSet.getString("keyword1"), resultSet.getString("keyword2"), resultSet.getString("keyword3"), resultSet.getString("keyword4"), resultSet.getString("keyword5")));
            }
            resultSet.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return courses;
    }

    public ArrayList<Website> getAllWebsites() {
        ResultSet resultSet;
        ArrayList<Website> courses = new ArrayList<>();
        try {
            resultSet = stmt.executeQuery("select * from website");
            while (resultSet.next()) {
                courses.add(new Website(resultSet.getInt("id"), resultSet.getString("url")));
            }
            resultSet.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return courses;
    }

    public void updateDoc(String documentName, String documentKeyword1, String documentKeyword2, String documentKeyword3, String documentKeyword4, String documentKeyword5) {
        try {
            stmt.executeUpdate("update documents set keyword1 ='"+documentKeyword1+"', keyword2='"+documentKeyword2+"', keyword3 ='"+documentKeyword3+"', keyword4='"+documentKeyword4+"', keyword5='"+documentKeyword5+"' where name='"+documentName+"'");
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
}
