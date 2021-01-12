using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelButtonController : MonoBehaviour
{
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Button>().interactable = sceneToLoad == "Level1" || SaveManager.isLevelUnlocked(sceneToLoad);
    }

    public void LoadSpecifiedLevel() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
