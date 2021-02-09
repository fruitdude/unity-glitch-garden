using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour{

    float currentSpeed = 1.0f;
    GameObject currentTarget;
    Animator myAnimtor;

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void Start() {
        myAnimtor = GetComponent<Animator>();
    }

    void Update(){
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        UpdateAnimationState();
    }

    private void OnDestroy() {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null) { //if the level controller is null it wont check for attacker destroyed
            levelController.AttackerDestroyed();
        }
    }



    private void UpdateAnimationState() {
        if (!currentTarget) {
            myAnimtor.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        myAnimtor.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }
}
