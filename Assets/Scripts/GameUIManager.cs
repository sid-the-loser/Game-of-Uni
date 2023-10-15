using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static bool showCardOpp = false;
    public static bool showCardExp = false;
    public static string cardText = string.Empty;

    GameObject cardOpp;
    GameObject cardExp;
    GameObject cardTextBox;

    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        cardOpp = GameObject.Find("OpportunitiesCard");
        cardExp = GameObject.Find("ExpensesCard");
        cardTextBox = GameObject.Find("TextBox");
    }

    // Update is called once per frame
    void Update()
    {
        cardExp.GetComponent<Renderer>().enabled = showCardExp;
        cardOpp.GetComponent<Renderer>().enabled = showCardOpp;
        if (showCardOpp || showCardExp)
        {
            cardTextBox.GetComponent<Text>().text = cardText;
        }
        else
        {
            cardTextBox.GetComponent<Text>().text = string.Empty;
        }
    }
}
