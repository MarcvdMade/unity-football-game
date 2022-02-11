using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{

    // Ball body
    private Rigidbody ballRb;

    // Player
    private GameObject player;
    private float playerScore = 0f;
    public TextMeshPro playerScoreText;

    // Enemy
    private GameObject enemy;
    private float enemyScore = 0f;
    public TextMeshPro enemyScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Get ball body
        ballRb = GetComponent<Rigidbody>();

        // Get player
        player = GameObject.Find("Player");
        playerScoreText.text = playerScore.ToString();

        // Get enemy
        enemy = GameObject.Find("Enemy");
        enemyScoreText.text = enemyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // On collision trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blue Goal") || collision.gameObject.CompareTag("Red Goal"))
        {
            // Check if ball is in red goal
            if (collision.gameObject.CompareTag("Red Goal"))
            {
                // Add point to player
                playerScore++;
                playerScoreText.text = playerScore.ToString();

                // Debug
                Debug.Log("Scored in red goal");
            }

            // Check if ball is in blue goal
            if (collision.gameObject.CompareTag("Blue Goal"))
            {
                // Add point to enemy
                enemyScore++;
                enemyScoreText.text = enemyScore.ToString();

                // Debug
                Debug.Log("Scored in blue goal");
            }

            // Reset ball position
            transform.position = new Vector3(0, 1, 0);
            ballRb.velocity = Vector3.zero;

            // Reset player position
            player.transform.position = new Vector3(0, 1, -13);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // Reset enemy position
            enemy.transform.position = new Vector3(0, 1, 11);
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
