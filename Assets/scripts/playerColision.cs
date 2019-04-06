using UnityEngine;

public class playerColision : MonoBehaviour {

    public playerMovement movement;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "EndTriggerWall")
        {
            Debug.Log("Hit end of level trigger");
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
