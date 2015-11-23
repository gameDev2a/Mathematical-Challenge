using UnityEngine;
using System.Collections;

public class LearnerModule : MonoBehaviour {

	public WebRequests webRequests;
	private int currScore;
	private int cdditionPerformance;
	private int substractionPerformance;
	private int multiplicationPerformance;
	private string player1Name;
	private string player2Name;


	/**
	 * Getters and setters
	 * */

	public int getP1Score() {return currScore;}	
	public void setP1Score(int value) {currScore = value;}	
	public int getP1Addition() {return cdditionPerformance;}	
	public void setP1Addition(int value) {cdditionPerformance = value;}	
	public int getP1Substraction() {return substractionPerformance;}	
	public void setP1Substraction(int value) {substractionPerformance = value;}	
	public int getP2Substraction() {return multiplicationPerformance;}	
	public void setP2Substraction(int value) {multiplicationPerformance = value;}

	public void generateNumbers(){
		//based on the player perfromance generate numbers

	}

	public void generateOperators(){
		//based on the player perfromance generate operators
	}

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
		player2Name = PlayerPrefs.GetString("player2Name");

	}
}
