using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {
    public static bool isGrounded(Vector3 position) {
        RaycastHit2D hit = Physics2D.CircleCast(position, 0.3f, Vector2.down, 1.0f, LayerMask.GetMask("Platforms"));
        return hit.collider != null;
    }
}
