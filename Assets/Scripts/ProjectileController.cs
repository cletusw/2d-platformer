using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    float direction = 0;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * 8, 0);
        Destroy(gameObject, 10f);
    }

    void Update() {
        transform.Rotate(0, 0, direction * 1000 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.SendMessage("Death");
        }
        if (!collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    public void setDirection(float x)
    {
        direction = x;
    }
}
