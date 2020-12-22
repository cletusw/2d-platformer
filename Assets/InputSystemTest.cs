using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTest : MonoBehaviour
{
    void OnMove(InputValue input) {
        Debug.Log("move!");
    }
}
