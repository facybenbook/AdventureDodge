using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    //-----Public variables-----\\
    [Header("Variables")]
    public Transform player;
    public Vector3 offset; //location away from player
    public Vector3 angle;

    public float mouseSensitivityX = 2.0f;
    public float mouseSensitivityY = 2.0f;



    void Start() // set beginning camera angle
    {
        transform.rotation = Quaternion.Euler(angle);
    }


    void Update () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivityX, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -mouseSensitivityY, Vector3.right) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0f, 2f, 0f));
    }
}
