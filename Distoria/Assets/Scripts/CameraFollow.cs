using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float xDistance;
    public float yDistance;
    public float zDistance;
    public Vector3 PlayerPos;
    private Camera mainCamera;

    public GameObject player;
    public ClickToMove clickToMoveScript;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();

        player = GameObject.Find("Player");
        PlayerPos = player.transform.position;
        clickToMoveScript = player.gameObject.GetComponent<ClickToMove>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPos = GameObject.Find("Player").transform.position;
        mainCamera.transform.position = new Vector3(PlayerPos.x - xDistance, PlayerPos.y + yDistance, PlayerPos.z);
        transform.LookAt(target);
        //GameObject.Find("MainCamera").transform.position = new Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z - distance);
        

        if(clickToMoveScript.currentWalkZone == 0)
        {
            xDistance = 3.5f;
            yDistance = 5.0f;
            zDistance = 0.0f;
        }
        else if (clickToMoveScript.currentWalkZone == 1)
        {
            xDistance = -9.5f;
            yDistance = 5.0f;
            zDistance = 14.0f;
        }
    }
}
