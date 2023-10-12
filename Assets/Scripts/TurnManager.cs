using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager
{
    public static int currentPlayerID = 1;
    int maxPlayers = 6;

    public static int RollDie() { return Random.Range(1, 6); }

    public static void NextPlayerTurn() 
    {
        /*
        if (currentPlayerID < maxPlayers) 
        {
            currentPlayerID++;
        }
        else
        {
            currentPlayerID = 1;
        } */
        Debug.Log("No functionality added yet!");
    }
}
