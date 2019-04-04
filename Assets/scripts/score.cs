using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Transform player;
    public GameManager gameManager;
    public Text scoreText;
    public Text triesText;

    private void Start()
    {
        triesText.text = gameManager.getTries();
    }
    void Update () {
        scoreText.text = player.position.z.ToString("0"); // 0 makes whole numbers
	}
}
