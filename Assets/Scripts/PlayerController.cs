using System.Collections;
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
    Rigidbody2D rigidbody2d;
    Vector2 currentMovementInput;
    bool grounded = false;
    bool hasKey = false;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 1.0f, LayerMask.GetMask("Platforms"));
        grounded = hit.collider != null;
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
        Debug.Log("Hurt");
        GetComponent<Animator>().SetBool("Hurt", true);
        CustomEvent.Trigger(gameObject, "Hurt");
    }
}