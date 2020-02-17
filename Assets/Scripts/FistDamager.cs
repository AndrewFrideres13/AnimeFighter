using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistDamager : MonoBehaviour {
    Transform playerOne, playerTwo;
    public bool hitConnected = false;
    void Start () {
        //this.gameObject.SetActive (false);
    }

    private void OnTriggerEnter (Collider other) {
        //Debug.Log ("Collision P1");
        if (other.GetComponent<Collider> ().tag == "Player") {
            if (Input.GetButton ("Attack")) {
                other.gameObject.GetComponent<Health> ().takeDamage (5);
            } else if (Input.GetButton ("HeavyAttack")) {
                other.gameObject.GetComponent<Health> ().takeDamage (10);
            } else if (this.gameObject.tag == "Proj") {
                other.gameObject.GetComponent<Health> ().takeDamage (30);
            }
            hitConnected = true;
            this.gameObject.SetActive (false);
        } else if (other.GetComponent<Collider> ().tag == "PlayerTwo") {
            if (Input.GetButton ("Attack")) {
                other.gameObject.GetComponent<Health> ().takeDamage (5);
            } else if (Input.GetButton ("HeavyAttack")) {
                other.gameObject.GetComponent<Health> ().takeDamage (10);
            } else if (this.gameObject.tag == "Proj") {
                other.gameObject.GetComponent<Health> ().takeDamage (30);
            }
            hitConnected = true;
            this.gameObject.SetActive (false);
        }
    }

    void takeDamage () {

    }

    void Update () {
        hitConnected = false;
    }
}