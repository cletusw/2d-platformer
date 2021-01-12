using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveController : MonoBehaviour
{
    public string nextScene;

    void Start() {
        if (nextScene == null) {
            Debug.LogError("Missing nextScene!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            SaveManager.setLevelUnlocked(nextScene);
            SceneManager.LoadScene(nextScene);
        }
    }
}
