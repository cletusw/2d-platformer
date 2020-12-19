using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite doorOpenSprite;

    void Start() {
        if (doorOpenSprite == null) {
            Debug.LogError("Missing doorOpenSprite!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerController>();
        if (player && player.HasKey()) {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
        }
        else {
            Debug.Log("No key!");
        }
    }
}
