using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    // Get player
    private GameObject player;

    // Min height for respawn
    public float minHeightForDeath;

    // Respawn position
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < minHeightForDeath)
            player.transform.position = new Vector3(x, y, z);
        
    }
}
