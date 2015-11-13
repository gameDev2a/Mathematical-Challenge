using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

	public GetInput nickname1;
	public GetInput nickname2;

    //Horizontal position of the needed number on the screen
	private int NeedLabelY = (Screen.width / 2) - 50;

    //Horizontal position of the acquired numbers on the screen

	//Player 1 Acquired Numbers Labels
	public int LabP1Num1 = (Screen.width * 25) / 100;
	private int LabP1Op;
	private int LabP1Num2;

	//Player 2 Acquired Numbers Labels
	public int LabP2Num1 = (Screen.width * 70) / 100;
	private int LabP2Op;
	private int LabP2Num2;

	//Multiplayer Nickname Labels
	private int P1Nick = (Screen.width * 25) / 100;
	private int P2Nick = (Screen.width * 70) / 100;
    
	//Vertical position of labels
    private int LabelX = ((Screen.height * 5) / 100) + 25;

	private int MultLabelX = ((Screen.height * 5) /100) + 50;

	private int NickLabelX = ((Screen.height * 85) / 100);

    //Size of labels
    private int LabelWidth = 200;
	private int SmallLabelWidth = 50;
    private int LabelHeight = 100;

    //Various Variables
    //These used to edit on-screen label
    string numberNeeded = "100";

	string P1Num1 = "1", P1Num2 = "2", P2Num1 = "3", P2Num2 = "4";
	string P1Op = "+", P2Op = "-";

    //These used to determine what was collected 
    //and add to "numbersCollected" String
    int numberColl;
    string opColl;

	string nick1 = "nick1", nick2 = "nick2";

	string scene;
	int size1, size2;

    // Use this for initialization
    void Start () {

		scene = Application.loadedLevelName;

		if (!scene.Equals ("SceneMult")) {
			LabP1Num1 = (Screen.width * 15) / 100;

			//nick1 = nickname1.getNickName1();
			//nick2 = nickname2.getNickName2();

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

		size1 = P1Num1.Length;
		size2 = P2Num1.Length;

		LabP1Op = LabP1Num1 + (size1 * 30);
		LabP1Num2 = LabP1Op + 30;

		LabP2Op = LabP2Num1 + (size2 * 30);
		LabP2Num2 = LabP2Op + 30;

		if (scene.Equals ("SceneMult")) {

			GUI.Label (new Rect (NeedLabelY, MultLabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);

			//Numbers Collected Labels
			GUI.Label (new Rect (LabP2Num1, LabelX, SmallLabelWidth, LabelHeight), P2Num1.ToString(), style);
			GUI.Label (new Rect (LabP2Op, LabelX, SmallLabelWidth, LabelHeight), P2Op, style);
			GUI.Label (new Rect (LabP2Num2, LabelX, SmallLabelWidth, LabelHeight), P2Num2.ToString(), style);

			//Nickname Labels
			GUI.Label (new Rect (P1Nick, NickLabelX, LabelWidth, LabelHeight), nick1, style);
			GUI.Label (new Rect (P2Nick, NickLabelX, LabelWidth, LabelHeight), nick2, style);

		} else {
			GUI.Label (new Rect (NeedLabelY, LabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);
		}

		//First Player Numbers Collected
		GUI.Label (new Rect (LabP1Num1, LabelX, (SmallLabelWidth * size1), LabelHeight), P1Num1.ToString(), style);
		GUI.Label (new Rect (LabP1Op, LabelX, SmallLabelWidth, LabelHeight), P1Op, style);
		GUI.Label (new Rect (LabP1Num2, LabelX, SmallLabelWidth, LabelHeight), P1Num2.ToString(), style);
	}

	//getters and setters...
	public void setP1Num1(string value){P1Num1 = value;}
	public string getP1Num1(){return P1Num1;}
	public void setP1Num2(string value){P1Num2 = value;}
	public string getP1Num2(){return P1Num2;}
	public void setP2Num1(string value){P2Num1 = value;}
	public string getP2Num1(){return P2Num1;}
	public void setP2Num2(string value){P2Num2 = value;}
	public string getP2Num2(){return P2Num2;}
	
	public void setP1Op(string value){P1Op = value;}
	public string getP1Op(){return P1Op;}
	
	public void setP2Op(string value){P2Op = value;}
	public string getP2Op(){return P2Op;}

	/*
	 * This method sets the value displayed on the label "collected operator"
	 * \param value string the String value of operator
	 * */
	public void setOperatorCollected(string value){
		opColl = value;
	}
}
