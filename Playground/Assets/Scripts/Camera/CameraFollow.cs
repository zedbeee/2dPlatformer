using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector2 playerOffset;
    private Vector2 threshold;
    public float speed = 1f;
    private Rigidbody2D rigidBody;
    void Start()
    {
        threshold = calculateThreshold();
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Vector2 follow = player.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);
        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x)
            newPosition.x = follow.x;
        if (Mathf.Abs(yDifference) >= threshold.y)
            newPosition.y = follow.y;
        float moveSpeed;
            moveSpeed = Mathf.Abs(rigidBody.velocity.magnitude) > speed ? Mathf.Abs(rigidBody.velocity.magnitude) : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

    }
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 threshold = new Vector2(UnityEngine.Camera.main.orthographicSize * aspect.width / aspect.height, UnityEngine.Camera.main.orthographicSize);
        threshold.x -= playerOffset.x;
        threshold.y -= playerOffset.y;
        return threshold;
    } 
}
