﻿using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	
	
	/* Global Variables */
	private int sequence = 1; /**< int value of equation sequence */ 
	private bool isFirstNum;   
	private bool isSecondNum ;
	private bool isOperator ;
	private int result;
	private int firstNumberValue;
	private int secondNumberValue;
	private string operatorValue;
	private int targetNumber;
	public PlayerGui playerGui;
	public SoundScript soundScript;



	/**
	 * This method is triggered when the player enters any colliders objects on the level
	 * \param c the objects collider
	 * \param tag String tag value of the collided object
	 * @see IsNumber() @see ComponentsToDisplay() @see IncreaseSequence() @see IsLoadedLevel() @see ShowOperators @see ShowNumbers() @see ShowOperators() @see TurnFlashLightOn()
	 * */
	private void OnTriggerEnter(Collider c)
	{

		string tag = c.tag;
		string temp = c.GetComponent<TextMesh>().text;
		
		if (IsNumber (tag) && sequence == 1) {
			soundScript.PlayPickupSound ();
			IncreaseSequence ();
			playerGui.setP1Num1 (int.Parse (temp));
		} else if (IsOperator (tag) && sequence == 2) {

			soundScript.PlayPickupSound ();
			IncreaseSequence ();
			playerGui.setP1Op (temp);
		} else if (IsNumber (tag) && sequence == 3) {
			IncreaseSequence ();
			soundScript.PlayPickupSound ();
			playerGui.setP1Num2 (int.Parse (temp));

			Calculate();
		} else {
			soundScript.PlayErrSound();
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
		targetNumber = Random.Range (1, 10);
	}
	public void newTargetNumber(int minRange, int maxrange){
		targetNumber = Random.Range (minRange, maxrange);
	}
	
	
	public void setFirtsNumber(int value){
		firstNumberValue = value;
	}
	
	public void setSecondNumber(int value){
		secondNumberValue = value;
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
	
	/**
	 * This method performs calculation using (firstnumber, operator, secondnumber)
	 * */
	private void Calculate(){
		int firstNum = playerGui.getP1Num1();
		int secondNum = playerGui.getP1Num2();
		string currentOperator = playerGui.getP1Op ();
		
		if(currentOperator == "X"){  result = firstNum * secondNum;  }
		else if(currentOperator == "+"){  result =firstNum + secondNum;  }
		else if(currentOperator == "-"){  result =firstNum - secondNum;  }
		isSecondNum = false;
		isOperator = false;
		playerGui.setP1Op ("");
		playerGui.setP1Num1(result);
		sequence = 2;
		
	}
}
