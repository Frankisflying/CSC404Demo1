using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour{

    public Transform camera;
    
    private void Update(){
        transform.position = new Vector3(camera.position.x, camera.position.y, -10);
    }

    private void OnMouseDown(){
        gameObject.SetActive(false);
    }
}
