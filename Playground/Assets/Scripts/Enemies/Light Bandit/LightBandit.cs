using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : Enemy
{
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimState", 2);
    }
    void Update()
    {
        
        wander();
    }
}
