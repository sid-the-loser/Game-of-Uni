using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerID;
    [SerializeField] string sectionID;
    [SerializeField] int tileID;

    float playerSpeed = 5f;

    Dictionary<string, Tile.TileData> tileObjects = new Dictionary<string, Tile.TileData>();

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tile"))
        {
            if (obj != null)
            {
                tileObjects[$"{obj.GetComponent<Tile>()._tileData.sectionID}{obj.GetComponent<Tile>()._tileData.tileID}"] = obj.GetComponent<Tile>()._tileData;
            }
            else
            {
                Debug.Log("Bruh, found a null!");
            }
        }

        foreach (string key in tileObjects.Keys)
        {
            Debug.Log(key);
        }
    }

    private void Update()
    {
        if (TurnManager.currentPlayerID == playerID)
        {
            if (!tileObjects[$"{sectionID}{tileID}"].endTile)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (tileObjects[$"{sectionID}{tileID}"].decisionTile)
                    {
                        //something to be done on the decision tile
                    }
                    else
                    {
                        tileID++;
                    }
                }
            }
            else
            {
                TurnManager.NextPlayerTurn();
            }
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, tileObjects[$"{sectionID}{tileID}"].tilePosition, playerSpeed*Time.deltaTime);
    }
}
