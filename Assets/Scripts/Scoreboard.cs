using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "";
        for (int i = 1; i <= 4; i++)
        {
            this.GetComponent<Text>().text += $"Player{i} : ${TurnManager.PlayerMoney[i]}\n";
        }

        if (Input.GetKeyDown(KeyCode.Space) && BetweenSceneInputManager.currentInputID == 5)
        {
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            BetweenSceneInputManager.currentInputID = 5;
        }
    }
}
