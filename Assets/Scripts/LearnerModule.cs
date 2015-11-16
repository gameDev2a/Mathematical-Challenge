using UnityEngine;
using System.Collections;

public class LearnerModule : MonoBehaviour {

	private int currScore;
	private int cdditionPerformance;
	private int substractionPerformance;
	private int multiplicationPerformance;

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
}
