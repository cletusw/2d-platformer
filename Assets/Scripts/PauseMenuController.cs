using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Ludiq;
using Bolt;

public class PauseMenuController : MonoBehaviour
{
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnPause() {
        CustomEvent.Trigger(transform.parent.gameObject, isPaused ? "Resume" : "Pause");
        isPaused = !isPaused;
    }

    public void Resume() {
        CustomEvent.Trigger(transform.parent.gameObject, "Resume");
        isPaused = false;
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene("Menu");
    }

    public void Quit() {
        Application.Quit();
    }
}
