using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID; // player id to identiry every player (configured in the editor)

    [SerializeField] string tileID; // initial tile id (configured in the editor)
    [SerializeField] int tileNumber; // initial tile number (configured in the editor)

    int money = 0;

    Tile.TileData currentTileData; // current tile data

    int speed = 5; // speed of the player when moving between tiles (only applies to visuals/animation of a player jumping between tiles)

    Dictionary<string, Tile.TileData> _tileData = new Dictionary<string, Tile.TileData>(); // data of every tile in the board
    GameObject _camera; // camera game object

    void Start()
    {
        TurnManager.RemovePlayerFinished(playerID);
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            _tileData[$"{tile.GetComponent<Tile>()._tileData.tileID}{tile.GetComponent<Tile>()._tileData.tilePosition}"] = tile.GetComponent<Tile>()._tileData;
        }
        currentTileData = _tileData[$"{tileID}{tileNumber}"];

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (TurnManager.currentPlayer == playerID && !currentTileData.endingTile)
        {
            Hide(false);
            if (Input.GetKeyDown(KeyCode.Space) && BetweenSceneInputManager.currentInputID == playerID)
            {

                if (currentTileData.coinTossTile)
                {
                    Debug.Log("Heyo" + playerID.ToString());


                }
                else if (currentTileData.decisionTile)
                {

                }
                else if (currentTileData.startingTile)
                {
                    Debug.Log("Huh?" + playerID.ToString());
                    tileNumber++;
                    TurnManager.PlayerTurnEnded();
                }
                else
                {
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                BetweenSceneInputManager.currentInputID = playerID;
            }

                if (currentTileData.endingTile)
            {
                TurnManager.NotePlayerFinished(playerID);
            }
            currentTileData = _tileData[$"{tileID}{tileNumber}"];
        }
        else
        {
            Hide(true);
        }

        UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.position = _tileData[$"{tileID}{tileNumber}"].tileObjectPosition;
        if (TurnManager.currentPlayer == playerID) _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(0, this.transform.position.y, -10), speed * Time.deltaTime);
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
