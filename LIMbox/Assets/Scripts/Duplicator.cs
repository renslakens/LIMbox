using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : MonoBehaviour
{
    public GameObject playerPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.tag == "Player")
        {
            // Create a new player at the player's position
            Instantiate(playerPrefab, collision.transform.position, Quaternion.identity);

            // Destroy self
            Destroy(this.gameObject);
        }
    }
}
