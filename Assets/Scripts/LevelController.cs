using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [Tooltip("the amount of time it takes to load the next level")]
    [SerializeField] int tuneableLoadingTime;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        numberOfAttackers += 1;
    }

    public void AttackerDestroyed() {
        numberOfAttackers -= 1;

        if (numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        FindObjectOfType<DefenderSpawner>().gameObject.SetActive(false);
        yield return new WaitForSeconds(tuneableLoadingTime);
        Debug.Log("i should wait " + tuneableLoadingTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition() {
        FindObjectOfType<DefenderSpawner>().gameObject.SetActive(false);
        loseLabel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }
}
