﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public float detectionRadius = 3;

    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;
    private bool dying;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        if (player == null) {
            Debug.LogError("Missing player!");
        }
    }

    void Update() {
        if (dying) {
            transform.Rotate(0, 0, 720 * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.gameObject.SendMessage("Damage", 1);
        }
    }

    // Called from ProjectileController
    void Death() {
        CustomEvent.Trigger(gameObject, "Death");
    }

    public void DoDeath() {
        dying = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        GetComponent<Animator>().SetFloat("Speed", 0);
        Destroy(gameObject, 5);
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

    public bool almostAtEdge() {
        return !Util.isGrounded(transform.position, new Vector2(transform.localScale.x * 0.5f, 0));
    }

    public bool shouldChasePlayer() {
        return Vector2.Distance(transform.position, player.transform.position) < detectionRadius;
    }

    public void walkTowardPlayer() {
        var xDistance = (player.transform.position - transform.position).x;
        if (almostAtEdge()) {
            Walk(0);
        }
        else if (xDistance < 0) {
            Walk(-1);
        }
        else if (xDistance > 0) {
            Walk(1);
        }
        else {
            Walk(0);
        }
    }
}
