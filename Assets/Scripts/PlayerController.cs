using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // store player rigid body
    private Rigidbody playerRb;
    private float minHeight = -10f;

    // Get focal point
    private GameObject focalPoint;

    // Speed
    public float speed = 10.0f;

    // Check if player picked up power up
    public bool hasPowerup = false;

    // Set powerup indicator
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        }

        // Make power up indicator follow player
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0, 0);

        if (playerRb.position.y < minHeight)
        {
            playerRb.position = new Vector3(0, 1, -13);
        }
    }

    // On trigger enter method
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            speed = 20f;

            // Set powerup indicator active
            powerupIndicator.gameObject.SetActive(true);

            // Destroy powerup item
            Destroy(other.gameObject);

            // Call coroutine
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    // coroutine for powerup countdown
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        speed = 10f;

        // Set powerup indicator unactive
        powerupIndicator.gameObject.SetActive(false);
    }

    // On collision trigger
    private void OnCollisionEnter(Collision collision)
    {
        // Get ball rigidbody
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // Move position away from player
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

        // Check if player collided with ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Set force to move the ball
            ballRigidbody.AddForce(awayFromPlayer * 5, ForceMode.Impulse);

            Debug.Log("Player collided with: " + collision.gameObject.name);
        }

        // Check if player collided with ball and has powerup
        if (collision.gameObject.CompareTag("Ball") && hasPowerup)
        {
            // Set force to move the ball
            ballRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);

            // Debug
            Debug.Log("Player Collided with: " + collision.gameObject.name + " while powerup is " + hasPowerup);
        }
    }
}
