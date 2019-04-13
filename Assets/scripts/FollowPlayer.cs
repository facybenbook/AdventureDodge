using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    //-----Public variables-----\\
    [Header("Variables")]
    public Transform player;
    public Vector3 offset; //location away from player
    public Vector3 angle;
    public bool rotate;
    public Vector3 rotateAngle;

    public float mouseSensitivityX = 2.0f;
    public float mouseSensitivityY = 2.0f;



    void Start() // set beginning camera angle
    {
        transform.rotation = Quaternion.Euler(angle);
    }


    void Update () {
        //Debug.Log(Camera.main.transform.eulerAngles.y.ToString()); //print angle left right
        if (Camera.main.transform.eulerAngles.y > 90 && Camera.main.transform.eulerAngles.y < 270) // if facing backwards
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivityX, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * mouseSensitivityY, Vector3.right) * offset;
        }
        else
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivityX, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -mouseSensitivityY, Vector3.right) * offset;
        }
        transform.position = player.position + offset;
        if (rotate){ 
            transform.LookAt(player.position + new Vector3(0f, 2f, 0f));
        } else {
            transform.LookAt(player.position + new Vector3(0f, 2f, 0f)); // plus 2 vertical so player is closer to bottom of screen rather than the middle
        }   
    }
}
