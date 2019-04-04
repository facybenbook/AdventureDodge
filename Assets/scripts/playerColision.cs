using UnityEngine;

public class playerColision : MonoBehaviour {

    public playerMovement movement;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
