using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	/* Global Variables */
	private int sequence = 1; /**< int value of equation sequence */ 
	private int result;
	private int firstNumberValue;
	private string operatorValue;
	private int targetNumber;
	public PlayerGui playerGui;
	public MultiMode MultiMode;
	public SoundScript soundScript;
	public PlayerLives playerLives;
	public GameObject playerObject;
	public LearnerModule learnerModule;
	private Vector3 respawnPosition;

	private string player;
	private int sequence2 = 1;
	private string scene;
	private int targetNumber2;
	private int mode = 2;

	void Start(){
		respawnPosition = playerObject.GetComponent<Transform> ().position;

		//mode = MultiMode.getMode ();

		player = playerObject.tag;

		scene = Application.loadedLevelName;
		newTargetNumber ();
	}

	/**
	 * This method is triggered when the player enters any colliders objects on the level
	 * \param c the objects collider
	 * \param tag String tag value of the collided object
	 * @see IsNumber() @see ComponentsToDisplay() @see IncreaseSequence() @see IsLoadedLevel() @see ShowOperators @see ShowNumbers() @see ShowOperators() @see TurnFlashLightOn()
	 * */
	private void OnTriggerEnter(Collider c)
	{
		string tag = c.tag;

		if(player.Equals("Player1") || !scene.Equals ("SceneMult")){

			if (!tag.Equals ("WaterLimit")) {

				string temp = c.GetComponent<TextMesh> ().text;
				
				if (IsNumber (tag) && sequence == 1) {
					soundScript.PlayPickupSound ();
					IncreaseSequence ();
					playerGui.setP1Num1 (temp);
				} else if (IsOperator (tag) && sequence == 2) {

					soundScript.PlayPickupSound ();
					IncreaseSequence ();
					playerGui.setP1Op (temp);
				} else if (IsNumber (tag) && sequence == 3) {
					IncreaseSequence ();
					soundScript.PlayPickupSound ();
					playerGui.setP1Num2 (temp);

					Calculate ();
				} else {
					soundScript.PlayErrSound ();
				}

			} else {
				print ("hit Water");
				playerLives.WrongAnswer(player);
				RespawnPlayer();
			}
		}else if(player.Equals("Player2")){
			
			if (!tag.Equals ("WaterLimit")) {
				
				string temp = c.GetComponent<TextMesh> ().text;
				
				if (IsNumber (tag) && sequence2 == 1) {
					soundScript.PlayPickupSound ();
					IncreaseSequence2 ();
					playerGui.setP2Num1 (temp);
				} else if (IsOperator (tag) && sequence2 == 2) {
					
					soundScript.PlayPickupSound ();
					IncreaseSequence2 ();
					playerGui.setP2Op (temp);
				} else if (IsNumber (tag) && sequence2 == 3) {
					IncreaseSequence2 ();
					soundScript.PlayPickupSound ();
					playerGui.setP2Num2 (temp);
					
					Calculate ();
				} else {
					soundScript.PlayErrSound ();
				}
				
			} else {
				print ("hit Water");
				playerLives.WrongAnswer(player);
				RespawnPlayer();
			}
		}
	}
	/**
	 * This method checks the condition of win
	 * \return bool (true: if @see targetNumber is equal calculation result @see firstNumberValue)
	 * */
	private bool IsWinner(){

		if(firstNumberValue == targetNumber ){
			return true;
		}else{ return false;}
	}
	
	public void newTargetNumber(){

		if (player.Equals ("Player1") || !scene.Equals ("SceneMult")) {
			targetNumber = Random.Range (1, 10);
			playerGui.setNumberNeeded (targetNumber.ToString ());
		} else if (mode == 2) {
			targetNumber2 = Random.Range (1, 10);
			playerGui.setNumberNeeded2 (targetNumber2.ToString ());
		}

	}
	public void newTargetNumber(int minRange, int maxrange){
		targetNumber = Random.Range (minRange, maxrange);
	}
	
	
	public void setFirtsNumber(int value){
		firstNumberValue = value;
	}

	
	/**
	 * This method is used to confirm any String is a Number or not
	 * @see IsOperator()
	 * \param s String to be checked
	 * \return bool (true: if the String passed is a Number)
	 * */
	private bool IsNumber(string s){
		if (s == "+") { return false;
		} else if (s == "X") { return false;
		} else if (s == "-") { return false;
		} else if (s == "FlashLight") { return false;
		} else { return true; }
	}
	
	/**
	 * This method is used to check if a String is an Operator or not
	 * @see IsNumber()
	 * \param s String to be checked
	 * \return bool (true: if the String passed is an Operator)
	 * */
	private bool IsOperator(string s){
		if (s == "+") { return true;
		} else if (s == "X") { return true;
		} else if (s == "-") { return true;
		} else { return false; }
	}
	
	/**This method (setter) sets the value OperatorValue to the String passed
	 * \param s String will be the value of the Operator
	 * @see GetOperatorValue()
	 *  */
	private void SetOperator(string s){ operatorValue = s; }
	
	/**
	 * This method (getter) return the current operatorValue
	 * return String value of the Operator
	 * */
	private string GetOperatorValue(){ return operatorValue; }
	
	
	/**
	 * A method to increase the sequence of the equation:
	 * 1: first number. 2: operator. 3: second number
	 * \param sequence Int represents what object need to be picked up (Operator or a Number)
	 * */
	private void IncreaseSequence(){
		
		if (sequence < 3) { sequence ++; } 
		else { sequence = 1;}
	}

	private void IncreaseSequence2(){
		
		if (sequence2 < 3) { sequence2 ++; } 
		else { sequence2 = 1;}
	}
	
	/**
	 * This method performs calculation using (firstnumber, operator, secondnumber)
	 * */
	private void Calculate(){
		if(player.Equals ("Player1")){
			int firstNum = int.Parse(playerGui.getP1Num1());
			int secondNum = int.Parse(playerGui.getP1Num2());
			string currentOperator = playerGui.getP1Op ();
			
			if(currentOperator == "X"){  result = firstNum * secondNum;  }
			else if(currentOperator == "+"){  result =firstNum + secondNum;  }
			else if(currentOperator == "-"){  result =firstNum - secondNum;  }
			playerGui.setP1Op ("");
			playerGui.setP1Num1(result.ToString());
			playerGui.setP1Num2 ("");
			sequence = 2;
			print (firstNum +" : "+ secondNum);
			if(IsWinner()){
				soundScript.PlayWinSound();
				//load next level   <---------------------------
			}
		}else if(player.Equals ("Player2")){
			int firstNum = int.Parse(playerGui.getP2Num1());
			int secondNum = int.Parse(playerGui.getP2Num2());
			string currentOperator = playerGui.getP2Op ();
			
			if(currentOperator == "X"){  result = firstNum * secondNum;  }
			else if(currentOperator == "+"){  result =firstNum + secondNum;  }
			else if(currentOperator == "-"){  result =firstNum - secondNum;  }
			playerGui.setP2Op ("");
			playerGui.setP2Num1(result.ToString());
			playerGui.setP2Num2 ("");
			sequence2 = 2;
		}
		
	}

	private void RespawnPlayer(){
		playerObject.transform.position = respawnPosition;

	}
}
