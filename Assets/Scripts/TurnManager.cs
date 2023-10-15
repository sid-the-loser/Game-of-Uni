using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TurnManager
{
    public static int currentPlayer = 1;
    static int maxPlayers = 4;
    static List<int> finishedPlayers = new List<int>();

    public static int CoinToss() {  return Random.Range(0, 1); }

    static void ClearPlayerFinished() {  finishedPlayers.Clear(); }

    public static void PlayerTurnEnded() 
    {
        if (!GetGameEnd())
        {
            if (currentPlayer >= maxPlayers)
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer++;
                Debug.Log(currentPlayer);
            }

            if (finishedPlayers.Contains(currentPlayer))
            {
                PlayerTurnEnded();
            }
        }
        else
        {
            Debug.Log("Game ended! Players still trying to get new turns!!"); 
            // we can change this to something that might take us to the score board scene or
            // something like that
        }
    }

    public static void NotePlayerFinished(int playerID) {  finishedPlayers.Add(playerID); }

    public static void RemovePlayerFinished(int playerID) { finishedPlayers.Remove(playerID); }
    public static bool GetGameEnd()
    {
        if (finishedPlayers.Count == maxPlayers)  return true;
        return false;
    }

    public static void ResetManager()
    {
        ClearPlayerFinished();
        currentPlayer = 1;
    }
}
