using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {
    public static bool isGrounded(Vector3 position) {
        return isGrounded(position, Vector3.zero);
    }

    public static bool isGrounded(Vector3 position, Vector2 offset) {
        RaycastHit2D hit = Physics2D.CircleCast(position + (Vector3) offset, 0.3f, Vector2.down, 1.0f, LayerMask.GetMask("Platforms"));
        return hit.collider != null;
    }
}
