using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

    //Horizontal position of the needed number on the screen
	private int NeedLabelY = Screen.width / 2;

    //Horizontal position of the wanted number on the screen
    private int HaveLabelY = (Screen.width * 20) / 100;

    //Vertical position of both labels
    private int LabelX = ((Screen.height * 5) / 100) + 25;

    //Size of both labels
    private int LabelWidth = 200;
    private int LabelHeight = 100;

    //Various Variables
    //These used to edit on-screen label
    int numberNeeded = 100;
    string numbersCollected = "100";

    //These used to determine what was collected 
    //and add to "numbersCollected" String
    int numberColl;
    string opColl;

    // Use this for initialization
    void Start () {
	
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

		GUI.Label(new Rect(NeedLabelY, LabelX, LabelWidth, LabelHeight), numberNeeded.ToString(), style);
		GUI.Label (new Rect (HaveLabelY, LabelX, LabelWidth, LabelHeight), numbersCollected, style);
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
