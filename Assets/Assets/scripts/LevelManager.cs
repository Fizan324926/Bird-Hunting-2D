using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] menus;
    GameObject r;
    GameObject b;
    private AudioManager audioManager;
    TextMesh t;
    

    public int levelNumber=0;
    public static LevelManager instance;
    void DisableAllLevels(){
        foreach(var level in levels){
            level.SetActive(false);
        }
    }
   
    void DisableAllMenus(){
        foreach(var menu in menus){
            menu.SetActive(false);
        }
    }
    public void StartGame(){

        DisableAllLevels();
        DisableAllMenus();
        levelNumber=0;
        levels[levelNumber].SetActive(true);
        audioManager.PlaySound("start");
    }
    public void Next(){
        DisableAllLevels();
        DisableAllMenus();
        
        levels[levelNumber+1].SetActive(true);
         audioManager.PlaySound("start");
        levelNumber++;
    }
    public void Replay(){
        DisableAllLevels();
        DisableAllMenus();
        levels[levelNumber].SetActive(true);
         audioManager.PlaySound("start");
    }
    public void GoHome(){
        DisableAllLevels();
        DisableAllMenus();
         if(r.activeInHierarchy==false){
                r.SetActive(true);
            }
            if(b.activeInHierarchy==false){
                b.SetActive(true);
            }
        menus[0].SetActive(true);
    }
    public void GameWin(){
        DisableAllLevels();
        DisableAllMenus();
        menus[1].SetActive(true);
         audioManager.PlaySound("win");
    }
    public void GameReplay(){
        DisableAllLevels();
        DisableAllMenus();
        menus[2].SetActive(true);
         audioManager.PlaySound("loose");

        
    }
   
    private void Awake(){
        if(instance==null){
            instance=this;

        }
        else{
            Destroy(instance);
        }
       // DisableAllLevels();
        //Next();
    }
    void Start()
    {
        t=GameObject.FindWithTag("levelNumber").GetComponent<TextMesh>();
        audioManager=AudioManager.instance;
        r=GameObject.FindWithTag("bird");
        b=GameObject.FindWithTag("black bird");
        DisableAllMenus();
        DisableAllLevels();
        menus[0].SetActive(true);
        AudioManager.instance.PlaySound("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(t!=null){
        
            t.text=levelNumber+1+"";  
        }
        
    }
}
