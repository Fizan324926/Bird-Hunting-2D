using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
   
    int levelNumber;
    public float   totalBlackBirds=1;
    public float totalRedBirds=1;
    public static Levels instance;
    private Levels(){

    }
    public float GetBlackBirdMaxHealth(){
        return this.totalBlackBirds*10;
    }
    public float GetThrowsHealth(){
        if(levelNumber%2==0){
            return this.totalBlackBirds*10+5+this.totalBlackBirds*7;
        }
        else{
            return this.totalBlackBirds*10+12+this.totalBlackBirds*7;
        }
        
    }
    
    public float GetRedBirdMaxHealth(){
        return this.totalRedBirds*7;
    }
    public static Levels getInstance(){
        if(instance==null){
            instance=new Levels();
            return instance;
        }
        else return instance;
    }
    void Start(){
        levelNumber=LevelManager.instance.levelNumber;
    }
   
}
