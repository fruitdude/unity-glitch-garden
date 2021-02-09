using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LiveDisplay : MonoBehaviour{

    [SerializeField] float baseLives = 3f;
    float amountOfLives;
    Text liveText;

    // Start is called before the first frame update
    void Start(){
        amountOfLives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<Text>();
        UpdateAmountOfLivesText();
    }

    private void UpdateAmountOfLivesText() {
        liveText.text = amountOfLives.ToString();
    }

    public void ReduceAmountOfLives() {
        amountOfLives -= 1;
        UpdateAmountOfLivesText();

        if (amountOfLives <= 0) {
            liveText.text = 0.ToString();
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
