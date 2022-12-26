using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    private Levels levelData;
    private int totalThrows;
    private int totalBirds=2;
    private int score;
    private int kills;
    private int throws;
    private static ScoreManager instance;
    private ScoreManager(){

    }
    public static ScoreManager getInstance(){
        if(instance==null){
            instance=new ScoreManager();
            return instance;
        }
        else return instance;
    }


     public void setTotalBirds(int birds){
        this.totalBirds=birds;
    }
    public int getTotalBirds(){
        return this.totalBirds;
    }

     public void setTotalThrows(int throws){
        this.totalThrows=throws;
    }
    public int getTotalThrows(){
        return this.totalThrows;
    }

    public void addThrows(){
        this.throws++;
    }
    public int getThrows(){
        return this.throws;
    }
    public void decreaseThrows(){
        this.throws--;
    }
    public void resetThrows(){
        this.throws=0;
    }

     public void addScore(int score){
        this.score+=score;
    }
    public int getScore(){
        return this.score;
    }
     public void addKills(){
        this.kills++;
    }
    public int getKills(){
        return this.kills;
    }

    // Start is called before the first frame update
   
}
