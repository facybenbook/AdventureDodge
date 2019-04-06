using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public const float restartDelay = 2f;
    public const float nextLevelDelay = 2f;
    public static int tries = 1;
    public static Dictionary<int, int> completedLevelsDict = new Dictionary<int, int>(); // levelindex, tries

    public GameObject levelCompleteUI;

	public void GameOver(float delay = restartDelay)
    {
        if (gameHasEnded == false) // if game not over
        {
            gameHasEnded = true; // so it only happens once
            Debug.Log("Ending level soon...");
            Invoke("restart", delay);
        }
        
    }

    public void restart() // only call from gameover
    {
        tries++;
        Debug.Log("Restarting...");
        Debug.Log("Tries = " + tries.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        gameHasEnded = true;
        if (!completedLevelsDict.ContainsKey(currentLevel))
        {
            completedLevelsDict.Add(currentLevel, tries);
        }
        tries = 1;
        Debug.Log("Completed Level");
        levelCompleteUI.SetActive(true);
        Invoke("loadNextLevel", nextLevelDelay);
    }

    public void loadNextLevel() // loads next level in build order
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public string getTries()
    {
        return tries.ToString("0");
    }

    public bool checkIfCompletedLevel(int level)
    {
        if (completedLevelsDict.ContainsKey(level)){
            return true;
        }
        else
        {
            return false;
        }
    }

}

