using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().take_damage(0);
        }
        var impact = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject); 
        Destroy(impact,1.18f);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);    
    }
}
