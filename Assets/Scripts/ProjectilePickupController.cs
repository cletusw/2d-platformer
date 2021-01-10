using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickupController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerProjectileController>();
        if (player) {
            player.GotProjectiles();
            Destroy(gameObject);
        }
    }
}
