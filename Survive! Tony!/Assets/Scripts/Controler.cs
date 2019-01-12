using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Controler: MonoBehaviour{

    public Tile tile;
    public static int resource;
    public static List<List<Tile>> tiles;
    public float waterLevel;
    public float fillInitTime;
    public float fillSpeed;
    
    public GameObject water;
    public Player player;

    void Start(){
        build();
    }

    private void Update(){
        waterLevel = (Time.timeSinceLevelLoad - fillInitTime) * fillSpeed;
        water.transform.position = new Vector3(0, waterLevel, 0);
        if (waterLevel > player.transform.position.y + 1){
            //game over
        }
    }

    private void build(){
        string[] lines = File.ReadAllLines("map.csv");
        
        List<string[]> matrix = new List<string[]>();
        tiles = new List<List<Tile>>();
        foreach (string line in lines) {
            matrix.Add(line.Split(','));
        }
        for (int y = 0; y < matrix.Count; y++){
            List<Tile> row = new List<Tile>();
            for (int x = 0; x < matrix[0].Length; x++){
                var structure = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
                switch (matrix[matrix.Count - y - 1][x]){
                    case "rb":
                        structure.type = TileType.resources;
                        break;
                    case "ib":
                        structure.type = TileType.wall;
                        break;
                    case "pb":
                        structure.type = TileType.trap;
                        break;
                }
                row.Add(structure);
            }
            tiles.Add(row);
        }
    }
}
