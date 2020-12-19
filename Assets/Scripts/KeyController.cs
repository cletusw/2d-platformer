using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerController>();
        if (player) {
            player.GotKey();
            Destroy(gameObject);
        }
    }
}
