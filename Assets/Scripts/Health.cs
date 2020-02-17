using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour {
    float playerHP;
    Button HPBar;
    InputController playerInput;
    SpriteRenderer playerRend;
    Color damageColor = Color.red, defaultColor = Color.clear, alpha, color;
    AudioSource charAudio;
    AudioController audio;
    void Start () {
        playerHP = 100f;
        playerInput = this.GetComponent<InputController> ();

        //Player 1 by default
        playerRend = this.GetComponent<SpriteRenderer> ();
        HPBar = GameObject.Find ("Player1HP").gameObject.GetComponent<Button> ();
        alpha = playerRend.material.color;
        defaultColor = playerRend.material.color; //Store the default color
        charAudio = this.GetComponent<AudioSource> ();
        audio = this.GetComponent<AudioController> ();
    }
    public void takeDamage (int damage) {
        if (playerInput.canTakeDam) {
            charAudio.clip = audio.audioFx[3];
            charAudio.Play ();
            playerHP -= damage;
            StartCoroutine ("ColorFlash");
            //Debug.Log (playerHP);
            GameManager.pointsToBuildUpSpecialAttackP1 += 10;
        }
    }

    void Update () {
        if (this.gameObject.tag == "Player") {
            //For damage flashing p1
            playerRend = this.GetComponent<SpriteRenderer> ();
            HPBar = GameObject.Find ("Player1HP").gameObject.GetComponent<Button> ();
        } else if (this.gameObject.tag == "PlayerTwo") {
            //P2 damage flashing
            playerRend = this.GetComponent<SpriteRenderer> ();
            HPBar = GameObject.Find ("Player2HP").gameObject.GetComponent<Button> ();
        }
        if (this.playerHP <= 50 && this.playerHP > 25) {
            //Swap to half HP   
            HPBar.image.sprite = Resources.Load ("Health Bar Half", typeof (Sprite)) as Sprite;
            //HPBar.GetComponent<RectTransform> ().Width -= 48;
        } else if (this.playerHP <= 25) {
            //Swap to low HP
            HPBar.image.sprite = Resources.Load ("Health Bar Quarter", typeof (Sprite)) as Sprite;
            //HPBar.GetComponent<RectTransform> ().Width -= 48;
        }
        if (this.playerHP <= 0) {
            alpha.a -= 0.06f;
            playerRend.material.color = alpha;
            if (playerRend.material.color.a <= 0) {
                Destroy (this.gameObject);
                //this.gameObject.SetActive (false);
                SceneManager.LoadScene (1);
            }
        }
    }

    private IEnumerator ColorFlash () {
        //Debug.Log ("RED");
        playerRend.material.color = damageColor;
        yield return new WaitForSeconds (0.4f);
        playerRend.material.color = defaultColor;
    }
}