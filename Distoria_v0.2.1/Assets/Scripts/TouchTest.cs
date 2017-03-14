using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {


    Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks if the screen detects touch input
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            //sets variable to hold position information on first touch
            Vector3 touch = Input.GetTouch(0).position;
            Debug.Log(touch);
        }

        //triggers when screen first touched
        /*if (Input.GetTouch(0).phase == TouchPhase.Began)
        
        {
            Debug.Log("Touch Began");
        }
        */

	}
}
