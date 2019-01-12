using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Controler: MonoBehaviour{

    public Tile tile;
    
    public int height = 30;
    public int width = 12;
    
    public static int resource;
    public static List<List<Tile>> tiles;

    void Start(){
        build();
    }

    private void build(){
        string[] lines = File.ReadAllLines("map.csv");
        
        List<string[]> matrix = new List<string[]>();
        tiles = new List<List<Tile>>();
        foreach (string line in lines) {
            matrix.Add(line.Split(','));
        }
        print(matrix);
        int ypos = height;
        for (int y = 0; y < matrix.Count; y++){
            int xpos = 0;
            List<Tile> row = new List<Tile>();
            for (int x = 0; x < matrix[0].Length; x++){
                var structure = Instantiate(tile, new Vector3(xpos, ypos, 0), Quaternion.identity);
                switch (matrix[y][x]){
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
                xpos += 1;
            }
            tiles.Add(row);
            ypos -= 1; 
        }
    }
}
