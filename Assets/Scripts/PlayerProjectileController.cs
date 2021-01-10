using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public bool hasProjectiles = false;
    public GameObject projectile;
    public float spawnOffset = 2;

    public void GotProjectiles()
    {
        hasProjectiles = true;
        var hudProjectileController = GameObject.Find("HUD").GetComponentInChildren<HudProjectileController>();
        if (hudProjectileController == null) {
            Debug.Log("No hudProjectileController found!");
        }
        else {
            hudProjectileController.GotProjectiles();
        }
    }

    void OnFire() {
        if (hasProjectiles) {
            if (projectile == null) {
                Debug.LogError("No projectile prefab provided!");
                return;
            }

            var direction = transform.localScale.x;
            var projectileObject = Instantiate(projectile, transform.position + new Vector3(direction * spawnOffset, 0, 0), Quaternion.identity);
            var projectileController = projectileObject.GetComponent<ProjectileController>();
            projectileController.setDirection(direction);
        }
    }
}
