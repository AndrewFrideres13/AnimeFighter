using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public float moveSpeedMult = 17f;
    public float jumpSpeed = 18f;
    public float gravity = 20f;
    Animator pAnim;
    CharacterController player, player2;
    public bool canTakeDam = true, canFlip = true;
    public Vector2 movement = Vector2.zero, movement2 = Vector2.zero;
    float xScale;
    void Start () {
        player = GetComponent<CharacterController> ();
        pAnim = this.GetComponent<Animator> ();
        xScale = transform.localScale.x; // assuming this is facing right
    }

    void FixedUpdate () {
        float horizMove = Input.GetAxis ("Horizontal"), horizMove2 = Input.GetAxis ("Horizontal2");
        bool jump = Input.GetButton ("Jump"), blawk = Input.GetButton ("Block");
        if (this.gameObject.tag == "Player") {
            horizMove = Input.GetAxis ("Horizontal");
            jump = Input.GetButton ("Jump");
            blawk = Input.GetButton ("Block");
        } else if (this.gameObject.tag == "PlayerTwo") {
            horizMove = Input.GetAxis ("Horizontal2");
            jump = Input.GetButton ("Jump2");
            blawk = Input.GetButton ("Block2");
        }

        if (player.isGrounded) {
            //Moves player based off our x
            movement = new Vector2 (horizMove, 0);
            movement *= moveSpeedMult;

            if (horizMove > 0) { //Move right
                transform.localScale = new Vector2 (xScale, transform.localScale.y);
                pAnim.SetBool ("isWalking", true);
            } else if (horizMove < 0) {
                transform.localScale = new Vector2 (-xScale, transform.localScale.y);
                pAnim.SetBool ("isWalking", true);
            } else if (horizMove == 0) {
                canFlip = true;
                pAnim.SetBool ("isWalking", false);
            }
            if (jump) {
                movement.y = jumpSpeed;
                pAnim.SetTrigger ("isJumping");
            }

            if (blawk) {
                pAnim.SetTrigger ("isBlawk");

                canTakeDam = false;
                StartCoroutine (DelayAction.invincFrame (0.5f, canTakeDam));
            }

        }
        movement.y -= gravity * Time.deltaTime;
        player.Move (movement * Time.deltaTime);
    }
}