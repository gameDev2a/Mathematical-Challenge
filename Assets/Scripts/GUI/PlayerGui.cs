using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

	public MultiMode MultiMode;
	public GameObject joystic;


    //Horizontal position of the needed number on the screen
	private int NeedLabelY = (Screen.width / 2) - 50;

	private int NeedLabel1 = (Screen.width * 25) / 100;
	private int NeedLabel2 = (Screen.width * 70) / 100;

    //Horizontal position of the acquired numbers on the screen

	//Player 1 Acquired Numbers Labels
	private int LabP1Num1 = ((Screen.width * 25) / 100) - 25;
	private int LabP1Op;
	private int LabP1Num2;

	//Player 2 Acquired Numbers Labels
	private int LabP2Num1 = ((Screen.width * 70) / 100) - 25;
	private int LabP2Op;
	private int LabP2Num2;

	//Multiplayer Nickname Labels
	private int P1Nick = (Screen.width * 25) / 100;
	private int P2Nick = (Screen.width * 70) / 100;
    
	//Vertical position of labels
    private int LabelX = ((Screen.height * 5) / 100) + 25;
	private int Label2X = (Screen.height * 5) / 100;

	private int MultLabelX = ((Screen.height * 5) / 100) + 50;

	private int NickLabelX = ((Screen.height * 85) / 100);

    //Size of labels
    private int LabelWidth = 200;
	private int SmallLabelWidth = 50;
    private int LabelHeight = 100;

    //Various Variables
    //These used to edit on-screen label
    string numberNeeded = "";
	string numberNeeded2 = "";

	string P1Num1 = "", P1Num2 = "", P2Num1 = "", P2Num2 = "";
	string P1Op = "", P2Op = "";

    //These used to determine what was collected 
    //and add to "numbersCollected" String
    int numberColl;
    string opColl;

	string nick1 = "nick1", nick2 = "nick2";

	string scene;
	int size1, size2;
	int mode = 2;
	/// <summary>
	/// Sets and gets the name of the scene.
	/// </summary>
	/// <param name="name">Name.</param>
	public void setSceneName(string name){
		scene = name;
	}
	public string getSceneName(){
		return scene;
	}
   /// <summary>
   /// Start this instance.
   /// </summary>
    void Start () {
		//add nicknames to GUI
		nick1 = PlayerPrefs.GetString ("nick1");
		nick2 = PlayerPrefs.GetString ("nick2");
		//check if is android and add virtual joystic
		if (menuScript.isWindows) {
			joystic.SetActive(false);
		} else {
			joystic.SetActive(true);
		}
		setSceneName (Application.loadedLevelName);
		//scene = Application.loadedLevelName;

		if (!scene.Equals ("SceneMult")) {
			LabP1Num1 = (Screen.width * 15) / 100;

			//mode = MultiMode.getMode ();

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

		GUIStyle style2 = new GUIStyle(GUI.skin.label);
		style2.fontSize = 30;

		size1 = P1Num1.Length;
		size2 = P2Num1.Length;

		LabP1Op = LabP1Num1 + (size1 * 30);
		LabP1Num2 = LabP1Op + 30;

		LabP2Op = LabP2Num1 + (size2 * 30);
		LabP2Num2 = LabP2Op + 30;

		if (scene.Equals ("SceneMult")) {

			if(mode == 1){

				//Number Needed Label
				GUI.Label (new Rect (NeedLabelY, MultLabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);
				
				//Numbers Collected Labels
				GUI.Label (new Rect (LabP2Num1, LabelX, SmallLabelWidth, LabelHeight), P2Num1.ToString(), style);
				GUI.Label (new Rect (LabP2Op, LabelX, SmallLabelWidth, LabelHeight), P2Op, style);
				GUI.Label (new Rect (LabP2Num2, LabelX, SmallLabelWidth, LabelHeight), P2Num2.ToString(), style);

			}else if(mode == 2){

				//Numbers Needed Labels
				GUI.Label (new Rect (NeedLabel1, Label2X, LabelWidth, LabelHeight), numberNeeded.ToString (), style);
				GUI.Label (new Rect (NeedLabel2, Label2X, LabelWidth, LabelHeight), numberNeeded2.ToString (), style);
				
				//Numbers Collected Labels
				GUI.Label (new Rect (LabP2Num1, MultLabelX, (SmallLabelWidth * size2), LabelHeight), P2Num1.ToString(), style2);
				GUI.Label (new Rect (LabP2Op, MultLabelX, SmallLabelWidth, LabelHeight), P2Op, style2);
				GUI.Label (new Rect (LabP2Num2, MultLabelX, SmallLabelWidth, LabelHeight), P2Num2.ToString(), style2);

			}

			//Nickname Labels
			GUI.Label (new Rect (P1Nick, NickLabelX, LabelWidth, LabelHeight), nick1, style);
			GUI.Label (new Rect (P2Nick, NickLabelX, LabelWidth, LabelHeight), nick2, style);

		} else {
			GUI.Label (new Rect (NeedLabelY, LabelX, LabelWidth, LabelHeight), numberNeeded.ToString (), style);
			GUI.Label (new Rect (5, 5, LabelWidth, LabelHeight), nick1, style);
		}

		if (mode == 2) {

			//First Player Numbers Collected
			GUI.Label (new Rect (LabP1Num1, MultLabelX, (SmallLabelWidth * size1), LabelHeight), P1Num1.ToString (), style2);
			GUI.Label (new Rect (LabP1Op, MultLabelX, SmallLabelWidth, LabelHeight), P1Op, style2);
			GUI.Label (new Rect (LabP1Num2, MultLabelX, SmallLabelWidth, LabelHeight), P1Num2.ToString (), style2);

		} else {

			//First Player Numbers Collected
			GUI.Label (new Rect (LabP1Num1, LabelX, (SmallLabelWidth * size1), LabelHeight), P1Num1.ToString (), style);
			GUI.Label (new Rect (LabP1Op, LabelX, SmallLabelWidth, LabelHeight), P1Op, style);
			GUI.Label (new Rect (LabP1Num2, LabelX, SmallLabelWidth, LabelHeight), P1Num2.ToString (), style);

		}
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
	public void setNumberNeeded(string value){numberNeeded = value;}
	public string getNumberNeeded(){return numberNeeded;}
	public void setNumberNeeded2(string value){numberNeeded2 = value;}
	public string getNumberNeeded2(){return numberNeeded2;}
	/*
	 * This method sets the value displayed on the label "collected operator"
	 * \param value string the String value of operator
	 * */
	public void setOperatorCollected(string value){
		opColl = value;
	}
}
