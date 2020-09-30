using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDive : MonoBehaviour
{
   public Rigidbody2D rb;
    void Start()
    {
    }
    void update(){
     
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<Enemy>().take_damage(1);
        Destroy(gameObject);
    }
  
}
