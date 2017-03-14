using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider progressBar;
    public int progressValue;
    public Text activeCase;
    public string activeCaseName;
    //reference case script

    private static bool UIExists;

	// Use this for initialization
	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        activeCaseName = "Speak to the Citizen";
        activeCase.text = activeCaseName;
        progressValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //activeCase.text = "Case: ";
        activeCase.text = activeCaseName;
        progressBar.value = progressValue;

	}
}
