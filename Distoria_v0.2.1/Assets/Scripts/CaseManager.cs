using UnityEngine;
using System.Collections;

public class CaseManager : MonoBehaviour {

    public CaseObject[] cases;
    public bool[] caseCompleted;

    public DialogueManager dialogueManagerScript;

	// Use this for initialization
	void Start () {

        caseCompleted = new bool[cases.Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowCaseText(string caseText)
    {
        dialogueManagerScript.dialogueLines = new string[1];
        dialogueManagerScript.dialogueLines[0] = caseText;

        dialogueManagerScript.currentLine = 0;
        dialogueManagerScript.ShowDialogue();
    }
}
