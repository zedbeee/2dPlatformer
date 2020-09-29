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

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<Enemy>().take_damage(1);
        Destroy(gameObject);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);    
    }
}
