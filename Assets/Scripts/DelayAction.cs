using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAction : MonoBehaviour {
    public static IEnumerator invincFrame (float timeToNotDie, bool playerCanTakeDam) {
        yield return new WaitForSeconds (timeToNotDie); //Will yield this function for x amount of time
        playerCanTakeDam = true;
    }
}