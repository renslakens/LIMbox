using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityEvent onPlayerFinished;
    public UnityEvent onPlayerLeft;
    public float delay = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.tag == "Player")
        {
            // Start a coroutine to delay the invocation of the event
            StartCoroutine(DelayedInvoke());
        }
    }

    private IEnumerator DelayedInvoke()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(0.1f);

        // Invoke the event
        onPlayerFinished.Invoke();
        Debug.Log("Player finished!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object leaving is the player
        if (collision.gameObject.tag == "Player")
        {
            onPlayerLeft.Invoke(); // Invoke the new event
            Debug.Log("Player left!");
        }
    }

}
