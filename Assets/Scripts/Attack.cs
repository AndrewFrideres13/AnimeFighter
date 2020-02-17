using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    Transform playerOne, playerTwo;
    GameObject fistOfDOOMOne;
    public GameObject projectile;
    Animator pAnim;
    AudioSource charAudio;
    AudioController audio;

    bool canAttack = true;
    float inputDelay = 0f;
    FistDamager fistConnected;
    void Start () {
        playerOne = this.GetComponent<Transform> ();
        pAnim = this.GetComponent<Animator> ();
        charAudio = this.GetComponent<AudioSource> ();
        audio = this.GetComponent<AudioController> ();
        fistOfDOOMOne = playerOne.transform.GetChild (0).gameObject;
        fistConnected = fistOfDOOMOne.GetComponent<FistDamager> ();
        projectile = Resources.Load ("Proj", typeof (GameObject)) as GameObject;
    }

    void Update () {
        bool lightAtt = Input.GetButton ("Attack"), hoovyAtt = Input.GetButton ("HeavyAttack"),
            special = Input.GetButton ("Special_"), _attack = Input.GetButton ("_Attack");

        if (this.gameObject.tag == "Player") {
            lightAtt = Input.GetButton ("Attack");
            hoovyAtt = Input.GetButton ("HeavyAttack");
            special = Input.GetButton ("Special_");
            _attack = Input.GetButton ("_Attack");
        } else if (this.gameObject.tag == "PlayerTwo") {
            lightAtt = Input.GetButton ("Attack2");
            hoovyAtt = Input.GetButton ("HeavyAttack2");
            special = Input.GetButton ("Special_2");
            _attack = Input.GetButton ("_Attack2");
        }
        //Debug.Log (Vector2.Distance (playerOne.position, playerTwo.position));
        ResetAction ();
        if (lightAtt && canAttack == true) {
            //Regular Attack
            fistOfDOOMOne.SetActive (true);
            //2 will be light attack
            charAudio.clip = audio.audioFx[0];
            charAudio.Play ();
            canAttack = false;
            inputDelay = 1f;
            GameManager.pointsToBuildUpSpecialAttackP1 += 5;
            pAnim.SetTrigger ("isLightAtt");
        } else if (hoovyAtt && canAttack == true) {
            //Heavy Attack
            charAudio.clip = audio.audioFx[1];
            charAudio.Play ();
            fistOfDOOMOne.SetActive (true);
            canAttack = false;
            inputDelay = 1.35f;
            GameManager.pointsToBuildUpSpecialAttackP1 += 10;
            pAnim.SetTrigger ("isHeavyAtt");
        }

        if (special && _attack /*&& GameManager.pointsToBuildUpSpecialAttackP1 >= GameManager.pointsToActivateSpecial*/ ) {
            //Special Attack
            //3 will be Special attack
            charAudio.clip = audio.audioFx[2];
            charAudio.Play ();
            GameObject bullet = Instantiate (projectile, new Vector3 (transform.position.x + 3f, 3, transform.position.z), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody> ().AddForce (Vector2.right * 2000);
            GameManager.pointsToBuildUpSpecialAttackP1 = 0;
            pAnim.SetTrigger ("isSPECIAL");
            canAttack = false;
            inputDelay = 1f;
        }
    }
    void ResetAction () {
        if (canAttack == false && inputDelay > 0) {
            inputDelay -= Time.deltaTime;
        }

        if (inputDelay < 0) {
            inputDelay = 0f;
            canAttack = true;
        }
    }
}