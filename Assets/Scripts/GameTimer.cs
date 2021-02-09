﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour{

    [Tooltip("Our level time in seconds")]
    [SerializeField] float levelTime = 10.0f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update(){
        if (triggeredLevelFinished) {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished) {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}