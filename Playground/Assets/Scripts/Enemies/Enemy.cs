using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public float vision_range;
    public int health;
    public int damage;

    private int current_health;
    private int current_waypoint;
    private int facing_direction;
    protected Animator animator;

    void Start()
    {
        current_health = health;
        current_waypoint = 0;
        facing_direction = 1;
    }

    public void take_damage(int damage)
    {
        current_health -= damage;
        if (current_health < 1)
            die();
    }
    private void die()
    {
        Destroy(gameObject);
    }
    public void wander()
    {
        if (transform.position.x == waypoints[current_waypoint].position.x)
        {
            current_waypoint = current_waypoint == waypoints.Length - 1 ? 0 : current_waypoint + 1;
            flip();
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[current_waypoint].position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }

    private void flip()
    {
        facing_direction *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void adjust_facing_direction()
    {
        if ((transform.position.x * facing_direction) <= 0)
            flip();
    }
}
