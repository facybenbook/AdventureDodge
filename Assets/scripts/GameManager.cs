using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public static int tries = 1;
    public static Dictionary<int, int> completedLevelsDict = new Dictionary<int, int>(); // levelindex, tries

    public GameObject completeLevelUI;

	public void GameOver()
    {
        if (gameHasEnded == false) // so it only happens once
        {
            Debug.Log("Ending level soon...");
            Invoke("restart", restartDelay);
        }
        
    }

    public void restart()
    {
        if (gameHasEnded == false)
        {
            tries++;
            Debug.Log("Restarting...");
            Debug.Log("Tries = " + tries.ToString());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
        completeLevelUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load next level
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

