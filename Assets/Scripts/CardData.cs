using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public static Dictionary<string, int> cardsOpp = new Dictionary<string, int> // this is the data for opportunities
    {
        {"Test 1", 10}, // { <card description> , <amount added>
        {"Test 2", 100}
    };

    public static Dictionary<string, int> cardsExp = new Dictionary<string, int> // this is the data for expenses
    {
        {"Test 1", 10}, // { <card description> , <amount deducted>
        {"Test 2", 20}
    };
}
