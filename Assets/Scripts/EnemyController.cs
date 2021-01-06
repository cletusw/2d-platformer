using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class EnemyController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.gameObject.SendMessage("Damage", 1);
        }
    }
}
