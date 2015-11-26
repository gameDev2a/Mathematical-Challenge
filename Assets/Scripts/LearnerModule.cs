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

	public int getP1Score() {return currScore;}	
	public void setP1Score(int value) {currScore = value;}	
	public int getP1Addition() {return additionPerformance;}	
	public void setP1Addition(int value) {additionPerformance = value;}	
	public int getP1Substraction() {return substractionPerformance;}	
	public void setP1Substraction(int value) {substractionPerformance = value;}	
	public int getP2Substraction() {return multiplicationPerformance;}	
	public void setP2Substraction(int value) {multiplicationPerformance = value;}


	public void setPlayer1Name(string value){ player1Name = value;}
	public void setPlayer2Name(string value){ player2Name = value;}

	
	public void PerformedAddition(string playerName ,int value){
			
		webRequests.updateDatabase(playerName, 1, value, 0, 0);
		string a = webRequests.getTopScores();
		setP1Score (currScore += 1);
	}
	public void PerformedSubstraction(string playerName, int value){
		webRequests.updateDatabase(playerName, 1, 0, value, 0);
		setP1Score (currScore += 1);
	}
	public void PerformedMultiplication(string playerName, int value){
		webRequests.updateDatabase(playerName, 1, 0, 0, value);
		setP1Score (currScore += 1);
	}

	public string getPlayer1Name(){
		return player1Name;
	}
	public string getPlayer2Name(){
		return player2Name;
	}

	void Start(){

		player1Name = PlayerPrefs.GetString("player1Name");

		if(PlayerPrefs.GetString("player2Name") != ""){
			player2Name = PlayerPrefs.GetString("player2Name");
		}

	}

	public void updateOperators(){
		string addition = "";
		string substraction = "";
		string multiplication = "";
		string performanaces = webRequests.getOperationsPerformance (PlayerPrefs.GetString("player1Name"));

		string[] arrayPerformance = performanaces.Split(':');

		//asign values of performances

		addition = arrayPerformance[0];
		substraction = arrayPerformance[1];
		multiplication = arrayPerformance[2];

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

		createOperatorsArray ();
	}

	private void createOperatorsArray (){
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
		instantiateObjects.setOperatorsString (arrayValue);

		//for (int i = 0; i <myArray.Count; i++){
		//	print("index: "+arrayValue[i]);
		//}

	}
}
