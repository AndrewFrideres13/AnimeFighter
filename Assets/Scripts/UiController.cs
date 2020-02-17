using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiController : MonoBehaviour {
    List<Button> menuButtons;
    Button playButton;
    Button quitButton;
    Navigation nav;
    EventSystem _eventsystem;
    void Awake () { }

    public void PlayGame () {
        SceneManager.LoadScene (1);
    }

    // Update is called once per frame
    public void Quit () {
        Application.Quit ();
    }

}