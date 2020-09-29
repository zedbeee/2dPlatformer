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
        if (positions.Length > 0)
            transform.position = positions[0].position;
        GetNext();
    }

    
    void FixedUpdate()
    {
        if (positions.Length > 0)
            Move();
    }

    private void Move()
    {
        if (transform.position == positions[target].position)
            GetNext();
        else
            transform.position = Vector3.MoveTowards(transform.position, positions[target].position, speed * Time.deltaTime);
    }

    private void GetNext()
    {
        target = target == positions.Length - 1 ? 0 : target + 1;
    }
}
