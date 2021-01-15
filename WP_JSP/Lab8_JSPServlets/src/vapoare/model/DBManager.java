package vapoare.model;

import javafx.util.Pair;
import vapoare.domain.Game;
import vapoare.domain.User;

import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class DBManager {
    private Statement stmt;
    private final Game game;

    public DBManager() {
        connect();
        game = new Game(new ArrayList<>(), true, false, false, false);
    }

    private void connect() {
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/vapoare","root", "");
            stmt = connection.createStatement();
        } catch (Exception ex) {
            System.out.println("Connection error: " + ex.toString());
            ex.printStackTrace();
        }
    }

    public User authenticate(String username, String password) {
        ResultSet resultSet;
        User user = null;
        System.out.println(username + " " + password);
        try {
            resultSet = stmt.executeQuery("select * from users where username = '" + username + "' and password='" + password + "'");
            if (resultSet.next()) {
                user = new User(resultSet.getInt("id"), resultSet.getString("username"), resultSet.getString("password"));
            }
            resultSet.close();
        } catch (SQLException throwable) {
            throwable.printStackTrace();
        }
        game.getUserList().add(user);
        return user;
    }

    public boolean placeVapor(int i, int j, int UID, int ID) {
        boolean resultSet = false;
        System.out.println(i + " " + j + " " + UID + " " + ID);
        try {
            stmt.executeUpdate("update `vapor` set X_pos = " + i + ", Y_pos = " + j + " where UID = " + UID + " and ID = " + ID);
            resultSet = true;
        } catch (SQLException throwable) {
            throwable.printStackTrace();
        }
        return resultSet;
    }
    
    public boolean hitVapor(int i, int j, int UID){//, int ID) {
        boolean result = false;
        ResultSet resultSet;
        Pair<Integer,Integer> pair = null;
        System.out.println(i + " " + j + " " + UID);// + " " + ID);
        try {
            resultSet = stmt.executeQuery("select X_pos, Y_pos from `vapor` where UID = " + UID);// + " and ID = " + ID);
            while (resultSet.next()) {
                pair = new Pair<>(resultSet.getInt("X_pos"), resultSet.getInt("Y_pos"));
                if ((pair != null) && pair.getKey().equals(i) && pair.getValue().equals(j)) {
                    return result = true;
                }
            }
            if ((pair != null) && pair.getKey().equals(i) && pair.getValue().equals(j)) {
                result = true;
            }
        } catch (SQLException throwable) {
            throwable.printStackTrace();
        }
        return result;
    }

    public boolean checkPlace(int i, int j) {
        boolean result = true;
        ResultSet resultSet;
        try {
            resultSet = stmt.executeQuery("select X_pos, Y_pos from `vapor` where X_pos = " + i + " and Y_pos = " + j);
            if (resultSet.next()) {
                result = false;
            }
        } catch (SQLException throwable) {
            throwable.printStackTrace();
        }
        return result;
    }

}
