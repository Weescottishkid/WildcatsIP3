using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{

    public float speed = 6.0f;
    public Vector3 originalPosition;
    public Vector3 targetPosition;
    public bool moving;
    public bool canMove;
    const int LEFT_MOUSE_BUTTON = 0;
    private RaycastHit hit;
    private Ray ray;

    private Vector3 stepBack;
    private Vector3 moveDirection = Vector3.zero;

    public DialogueManager dManagerScript;

    public int currentWalkZone;
    public Collider walkZone;
    public GameObject[] walkZones;
    public bool inWalkZone;

    public Vector3 minWalkPoint;
    public Vector3 maxWalkPoint;

	bool move ;

	Animator anim;

    // Use this for initialization
    void Start()
    {
		move = false;
        //playerObjectPosition = FindObjectOfType<PlayerObject>();
		anim = GetComponent<Animator>();

        walkZones = GameObject.FindGameObjectsWithTag("Boundary");

        for (int i = 0; i < walkZones.Length; i++)
        {
            walkZones[i] = GameObject.Find("walkZone" + i);
        }

        targetPosition = transform.position;
        moving = false;
        dManagerScript = FindObjectOfType<DialogueManager>();


        if (walkZone != null)
        {

            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            inWalkZone = true;
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
		anim.SetBool ("IsWalking", move);
        //cameraFollowScript.gameObject.transform.position = transform.position;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "NPC")
            {
                Debug.Log("target");
            }
        }

        if (dManagerScript.dialogueActive)
        {
            canMove = false;
        }
        if (!dManagerScript.dialogueActive && dManagerScript.talkTrigger)
        {
            canMove = true;
            
        }



        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            if (canMove)
            {
                SetTargetPosition();
            }
        }
        if (moving)
        {
            /*if (inWalkZone == true && (transform.position.x <= maxWalkPoint.x || transform.position.z <= maxWalkPoint.z || transform.position.x >= minWalkPoint.x || transform.position.z >= minWalkPoint.z))
            {

                moving = false;
            }
            else
            {
                MovePlayer();
            }*/
            MovePlayer();
        }
    }


    void SetTargetPosition()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float point = 0.0f;

        if (plane.Raycast(ray, out point))
        {
            Debug.Log("assigned target");
            targetPosition = ray.GetPoint(point);
            if (inWalkZone == true && (targetPosition.x <= maxWalkPoint.x && targetPosition.z <= maxWalkPoint.z && targetPosition.x >= minWalkPoint.x && targetPosition.z >= minWalkPoint.z))
            {
                moving = true;
				move = true;
                Debug.Log("move trigger");
            }
        }
        

    }

    void MovePlayer()
    {
        transform.LookAt(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		if (transform.position == targetPosition)
        {
            moving = false;
            originalPosition = targetPosition;
			move = false;
        }

        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "NPC")
        {
            moving = false;
			move = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Debug.Log("hit boundary");
            for (int i = 0; i < walkZones.Length; i++)
            {
                if (other.name == "walkZone" + i)
                {
                    currentWalkZone = i;
                    walkZone = walkZones[i].GetComponent<Collider>();
                    minWalkPoint = walkZone.bounds.min;
                    Debug.Log(minWalkPoint);
                    maxWalkPoint = walkZone.bounds.max;
                    inWalkZone = true;
                    Debug.Log("changed walk zone");
                }
            }
        }
    }

    
}
 
