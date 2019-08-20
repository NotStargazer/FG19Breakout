using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 1f;

    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(body, "Failed to find rigidbody2D component.");
    }

    private void Start()
    {
        GameMode.instance.OnBallAdded();
    }

    private void OnDestroy()
    {
        GameMode.instance.OnBallRemoved();
        //TODO Ball removed event
        //TODO If zero balls left, go to gameover screen
    }

    void FixedUpdate()
    {
        Vector3 velocity = body.velocity.normalized;
        velocity *= speed;
        body.velocity = velocity;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
