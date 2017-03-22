using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dManager;
    public bool pressedInRange = false;
    public string[] dialogueLines;

    public Collider talkRadius;

	// Use this for initialization
	void Start ()
    {
        dManager = FindObjectOfType<DialogueManager>();
        talkRadius = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dManager.talkTrigger == true)
        {
            talkRadius.enabled = false;
            StartCoroutine(WaitTime());
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            
            Debug.Log("colliding with dZone");

            if (Input.GetMouseButtonUp(0))
            {
                    
                if (!dManager.dialogueActive)
                {
                    dManager.dialogueLines = dialogueLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();

                }
            }
            
        }
    }

    private void OnMouseOver()
    {

        dManager.ShowTalkOption();
        
    }

    private void OnMouseExit()
    {
        dManager.talkGO.SetActive(false);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5.0f);
        dManager.talkTrigger = false;
        talkRadius.enabled = true;
    }
}
