using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : Enemy
{
    private enum states {
        idle,
        combat_ready,
        }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimState", 2);
    }
    void Update()
    {
        if(state!= "dead")
            action_handler();
    }

    private void action_handler()
    {
        if (!can_see_player())
            idle();
        else
            switch (state)
            {
                case "idle":
                    combat_ready();
                    break;
                default:
                    combat_ready();
                    break;
            }
    }
    private void idle()
    {
        animator.SetInteger("AnimState", 2);
        state = states.idle.ToString();
        wander();
    }
    private void combat_ready()
    {
        animator.SetInteger("AnimState", 1);
        state = states.combat_ready.ToString();
    }

}
