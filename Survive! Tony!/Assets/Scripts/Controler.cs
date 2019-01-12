using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Controler: MonoBehaviour{

    public GameObject tile;
    public static int resource;
    public static List<List<GameObject>> tiles;
    public float waterLevel;
    public float fillInitTime;
    public float fillSpeed;
    
    public GameObject water;
    public GameObject player;

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
        tiles = new List<List<GameObject>>();
        foreach (string line in lines) {
            matrix.Add(line.Split(','));
        }
        for (int y = 0; y < matrix.Count; y++){
            List<GameObject> row = new List<GameObject>();
            for (int x = 0; x < matrix[0].Length; x++){
                var structure = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
                Tile tileScript = tile.GetComponent<Tile>();
                switch (matrix[matrix.Count - y - 1][x]){
                    case "RB":
                        tileScript.type = TileType.resources;
                        break;
                    case "IB":
                        tileScript.type = TileType.wall;
                        break;
                    case "PB":
                        tileScript.type = TileType.trap;
                        break;
                }
                row.Add(structure);
            }
            tiles.Add(row);
        }
    }
}
