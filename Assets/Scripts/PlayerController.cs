﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Ludiq;
using Bolt;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 12;
    public GameObject statesManager;
    Rigidbody2D rigidbody2d;
    Vector2 currentMovementInput;
    bool grounded = false;
    bool hasKey = false;

    void Start()
    {
        if (statesManager == null) {
            Debug.LogError("Missing statesManager!");
        }
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        grounded = Util.isGrounded(transform.position);
    }

    void Update()
    {
        // TODO: Multiply by Time.deltaTime?
        float horizontal = currentMovementInput.x * speed;
        rigidbody2d.velocity = new Vector2(horizontal, rigidbody2d.velocity.y);

        if (horizontal != 0) {
            transform.localScale = new Vector3(horizontal > 0 ? 1 : -1, 1, 1);
        }

        GetComponent<Animator>().SetBool("Grounded", grounded);
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(horizontal));
    }

    void OnMove(InputValue input) {
        currentMovementInput = input.Get<Vector2>();
    }

    void OnJump() {
        if (grounded) {
            rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public bool HasKey() {
        return hasKey;
    }

    public void GotKey() {
        hasKey = true;
    }

    // Called from SpikesController, DamageController
    void Death() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Hurt() {
        GetComponent<Animator>().SetBool("Hurt", true);
        CustomEvent.Trigger(statesManager, "Hurt");
    }
}