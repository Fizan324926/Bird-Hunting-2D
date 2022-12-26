using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        StartCoroutine(WaitandDestroy());

    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
    }
    void TrackMovement(){
        spriteRenderer.color=Color.red;
        Vector2 direction=rigidbody2D.velocity;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);
    }
    public void OnCollisionEnter2D(Collision2D collision){
        if(gameObject!=null){
            Destroy(gameObject);
        }
    }
    IEnumerator WaitandDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
