using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class TestController : MonoBehaviour
{
    // Called via message from __
    void Damage(int damage) {
        var variables = Variables.Object(gameObject);
        int newHealth = Mathf.Max(0, (int) variables.Get("Health") - damage);
        variables.Set("Health", newHealth);
        gameObject.SendMessage((newHealth == 0) ? "Death" : "Hurt");
    }
}
