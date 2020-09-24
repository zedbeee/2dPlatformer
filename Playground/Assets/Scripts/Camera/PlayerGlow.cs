using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position;
    }
}
