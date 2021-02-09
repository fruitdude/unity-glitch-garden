using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    [Header("Projectile")]
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float speedOfRotation = 5.0f;
    [SerializeField] float projectileDamage;

    // Update is called once per frame
    void Update(){
        MoveProjectile();
    }

    private void MoveProjectile() {
        transform.Rotate(0, 0, -speedOfRotation * Time.deltaTime);
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World); //with Space.World the Projectile will rotate on its own z axis
    }

    /*
    public float GetZucchiniDamage() {
        return projectileDamage;
    }
    */

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health) { //if the otherCollider has the gamecomponents Health and Attacker then do shit
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }


}
