using UnityEngine;
using System.Collections;

public class LearnerModule : MonoBehaviour {

	public WebRequests webRequests;
	public InstantiateObjects instantiateObjects;
	private int currScore;
	private int additionPerformance;
	private int substractionPerformance;
	private int multiplicationPerformance;
	private string player1Name;
	private string player2Name;


	/**
	 * Getters and setters
	 * */

	public int GetP1Score() {return currScore;}	
	public void SetP1Score(int value) {currScore = value;}	
	public int GetP1Addition() {return additionPerformance;}	
	public void SetP1Addition(int value) {additionPerformance = value;}	
	public int GetP1Substraction() {return substractionPerformance;}	
	public void SetP1Substraction(int value) {substractionPerformance = value;}	
	public int GetP2Substraction() {return multiplicationPerformance;}	
	public void SetP2Substraction(int value) {multiplicationPerformance = value;}

	//setters for players name
	public void SetPlayer1Name(string value){ player1Name = value;}
	public void SetPlayer2Name(string value){ player2Name = value;}


	/**
	 * This method will update the score and the addition performance score in the database, when performing addition equasions
	 * /param string playerName
	 * /param int value
	 * */
	public void PerformedAddition(string playerName ,int value){
			
		webRequests.UpdateDatabase(playerName, 1, value, 0, 0);
		string a = webRequests.GetTopScores();
		SetP1Score (currScore += 1);
	}
	/**
	 * This method will update the database with player score and substraction pefroamance score when performing substraction equasions
	 * */
	public void PerformedSubstraction(string playerName, int value){
		webRequests.UpdateDatabase(playerName, 1, 0, value, 0);
		SetP1Score (currScore += 1);
	}

	/**
	 * This method will update the database with player score and multiplication pefroamance score when performing multiplication equasions
	 * */
	public void PerformedMultiplication(string playerName, int value){
		webRequests.UpdateDatabase(playerName, 1, 0, 0, value);
		SetP1Score (currScore += 1);
	}

	/*
	 * This method will return first player nickname
	 * @return string first player name
	 * */
	public string GetPlayer1Name(){
		return player1Name;
	}

	/**
	 * This method will return second player nickname
	 * @return string second player name
	 * */
	public string GetPlayer2Name(){
		return player2Name;
	}

	void Start(){

		player1Name = PlayerPrefs.GetString("player1Name");

		if(PlayerPrefs.GetString("player2Name") != ""){
			player2Name = PlayerPrefs.GetString("player2Name");
		}

	}

	/**
	 * This method will request player performances on each; addition, substraction and multiplication
	 * then will create set of array Operators based on the plyer perfomance
	 * */
	public void UpdateOperators(){
		//player1Name = PlayerPrefs.GetString("player1Name");
		string addition = webRequests.GetAdditionPerformance("Omar");
		string substraction = webRequests.GetSubstractionPerformance("Omar");
		string multiplication = webRequests.GetMultiplicationPerformance ("Omar");

		print ("Addition result" + addition);

		//asign values of performances



		//calculate avergae perfoamances
		int additionAvg = int.Parse (addition)+int.Parse (substraction)+int.Parse (multiplication) / int.Parse (addition);
		int substractionAvg = int.Parse (addition)+int.Parse (substraction)+int.Parse (multiplication) / int.Parse (substraction);
		int multiplicationAvg = int.Parse (addition)+int.Parse (substraction)+int.Parse (multiplication) / int.Parse (multiplication);

		//set up value of Addition operators
		if (additionAvg > 5) {
			additionPerformance = 1;
		} else if (additionAvg < 5 && additionAvg > 10) {
			additionPerformance = 2;
		} else if (additionAvg < 10 && additionAvg > 21) {
			additionPerformance =  3;
		} else {
			additionPerformance = 3;
		}

		//set up value of substraction operators
		if (substractionAvg > 5) {
			substractionPerformance = 1;
		} else if (substractionAvg < 5 && substractionAvg > 10) {
			substractionPerformance = 2;
		} else if (substractionAvg < 10 && substractionAvg > 21){
			substractionPerformance = 3;
		}else {
			substractionPerformance = 3;
		}

		//set up multiplictions operator value
		if (multiplicationAvg > 5) {
			multiplicationPerformance = 1;
		} else if (multiplicationAvg < 5 && multiplicationAvg > 10) {
			multiplicationPerformance = 2;
		} else if (multiplicationAvg < 10 && multiplicationAvg > 21){
			multiplicationPerformance = 3;
		}else {
			multiplicationPerformance = 3;
		}

		CreateOperatorsArray ();
	}

	/**
	 * This method will create Operators array based on the player perfoamnce, the array will be used to generate operators for the player on the scene
	 * */
	private void CreateOperatorsArray (){
		int total = additionPerformance + substractionPerformance + multiplicationPerformance - 1;
		ArrayList myArray = new ArrayList ();

		switch (additionPerformance) {
		case 1:
			myArray.Add("+");
			break;
		case 2:
			myArray.Add("+");
			myArray.Add("+");
			break;
		case 3:
			myArray.Add("+");
			myArray.Add("+");
			myArray.Add("+");
			break;
		}

		switch (substractionPerformance) {
			case 1:
				myArray.Add ("-");
				break;
			case 2:
				myArray.Add ("-");
				myArray.Add ("-");
				break;
			case 3:
				myArray.Add ("-");
				myArray.Add ("-");
				myArray.Add ("-");
				break;
		}

		switch (multiplicationPerformance) {
			case 1:
				myArray.Add ("x");
			break;
			case 2:
				myArray.Add ("x");
				myArray.Add ("x");
				break;
			case 3:
				myArray.Add ("x");
				myArray.Add ("x");
				myArray.Add ("x");
				break;
		}

		string[] arrayValue = new string[myArray.Count];
		myArray.CopyTo (arrayValue);
		instantiateObjects.SetOperatorsString (arrayValue);


	}
}
