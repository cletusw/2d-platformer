using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudKeyController : MonoBehaviour
{
    public Sprite hudKeyFullSprite;
    public Sprite hudKeyEmptySprite;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(GameObject.FindWithTag("Key") != null);
        if (hudKeyFullSprite == null) {
            Debug.LogError("Missing hudKeyFullSprite!");
        }
        if (hudKeyEmptySprite == null) {
            Debug.LogError("Missing hudKeyEmptySprite!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        GetComponent<Image>().sprite = player.HasKey() ? hudKeyFullSprite : hudKeyEmptySprite;
    }
}
