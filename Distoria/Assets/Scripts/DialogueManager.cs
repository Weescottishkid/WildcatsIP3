using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public GameObject talkGO;
    public Text dText;
    public Text dTalk;
    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;
    public bool talkTrigger;
    

    public GameObject uiManager;
    public UIManager uiManagerScript;

    // Use this for initialization
    void Start () {
        uiManager = GameObject.Find("UIManager");
        uiManagerScript = uiManager.gameObject.GetComponent<UIManager>();

        talkTrigger = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dialogueActive && Input.GetMouseButtonDown(0))
        {
            currentLine++;
        }

        if(currentLine >= dialogueLines.Length && Input.GetMouseButtonDown(0) && talkTrigger == false)
        {
            talkTrigger = true;
            dBox.SetActive(false);
            dialogueActive = false;
            uiManagerScript.progressValue = 1;
            uiManagerScript.activeCaseName = "Speak to the Citizen - Complete!";
            currentLine = 0;
            
        }
        
        dText.text = dialogueLines[currentLine];

    }


    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
    }

    public void ShowTalkOption()
    {
        talkGO.SetActive(true);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.0f);
        talkTrigger = false;
    }
}
