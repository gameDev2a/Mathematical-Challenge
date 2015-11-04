using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

    //Horizontal position of the needed number on the screen
	private int NeedLabelY = (Screen.width / 2) - 50;

    //Horizontal position of the acquired numbers on the screen

	//Player 1 Acquired Numbers Labels
	private int LabP1Num1 = (Screen.width * 25) / 100;
	private int LabP1Op;
	private int LabP1Num2;

	//Player 2 Acquired Numbers Labels
	private int LabP2Num1 = (Screen.width * 70) / 100;
	private int LabP2Op;
	private int LabP2Num2;
    
	//Vertical position of labels
    private int LabelX = ((Screen.height * 5) / 100) + 25;

	private int MultLabelX = ((Screen.height * 5) /100) + 50;

    //Size of labels
    private int LabelWidth = 200;
	private int SmallLabelWidth = 50;
    private int LabelHeight = 100;

    //Various Variables
    //These used to edit on-screen label
    int numberNeeded = 100;

	int P1Num1 = 1, P1Num2 = 2, P2Num1 = 3, P2Num2 = 4;
	string P1Op = "+", P2Op = "-";

    //These used to determine what was collected 
    //and add to "numbersCollected" String
    int numberColl;
    string opColl;

	string scene;

    // Use this for initialization
    void Start () {

		scene = Application.loadedLevelName;

		if (!scene.Equals ("SceneMult")) {
			LabP1Num1 = (Screen.width * 15) / 100;
		}
	
	}

    // Update is called once per frame
    void Update () {

    }

	private void OnGUI(){

		getNumbers ();

	}

	private void getNumbers()
	{
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 50;

		LabP1Op = LabP1Num1 + 30;
		LabP1Num2 = LabP1Num1 + 60;

		LabP2Op = LabP2Num1 + 30;
		LabP2Num2 = LabP2Num1 + 60;

		if (scene.Equals ("SceneMult")) {

			GUI.Label (new Rect (NeedLabelY, MultLabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);

			GUI.Label (new Rect (LabP2Num1, LabelX, LabelWidth, LabelHeight), P2Num1.ToString(), style);
			GUI.Label (new Rect (LabP2Op, LabelX, LabelWidth, LabelHeight), P2Op, style);
			GUI.Label (new Rect (LabP2Num2, LabelX, LabelWidth, LabelHeight), P2Num2.ToString(), style);

		} else {
			GUI.Label (new Rect (NeedLabelY, LabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);
		}

		GUI.Label (new Rect (LabP1Num1, LabelX, SmallLabelWidth, LabelHeight), P1Num1.ToString(), style);
		GUI.Label (new Rect (LabP1Op, LabelX, SmallLabelWidth, LabelHeight), P1Op, style);
		GUI.Label (new Rect (LabP1Num2, LabelX, SmallLabelWidth, LabelHeight), P1Num2.ToString(), style);
	}

	/*
	 * This method sets the value displayed on the label "collected numbers"
	 * \param value integer value of the number 
	 * */


	public void setNumberCollected(int value){
		numberColl = value;
	}

	/*
	 * This method sets the value displayed on the label "collected operator"
	 * \param value string the String value of operator
	 * */
	public void setOperatorCollected(string value){
		opColl = value;
	}
}
