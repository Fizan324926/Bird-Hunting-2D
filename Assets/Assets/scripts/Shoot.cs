using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    GameObject r;
    GameObject b;
    public float launchSpeed;
    public HealthBar throwsHealth;
    
   // public GameObject fill;
    public static  float maxHealth;
    public static float currentThrowsHealth;
    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        r=GameObject.FindWithTag("bird");
        b=GameObject.FindWithTag("black bird");
        maxHealth=Levels.instance.GetThrowsHealth();
        
        currentThrowsHealth=maxHealth;
        throwsHealth.setMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentThrowsHealth==0){
            LevelManager.instance.GameReplay();
            if(r.activeInHierarchy==false){
                r.SetActive(true);
            }
            if(b.activeInHierarchy==false){
                b.SetActive(true);
            }
            currentThrowsHealth=maxHealth;
            ManageBird.redBirdCurHealth=ManageBird.redBirdMaxHealth;
            ManageBird.blackBirdCurHealth=ManageBird.blackBirdMaxHealth;
        }
         if(Input.GetKeyDown(KeyCode.Space)){
            
                shoot();
                currentThrowsHealth--;
                throwsHealth.setHealth(currentThrowsHealth);
                
            
            
            
         }
    }
    void shoot(){
        //scoreManager.addThrows();
        GameObject arrowInst=Instantiate(Arrow,transform.position,transform.rotation);
        arrowInst.GetComponent<Rigidbody2D>().AddForce(transform.right*launchSpeed);
    }
}
