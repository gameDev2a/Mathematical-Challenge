﻿using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject numberObject;              // reference to the Number prefab object
	public GameObject operatorObject;			// ref to Operator prefab object
	public GameObject spawns;					// group defines Numbers and Operator amount to be spawned
	public Terrain terrain;
	public LearnerModule learnerModule;
	private int numbers =12;
	private int operators = 5;
	private string randNumber = "";
	private string randOperator = "";
	private ArrayList numbersArray;
	private ArrayList operatorsArray;
	string[] operatorsStr;


	public string getRandomOperator(){
		int rand = Random.Range (0, operatorsArray.Count);
		randOperator = (string)operatorsArray[rand].ToString();
		return randOperator;
	
		
	}
	public string getRandomNumber(){
		int rand = Random.Range (0, numbersArray.Count);
		randNumber = (string)numbersArray[rand].ToString();
		return randNumber;
		
	}

	public void createObjects(){

		//use Learner Module to set Array operators based on user perfoamance
		//learnerModule.updateOperators ();

		//find out spawns childerns 
		numbersArray = new ArrayList();
		operatorsArray = new ArrayList();

		for (int i = 0; i<numbers; i++) {
			GameObject myobject = new GameObject ("Number");
			myobject.transform.SetParent(spawns.transform);
			myobject.tag = "Number";
			myobject.transform.position = new Vector3(0,2,0);
			
		}
		for (int i = 0; i<operators; i++) {
			GameObject myobject = new GameObject ("Operator");
			myobject.transform.SetParent(spawns.transform);
			myobject.transform.position = new Vector3(0,2,0);
		}
		Transform[] spawnedObjects = spawns.GetComponentsInChildren<Transform>();
		//loop through each chiled in spawns object
		foreach (Transform child in spawnedObjects) {
			
			// generate random position in a Vector3
			float Yposition = child.gameObject.transform.position.y;
			Vector3 rndPosition = new Vector3(Random.Range(10,30), Yposition, Random.Range(10,30));
			operatorsStr = new string[]{"+","-","x", "+", "+", "-","x","-"};
			
			
			if (child.name.Equals("Number")) {
				//instantiate the object and assigne a random position
				Instantiate(numberObject).gameObject.transform.position = rndPosition;
				numberObject.GetComponent<TextMesh>().text = Random.Range(1,10).ToString();
				numberObject.name = "Number";
				numbersArray.Add(numberObject.GetComponent<TextMesh>().text);
			}
			if(child.name.Equals("Operator")){
				//instantiate the object and assigne a random position
				Instantiate(operatorObject).gameObject.transform.position = rndPosition;
				operatorObject.GetComponent<TextMesh>().text = operatorsStr[Random.Range(0,operatorsStr.Length)];
				operatorObject.name = "Operator";
				operatorsArray.Add (operatorObject.GetComponent<TextMesh>().text);

			}
		}
	}

	/**
	 *  This method will remove all instantiated object and create a new set of Operators and Numbers.
	 * */
	public void recreateObjects(){
		//learnerModule.updateOperators ();
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))){
			if(obj.tag == "Number" || obj.tag.Equals("Operator")){
				obj.SetActive(false);
				Destroy(obj);
			}
			if(obj.name == "Number(Clone)" || obj.name == "Operator(Clone)"){
				obj.SetActive(false);
			}
			if (obj.name == "Operator(Clone)"){
				obj.SetActive(false);
			}
		}


		foreach (Transform childTransform in spawns.transform) {

			Destroy(childTransform.gameObject);
		}
		numbersArray.Clear();
		operatorsArray.Clear ();
		createObjects ();


	}
	public void setNumbers(int value){numbers = value;}
	public void setOperators(int value){operators = value;}
	public void setOperatorsString(string[] value){operatorsStr = value;}


}
