using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class teleport : MonoBehaviour {

    public GameManager gameManager;
    Renderer rend;
    public int level; // level to teleport to

    private void Start() 
    {
        rend = GetComponent<Renderer>();
        if (gameManager.checkIfCompletedLevel(level)) // set to black if completed that level
        {
            rend.material.SetColor("_Color", Color.black);
        }
    }

    private void OnTriggerEnter() // when applying to trigger
    {
        if (level == -1)
        {
            Application.Quit();
        }
        goToLevel(level);
    }

    public void goToLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex); // load next level
    }

}
