using UnityEngine;

public class grow : MonoBehaviour
{
    public float rate = .1f;
    public bool growX;
    public bool growY;
    public bool growZ;
    public bool requireDistanceFromPlayer = false;
    public float distance = 1f;
    private Transform thisObject;
    private Transform player;

    void Update()
    {
        if (requireDistanceFromPlayer) // if distance is required 
        {
            thisObject = this.transform;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            //Debug.Log(Vector3.Distance(thisObject.position, player.position).ToString());
            if (Vector3.Distance(thisObject.position, player.position) > distance)// if distance is insuffiecent 
            {
                return;
            }
        }
        if (growX)
        {
            transform.localScale += new Vector3(rate, 0, 0);
        }
        if (growY)
        {
            transform.localScale += new Vector3(0, rate, 0);
        }
        if (growZ)
        {
            transform.localScale += new Vector3(0, 0, rate);
        }
    }
}