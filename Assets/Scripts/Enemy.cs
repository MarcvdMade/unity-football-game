using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float minHeight = -10f;

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
        if (!PauseMenu.GameIsPaused)
        {
            Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
            enemyRb.AddForce( lookDirection * speed);
        }

        if (enemyRb.position.y < minHeight)
        {
            enemyRb.position = new Vector3(0, 1, 11);
        }
    }
}
