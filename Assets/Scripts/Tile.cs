using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public class TileData
    {
        public string tileID { get; set; }
        public int tilePosition { get; set; }
        public bool coinTossTile { get; set; }
        //public bool startingTile { get; set; }
        public bool decisionTile { get; set; }
        public bool oppOnlyTile { get; set; }
        public bool giveOrTake { get; set; }
        public int moneyToGT { get; set; }
        public bool endingTile { get; set; }
        public Vector3 tileObjectPosition { get; set; }
    }

    [SerializeField] string tileID;
    [SerializeField] int tilePosition;
    [SerializeField] bool coinTossTile = true; // makes the player toss a coin and land on 
    //[SerializeField] bool startingTile; // does nothing but give the player a little cash and send them to next tile
    [SerializeField] bool decisionTile;
    [SerializeField] bool oppOnlyTile;
    [SerializeField] bool giveOrTake;
    [SerializeField] int moneyToGT;
    [SerializeField] bool endingTile;

    public TileData _tileData = new TileData();

    private void OnEnable()
    {
        _tileData.tileID = tileID;
        _tileData.tilePosition = tilePosition;
        _tileData.coinTossTile = coinTossTile;
        //_tileData.startingTile = startingTile;
        _tileData.decisionTile = decisionTile;
        _tileData.oppOnlyTile = oppOnlyTile;
        _tileData.giveOrTake = giveOrTake;
        _tileData.moneyToGT = moneyToGT;
        _tileData.endingTile = endingTile;
        _tileData.tileObjectPosition = transform.position;
    }
}
