using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public static bool playerOneSelection = true;
    public static int pointsToBuildUpSpecialAttackP1 = 0, pointsToBuildUpSpecialAttackP2 = 0, pointsToActivateSpecial = 50;
    Image BuildBar1, BuildBar2;
    Color color, color2;
    void Awake () {
        BuildBar1 = GameObject.Find ("Player1BuildBar").GetComponent<Image> ();
        BuildBar2 = GameObject.Find ("Player2BuildBar").GetComponent<Image> ();
        color = BuildBar1.color;
        color2 = BuildBar2.color;
        pointsToBuildUpSpecialAttackP1 = 0;
        pointsToBuildUpSpecialAttackP2 = 0;
    }
    void Update () {
        if (Input.GetButton ("Reset")) {
            SceneManager.LoadScene (1);
        }

        color.a = ((float) GameManager.pointsToBuildUpSpecialAttackP1 / 100 * 2);

        BuildBar1.color = color;
        color2.a = ((float) GameManager.pointsToBuildUpSpecialAttackP2 / 100 * 2);
        BuildBar2.color = color2;

    }
}