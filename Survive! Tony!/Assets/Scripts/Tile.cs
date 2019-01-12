using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{ 
    public int progress;
    private bool pressed;
    public TileType type;
    public GameObject pipe;
    public GameObject wall;
    public GameObject regularBlock;
    public Slider progressbar;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        progress = 0;
        UpdateBlock(type);
        done = false;
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
            progress = 0;
            done = false;
        }
        UpdateProgress();
    }

    void UpdateProgress()
    {
        if (pressed)
        {
            if (type != TileType.wall && type != TileType.pipe)
            {
                progressbar.gameObject.SetActive(true);
                if (progress < 100)
                {
                    progress += 1;
                }
                if (progress == 100 && done == false)
                {
                    done = true;
                    progressbar.gameObject.SetActive(false);
                    switch (type)
                    { 
                        case TileType.empty:
                            type = TileType.resources;
                            Controler.resource -= 1;
                            UpdateBlock(type);
                            break;
                        case TileType.trap:
                            type = TileType.pipe;
                            UpdateBlock(type);
                            break;
                        case TileType.resources:
                            type = TileType.empty;
                            Controler.resource += 1;
                            UpdateBlock(type);
                            break;
                        default:
                            break;
                    }
                }
                if (done == true)
                {
                    progressbar.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (progress != 100)
            {
                progressbar.gameObject.SetActive(false);
                progress = 0;
            }
        }
    }

    void UpdateBlock(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.empty:
                pipe.SetActive(false);
                wall.SetActive(false);
                regularBlock.SetActive(false);
                break;
            case TileType.pipe:
                pipe.SetActive(true);
                wall.SetActive(false);
                regularBlock.SetActive(false);
                break;
            case TileType.resources:
                pipe.SetActive(false);
                wall.SetActive(false);
                regularBlock.SetActive(true);
                break;
            case TileType.trap:
                pipe.SetActive(false);
                wall.SetActive(false);
                regularBlock.SetActive(true);
                break;
            case TileType.wall:
                pipe.SetActive(false);
                wall.SetActive(true);
                regularBlock.SetActive(false);
                break;
        }
    }
}

public enum TileType {empty, wall, resources, trap, pipe}
