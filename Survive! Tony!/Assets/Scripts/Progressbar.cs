using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    public Slider progress;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Tile tile = GetComponent<Tile>();
        progress.value = 0.01f * tile.progress;
    }
}
