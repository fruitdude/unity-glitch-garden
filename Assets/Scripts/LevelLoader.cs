using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour{

    int currentSceneIndex;
    [SerializeField] int loadingWaitTime = 3;

    private void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0) {
            StartCoroutine(WaitForTimeToLoadStartScreen());
        }
    }

    IEnumerator WaitForTimeToLoadStartScreen() {
        yield return new WaitForSeconds(loadingWaitTime);
        LoadNextScene();
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenuScene() {
        SceneManager.LoadScene("Start Screen");
        Time.timeScale = 1;
    }

    public void LoadCurrentScene() {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadGameOverScene() {
        //StartCoroutine(WaitForTime());
        SceneManager.LoadScene("Game Over Screen");
    }

    public void LoadOptionsMenuScene() {
        SceneManager.LoadScene("Option Screen");
    }

    public void QuitApplication() {
        Application.Quit();
    }
}
