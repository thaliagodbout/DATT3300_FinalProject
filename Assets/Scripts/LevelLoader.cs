using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckEndGame() {
        if (ProgressManager.endGame) {
            StartCoroutine(LoadLevel(2));
        }
    }

    public void LoadNextLevel() {
        // Load other level by build index
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            StartCoroutine(LoadLevel(1));
        } else {
            ProgressManager.isSpawnInOverworld = true;
            StartCoroutine(LoadLevel(0));
        }
    }

    IEnumerator LoadLevel(int levelIndex) {
        // Play animation
        transition.SetTrigger("Start");

        // Wait for animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
