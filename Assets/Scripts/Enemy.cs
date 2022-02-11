using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody enemyRb;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        // Find ball
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);
    }
}
