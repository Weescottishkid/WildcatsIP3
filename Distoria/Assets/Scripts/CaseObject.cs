using UnityEngine;
using System.Collections;

public class CaseObject : MonoBehaviour {

    public int caseNumber;
    public CaseManager caseManagerScript;

    public string startText;
    public string endText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartCase()
    {
        caseManagerScript.ShowCaseText(startText);
    }

    public void EndCase()
    {
        caseManagerScript.ShowCaseText(endText);
        caseManagerScript.caseCompleted[caseNumber] = true;
        gameObject.SetActive(false);
    }
}
