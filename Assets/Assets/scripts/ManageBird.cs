using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageBird : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public HealthBar healthBar;
    Vector3 intialPos;
    public float birdSpeed;
     bool isForward;
    Vector3 forward;
    Vector3 backward;
    private AudioManager audioManager;
    private ScoreManager scoreManager;
    private Levels levelData;
    private int black_bird_score=15;
    private int bird_score=10;
    
    public static float blackBirdMaxHealth;
    public static float redBirdMaxHealth;
    public static float blackBirdCurHealth;
    public static float redBirdCurHealth;

    
    //float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        audioManager=AudioManager.instance;
        //scoreManager=ScoreManager.getInstance();
        levelData=Levels.getInstance();
       
        intialPos=transform.position;
        forward=new Vector3(0,0,0);
        backward=new Vector3(0,180,0);

        // health bar


        blackBirdMaxHealth=levelData.GetBlackBirdMaxHealth();
        redBirdMaxHealth=levelData.GetRedBirdMaxHealth();
        blackBirdCurHealth=blackBirdMaxHealth;
        redBirdCurHealth=redBirdMaxHealth;
        healthBar.setBlackSMaxHealth(blackBirdMaxHealth);
        healthBar.setRedSMaxHealth(redBirdMaxHealth);
       
    }
    void Win(){
         
            LevelManager.instance.GameWin();
           
            redBirdCurHealth=redBirdMaxHealth;
            blackBirdCurHealth=blackBirdMaxHealth;
            Shoot.currentThrowsHealth=Shoot.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(redBirdCurHealth==0&&blackBirdCurHealth==0){
            
        }
        if(transform.position.x>10||transform.position.y>5){
            transform.position=intialPos;
        }
        
        if(transform.localPosition.x>=end.transform.localPosition.x){
            isForward=false;
        }
        if(transform.localPosition.x<=start.transform.localPosition.x){
            isForward=true;
        }
        if(isForward){
            moveToEnd();
            
        }
        else{
            moveToStart();
        }
        
        
    }
   
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="arrow"){
            audioManager.PlaySound("shoot");
           // scoreManager.addKills();

            if(gameObject.tag=="bird"){
               // scoreManager.addScore(bird_score);
                redBirdCurHealth-=1;
                healthBar.setHealth(redBirdCurHealth);
                if(redBirdCurHealth==0&&blackBirdCurHealth==0){
                    Win();
                }
                if(redBirdCurHealth==0){
                    gameObject.SetActive(false);
                }
                
            }
            else{
                //scoreManager.addScore(black_bird_score);
                blackBirdCurHealth-=1;
                healthBar.setHealth(blackBirdCurHealth);
                if(redBirdCurHealth==0&&blackBirdCurHealth==0){
                    Win();
                }
                if(blackBirdCurHealth==0){
                    gameObject.SetActive(false);
                }
            }
        }
        
    }
   
    void moveToStart(){
        transform.localPosition=Vector3.MoveTowards(transform.localPosition,start.transform.localPosition,Time.deltaTime*birdSpeed);
        transform.eulerAngles=backward;
        
    }
    void moveToEnd(){
        transform.localPosition=Vector3.MoveTowards(transform.localPosition,end.transform.localPosition,Time.deltaTime*birdSpeed);
        transform.eulerAngles=forward;
    }
}
