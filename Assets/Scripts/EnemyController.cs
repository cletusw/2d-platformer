using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;

    private Rigidbody2D rb;
    private Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.gameObject.SendMessage("Damage", 1);
        }
    }

    public void Walk(int direction = 0) {
        direction = Mathf.Clamp(direction, -1, 1);
        var movement = direction * speed;
        if (direction != 0) {
            transform.localScale = new Vector3(direction, 1, 1);
        }
        rb.velocity = new Vector2(movement, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(movement));
    }
}
