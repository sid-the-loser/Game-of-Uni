using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public int playerID; // player id to identiry every player (configured in the editor)

    [SerializeField] string tileID; // initial tile id (configured in the editor)
    [SerializeField] int tileNumber; // initial tile number (configured in the editor)

    Tile.TileData currentTileData; // current tile data

    string cardStringKey;

    int speed = 5; // speed of the player when moving between tiles (only applies to visuals/animation of a player jumping between tiles)

    Dictionary<string, Tile.TileData> _tileData = new Dictionary<string, Tile.TileData>(); // data of every tile in the board
    GameObject _camera; // camera game object

    void Start()
    {
        TurnManager.ResetManager();

        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            _tileData[$"{tile.GetComponent<Tile>()._tileData.tileID}{tile.GetComponent<Tile>()._tileData.tilePosition}"] = tile.GetComponent<Tile>()._tileData;
        }
        currentTileData = _tileData[$"{tileID}{tileNumber}"];

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (TurnManager.currentPlayer == playerID && !GameUIManager.paused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && BetweenSceneInputManager.currentInputID == playerID)
            {

                if (currentTileData.coinTossTile)
                {
                    Debug.Log("Coin Toss" + playerID.ToString());
                    GameUIManager.cardText = $"Player{playerID}\n\n";
                    if (TurnManager.CoinToss() == "opp")
                    {
                        GameUIManager.showCardOpp = true;
                        cardStringKey = GetRandomKey(CardData.cardsOpp);
                        GameUIManager.cardText += $"{cardStringKey}\n\n+${CardData.cardsOpp[cardStringKey]}\n\nPress [Enter]";
                    }
                    else
                    {
                        GameUIManager.showCardExp = true;
                        cardStringKey = GetRandomKey(CardData.cardsExp);
                        GameUIManager.cardText += $"{cardStringKey}\n\n-${CardData.cardsExp[cardStringKey]}\n\nPress [Enter]";
                    }
                    GameUIManager.paused = true;
                }

                else if (currentTileData.decisionTile)
                {
                    Debug.Log("Decision" + playerID.ToString());
                    GameUIManager.cardText = $"Player{playerID}\n\nPress Left or Right to choose between your decisions!\n[LeftArrow] for Masters and [RightArrow] for Jobs";
                    GameUIManager.showCardOpp = true;
                    GameUIManager.paused = true;
                }

                else if (currentTileData.oppOnlyTile)
                {
                    Debug.Log("Opp only" + playerID.ToString());
                    GameUIManager.cardText = $"Player{playerID}\n\n";
                    GameUIManager.showCardOpp = true;
                    cardStringKey = GetRandomKey(CardData.cardsOpp);
                    GameUIManager.cardText += $"{cardStringKey}\n\n+${CardData.cardsOpp[cardStringKey]}\n\nPress [Enter]";
                    GameUIManager.paused = true;
                }

                else
                {
                    Debug.Log("Nothing" + playerID.ToString());
                    tileNumber++;
                    TurnManager.PlayerTurnEnded();
                }

                if (currentTileData.giveOrTake)
                {
                    TurnManager.PlayerMoney[playerID] += currentTileData.moneyToGT;
                }

            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                BetweenSceneInputManager.currentInputID = playerID;
            }

            if (currentTileData.endingTile)
            {
                TurnManager.NotePlayerFinished(playerID);
                TurnManager.PlayerTurnEnded();
                Hide(true);
            }

        }

        else if (GameUIManager.paused)
        {
            if (currentTileData.coinTossTile || currentTileData.oppOnlyTile)
            {
                if (Input.GetKeyDown(KeyCode.Return) && BetweenSceneInputManager.currentInputID == playerID)
                {
                    Debug.Log(cardStringKey+playerID.ToString());
                    if (GameUIManager.showCardExp) TurnManager.PlayerMoney[playerID] -= CardData.cardsExp[cardStringKey]; else TurnManager.PlayerMoney[playerID] += CardData.cardsOpp[cardStringKey];
                    tileNumber++;
                    GameUIManager.showCardExp = false;
                    GameUIManager.showCardOpp = false;
                    GameUIManager.paused = false;
                    TurnManager.PlayerTurnEnded();
                }
                else if (Input.GetKeyUp(KeyCode.Return))
                {
                    BetweenSceneInputManager.currentInputID = playerID;
                }
            }
            else if (currentTileData.decisionTile)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && BetweenSceneInputManager.currentInputID == playerID)
                {
                    tileID = "b";
                    tileNumber = 1;
                    TurnManager.PlayerMoney[playerID] -= 1000;
                    GameUIManager.showCardOpp = false;
                    GameUIManager.paused = false;
                    TurnManager.PlayerTurnEnded();
                }
                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    BetweenSceneInputManager.currentInputID = playerID;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && BetweenSceneInputManager.currentInputID == playerID)
                {
                    tileID = "c";
                    tileNumber = 1;
                    TurnManager.PlayerMoney[playerID] += 500;
                    GameUIManager.showCardOpp = false;
                    GameUIManager.paused = false;
                    TurnManager.PlayerTurnEnded();

                }
                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    BetweenSceneInputManager.currentInputID = playerID;
                }
            }
            
        }

        UpdatePosition();
    }

    void UpdatePosition()
    {
        currentTileData = _tileData[$"{tileID}{tileNumber}"];
        if (currentTileData.tileObjectPosition != transform.position) transform.position = Vector3.Lerp(transform.position, _tileData[$"{tileID}{tileNumber}"].tileObjectPosition, speed * Time.deltaTime);

        if (TurnManager.currentPlayer == playerID)
        {
            if (this.transform.position.y < 4.3)
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, -10), speed * Time.deltaTime);
            }
            else
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(this.transform.position.x, 4.5f, -10), speed * Time.deltaTime);
            }

            if (this.transform.position.y > -4.3)
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, -10), speed * Time.deltaTime);
            }
            else
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(this.transform.position.x, -4.3f, -10), speed * Time.deltaTime);
            }
        }
    }

    static string GetRandomKey(Dictionary<string, int> dictionary)
    {
        // Create a random number generator
        System.Random random = new System.Random();

        // Generate a random index within the dictionary's count
        int randomIndex = random.Next(0, dictionary.Count);

        // Access the key at the random index
        string[] keys = new string[dictionary.Count];
        dictionary.Keys.CopyTo(keys, 0);
        string randomKey = keys[randomIndex];

        return randomKey;
    }

    
    void Hide(bool value)
    {
        this.GetComponent<Renderer>().enabled = !value;
        Transform parentTransform = transform;
        foreach (Transform childTransform in parentTransform)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.enabled = !value;
            }
        }
    }
    

}
