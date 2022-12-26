using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color=Color.white;
        Vector2 bowPosition=transform.position;
        Vector2 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction=mousePosition-bowPosition;
        faceMouse();
    }
    void faceMouse(){
        transform.right=direction;
    }
}
