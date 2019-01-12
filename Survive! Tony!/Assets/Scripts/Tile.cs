using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider progressbar;
    void OnMouseDown() {
        progressbar.gameObject.SetActive(true);
        progressbar.value = 0.1f;
    }
}
