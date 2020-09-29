using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public float vision_range;
    public int health;
    public int damage;
    public Transform player;

    private int current_waypoint;
    private int facing_direction = -1;
    protected Animator animator;
    protected string state;
    private float previous_x;

    void Start()
    {
        current_waypoint = 0;
        previous_x = transform.position.x;
    }

    public void take_damage(int damage)
    {
        GetComponent<Animator>().SetBool("Hurt", true);
        health -= damage;
        if (health < 1)
            die();
    }
    public void wander()
    {
        previous_x = transform.position.x;
        if (transform.position.x == waypoints[current_waypoint].position.x)
            current_waypoint = current_waypoint == waypoints.Length - 1 ? 0 : current_waypoint + 1;
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[current_waypoint].position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
         correct_facing_direction();
    }

    private void correct_facing_direction()
    {
        if ((transform.position.x - previous_x) * facing_direction < 0) { 
            facing_direction *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
    protected bool can_see_player()
    {
        float distance_to_player = transform.position.x - player.position.x;
        bool can_see_player = (Math.Abs(distance_to_player) < vision_range) && (distance_to_player * facing_direction) <= 0 && Math.Abs(transform.position.y - player.position.y) < 1.5;
        return can_see_player;
    }
    private void die()
    {
        GetComponent<Animator>().SetBool("Death", true);
        GetComponent<BoxCollider2D>().enabled = false;
        state = "dead";
    }
}
