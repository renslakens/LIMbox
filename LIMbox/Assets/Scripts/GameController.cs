using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public int amountOfPlayers;
    private int currentPlayers = 0;
    public UnityEvent onPlayerFinished;
    public UnityEvent onPlayerLeft;

    // finish.onPlayerFinished.AddListener(HandlePlayerFinished);

    // ...

    public void HandlePlayerFinished()
    {
        Debug.Log("Player finished again!");
        currentPlayers++;
        if (currentPlayers == amountOfPlayers)
        {
            Debug.Log("All players finished!");
        }
    }

    public void HandlePlayerLeft(){
        Debug.Log("Player left again!");
        currentPlayers--;
    }

    // Start is called before the first frame update
    void Start()
    {
        onPlayerFinished.AddListener(HandlePlayerFinished);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
