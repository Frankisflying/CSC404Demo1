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

    // Start is called before the first frame update
    public Slider progressbar;
    void OnMouseDown() {
        progressbar.gameObject.SetActive(true);
        progressbar.value = 0.1f;
    }
}

public enum TileType {empty, wall, resources, trap, pipe}
