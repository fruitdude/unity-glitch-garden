using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    // Start is called before the first frame update
    IEnumerator Start(){

        while (spawn){
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        } 
    }

    public void StopSpawning() {
        spawn = false;
    }

    /*
    private void SpawnAttacker() {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }
    */

    private void SpawnAttacker() {
        Attacker attacker = attackerPrefabArray[UnityEngine.Random.Range(0, attackerPrefabArray.Length)];

        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
