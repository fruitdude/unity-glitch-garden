﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject; //now i know about the gameobject i am colliding


        if (otherObject.GetComponent<Gravestone>()) {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        } else if (otherObject.GetComponent<Defender>()) { //does it have a defender Object
            GetComponent<Attacker>().Attack(otherObject); //if yes attack object
            //Debug.Log("This is the name of the Object i am colliding with: " + otherObject);
        }
    }
}
