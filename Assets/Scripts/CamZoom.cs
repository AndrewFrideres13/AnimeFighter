using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour {
    new Camera camera;
    Transform playerOne, playerTwo;
    public float testVar = 6.2f;
    void Start () {
        camera = Camera.main;
        playerOne = GameObject.Find ("Player11").GetComponent<Transform> ();
        playerTwo = GameObject.Find ("Player22").GetComponent<Transform> ();
    }

    void LateUpdate () {
        float zoomFactor = Vector2.Distance (playerOne.position, playerTwo.position);
        //Debug.Log (Vector2.Distance (playerOne.position, playerTwo.position));

        //Max size of the damn camera       //Min size so we dont zoom in and get ALL the fricken detail
        if (camera.orthographicSize < 18 && camera.orthographicSize > 5) {
            camera.orthographicSize = 3.5f * zoomFactor;
        }
    }
}