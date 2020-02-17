using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPicker : MonoBehaviour {
    //Need functions that will serve as our players
    //Will be called from on click from the buttons, replace those with
    //the sprite/character avatar, spawn them and connect player control to them
    CamZoom camZoomScript;
    GameObject characterMenu, fist;
    void Awake () {
        GameManager.playerOneSelection = true;
        camZoomScript = Camera.main.GetComponent<CamZoom> ();
        camZoomScript.enabled = false;
        characterMenu = GameObject.Find ("CharacterMenu");
    }
    public void playerOneSelect (GameObject selectedPlayer) {
        //Prefab of the player with all scripts...Need to pick between prefabs with player one or 2
        //To start might be easy to dupe this script and throw it on each portrait
        //And seperate out player spawning that way, and clean it up later if time permits
        if (GameManager.playerOneSelection) {
            GameObject clone = Instantiate (selectedPlayer, new Vector3 (5, 20, 0), Quaternion.identity);
            clone.name = "Player11";
            clone.tag = "Player";
            clone.AddComponent<Attack> ();
            clone.AddComponent<CharacterController> ();
            clone.GetComponent<CharacterController> ().center = new Vector3 (0, 2, 0);
            clone.GetComponent<CharacterController> ().radius = 0.35f;
            clone.AddComponent<InputController> ();
            clone.AddComponent<Health> ();
            GameManager.playerOneSelection = false;
        } else { //Next time we "click" it's P2's turn
            GameObject clone = Instantiate (selectedPlayer, new Vector3 (40, 20, 0), Quaternion.identity);
            clone.name = "Player22";
            clone.tag = "PlayerTwo";
            clone.AddComponent<Attack> ();
            clone.AddComponent<CharacterController> ();
            clone.GetComponent<CharacterController> ().center = new Vector3 (0, 2, 0);
            clone.GetComponent<CharacterController> ().radius = 0.35f;
            clone.AddComponent<InputController> ();
            clone.AddComponent<Health> ();
            camZoomScript.enabled = true;
            //Prevent spammery baby
            characterMenu.SetActive (false);
        }
    }

    //Need both players to be able to select characters...so both controllers in main menu.
    //Probably have them take turns with character selection would be easiest
    //P1 selects a character, then P2 selects a character
}