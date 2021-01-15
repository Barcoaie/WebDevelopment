package vapoare.domain;

import java.util.ArrayList;

public class Game {
    private ArrayList<User> userList;
    private boolean isPhase_1;
    private boolean isPhase_2;
    private boolean isPhase_3;
    private boolean isPhase_4;

    public Game(ArrayList<User> userList, boolean isPhase_1, boolean isPhase_2, boolean isPhase_3, boolean isPhase_4) {
        this.userList = userList;
        this.isPhase_1 = isPhase_1;
        this.isPhase_2 = isPhase_2;
        this.isPhase_3 = isPhase_3;
        this.isPhase_4 = isPhase_4;
    }

    public boolean isPhase_2() {
        return isPhase_2;
    }

    public void setPhase_2(boolean phase_2) {
        isPhase_2 = phase_2;
    }

    public boolean isPhase_1() {
        return isPhase_1;
    }

    public void setPhase_1(boolean phase_1) {
        isPhase_1 = phase_1;
    }

    public ArrayList<User> getUserList() {
        return userList;
    }

    public void setUserList(ArrayList<User> userList) {
        this.userList = userList;
    }

    public boolean isPhase_3() { return isPhase_3; }

    public void setPhase_3(boolean phase_3) { isPhase_3 = phase_3; }

    public boolean isPhase_4() { return isPhase_4; }

    public void setPhase_4(boolean phase_4) { isPhase_4 = phase_4; }
}
