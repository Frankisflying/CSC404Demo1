using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Controler: MonoBehaviour{

    public GameObject rblock;
    public GameObject iblock;
    public GameObject pblock;

    public static int resource;
    public static List<List<Tile>> tiles = new List<List<Tile>>();

    public int hight;
    public int width;

    void Start()
    {
        string[] lines = File.ReadAllLines("map.csv");
        List<string[]> matrix = new List<string[]>();
        foreach (string line in lines)
        {
            matrix.Add(line.Split(','));
        }

        for (int y = 0; y < matrix.Count; y++){
            for (int x = 0; x < matrix[0].Length; x++){
                GameObject structure;
                if (matrix[y][x] == "rb")
                {
                    structure = Instantiate(rblock, transform);

                }
                //structure.name = obj.name + x + ,  +y;
                //structure.transform.localPosition = new Vector3(x, 0, y);
            }
        }

        //for (int x = xMin; x = xMax; x++)
        //{
        //    for (int y = yMin; y = yMax; y++)
        //    {
        //        var structure = Instantiate(obj, transform);
        //        structure.name = obj.name + x + ,  +y;
        //        structure.transform.localPosition = new Vector3(x, 0, y);
        //    }
        //}
    }
}