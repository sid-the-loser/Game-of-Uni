using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public class TileData
    {
        public string sectionID {  get; set; }
        public int tileID {  get; set; }
        public bool decisionTile {  get; set; }
        public bool endTile { get; set; }
        public Vector3 tilePosition { get; set; }
    }

    [SerializeField] string sectionID;
    [SerializeField] int tileID;
    [SerializeField] bool decisionTile;
    [SerializeField] bool endTile;

    public TileData _tileData = new TileData();

    private void OnEnable()
    {
        _tileData.sectionID = sectionID;
        _tileData.tileID = tileID;
        _tileData.decisionTile = decisionTile;
        _tileData.endTile = endTile;
        _tileData.tilePosition = transform.position;
    }
}