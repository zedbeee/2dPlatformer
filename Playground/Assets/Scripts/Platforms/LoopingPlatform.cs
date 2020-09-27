using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoopingPlatform : MonoBehaviour
{
    public Transform[] positions;
    public float speed;
    private int target;
    void Start()
    {
        target = 0;
    }

    
    void FixedUpdate()
    {
        //if (positions.Length > 0)
        //    Move();
    }

    //private void Move()
    //{
    //    if (transform.position.x == positions[target].x && transform.position.y == positions[target].y)
    //        Debug.Log("We made it!");

    //    else
    //        transform.position = Vector3.MoveTowards(transform.position, positions[target], speed * Time.deltaTime);
    //}

    //private int GetNext()
    //{
    //    int i = target == positions.Length - 1 ? 0 : target + 1;
    //    Debug.Log("Next is " + i);
    //    return i;
    //}
}
