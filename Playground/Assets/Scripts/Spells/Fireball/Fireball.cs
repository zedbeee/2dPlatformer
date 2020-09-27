using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitinfo){
        //check if hitinfo touches a enemy
        //else destroy
        Destroy(gameObject); 
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);    
    }
}
