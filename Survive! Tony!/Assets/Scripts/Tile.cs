using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
    public int progress;
    private bool pressed = false;
    public TileType type;

    // Start is called before the first frame update
    void Start()
    {

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
            progress += 1;
        }
    }

    void UpdateResource()
    {
        
    }
}

public enum TileType {empty, wall, resources, trap, pipe}
