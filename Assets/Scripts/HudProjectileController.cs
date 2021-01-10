using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudProjectileController : MonoBehaviour
{
    void Start() {
        GetComponent<Image>().enabled = false;
    }

    public void GotProjectiles()
    {
        GetComponent<Image>().enabled = true;
    }
}
