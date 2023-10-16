using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager
{
    public static int currentPlayer = 1;
    static int maxPlayers = 4;
    static List<int> finishedPlayers = new List<int>();

    public static Dictionary<int, int> PlayerMoney = new Dictionary<int, int> // { <player id> , <money> }
    {
        {1, 0}, {2, 0}, {3,  0}, {4, 0}
    };

    public static string CoinToss() { if (Random.Range(0, 2) > 0) return "opp"; else return "exp"; }

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
            SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);
        }
    }

    public static void NotePlayerFinished(int playerID) {  if (!finishedPlayers.Contains(playerID)) finishedPlayers.Add(playerID); }

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
        PlayerMoney = new Dictionary<int, int> {{1, 0}, {2, 0}, {3,  0}, {4, 0}};
    }
}
