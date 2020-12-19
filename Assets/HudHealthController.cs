using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ludiq;
using Bolt;

public class HudHealthController : MonoBehaviour
{
    public Sprite hudHeartFullSprite;
    public Sprite hudHeartEmptySprite;
    GameObject player;
    List<Image> hearts;

    // Start is called before the first frame update
    void Start()
    {
        if (hudHeartFullSprite == null) {
            Debug.LogError("Missing hudHeartFullSprite!");
        }
        if (hudHeartEmptySprite == null) {
            Debug.LogError("Missing hudHeartEmptySprite!");
        }
        player = GameObject.FindWithTag("Player");
        hearts = new List<Image>() {
            transform.Find("Heart1").gameObject.GetComponent<Image>(),
            transform.Find("Heart2").gameObject.GetComponent<Image>(),
            transform.Find("Heart3").gameObject.GetComponent<Image>(),
        };
    }

    // Update is called once per frame
    void Update()
    {
        int health = (int) Variables.Object(player).Get("Health");

        for (int i = 0; i < hearts.Count; i++) {
            hearts[i].sprite = health > i ? hudHeartFullSprite : hudHeartEmptySprite;
        }
    }
}
