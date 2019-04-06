using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public Rigidbody rb;
    public GameManager gameManager;

    public float forwardForce = 2000f;
    public float sideForce = 500f;
    public float restartOnFalloffDistance = 2f;
    public bool forwardForceOn = true;


	
	// Update is called once per frame
	void FixedUpdate () { //use fixedUpdate instead of Update for physics
        if (forwardForceOn){
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // push forward added deltaTime to keep constant with time, 
        }

        controls();

        if (rb.position.y < -restartOnFalloffDistance) // check for falling off side
        {
            FindObjectOfType<GameManager>().GameOver();
        }

    }

    public void controls()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // velocity change changes velcoity regardless of mass (will accelerate without)
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("r"))
        {
            Debug.Log("Tried to restart");
            FindObjectOfType<GameManager>().GameOver(.01f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("hubworld");
        }

        if (Input.GetKey("p"))
        {
            Debug.Log("Skipped level");
            gameManager.CompleteLevel();
        }



    }
}
