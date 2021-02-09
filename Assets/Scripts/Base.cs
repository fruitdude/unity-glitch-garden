﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Attacker>()) {
            FindObjectOfType<LiveDisplay>().ReduceAmountOfLives();
            Destroy(otherObject);
        }

    }

}
