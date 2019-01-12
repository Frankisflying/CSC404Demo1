using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
    public static int progress;
    private bool pressed;
    public static TileType type;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
        UpdateProgress();
    }

    void UpdateProgress()
    {
        if (pressed)
        {
            if (type != TileType.wall)
            {
                progress += 1;
                if (progress == 100)
                {
                    switch (type)
                    { 
                        case TileType.empty:
                            type = TileType.resources;
                            break;
                        case TileType.trap:
                            type = TileType.pipe;
                            break;
                        case TileType.resources:
                            type = TileType.empty;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else
        {
            if (progress != 100)
            {
                progress = 0;
            }
        }
    }

    void UpdateResource()
    {

    }
}

public enum TileType {empty, wall, resources, trap, pipe}
