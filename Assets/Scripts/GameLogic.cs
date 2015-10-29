using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	
	
	/* Global Variables */
	private int sequence = 1; /**< int value of equation sequence */ 
	private bool isFirstNum;   
	private bool isSecondNum ;
	private bool isOperator ;
	private bool carryingFlashLight = false;
	private int result;
	private int firstNumberValue;
	private int secondNumberValue;
	private string operatorValue;
	private int targetNumber;
	private PlayerGui playerGui;


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
		int firstNum = firstNumberValue;
		int secondNum = secondNumberValue;
		string currentOperator = GetOperatorValue ();
		
		if(currentOperator == "X"){  result = firstNum * secondNum;  }
		else if(currentOperator == "+"){  result =firstNum + secondNum;  }
		else if(currentOperator == "-"){  result =firstNum - secondNum;  }
		isSecondNum = false;
		isOperator = false;
		currentOperator = null;
		firstNumberValue = result;
		sequence = 2;
		
	}
	void Start(){
		playerGui = gameObject.GetComponent<PlayerGui> ();
		playerGui.setNumberCollected (1);
	}
}
