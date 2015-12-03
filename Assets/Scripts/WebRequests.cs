using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class WebRequests : MonoBehaviour {
	
	private string result;
	private string url = "http://localhost:8888/dbFunctions.php";
	/**
	 * This method will either update informations of an existing player or if none existing will create new one
	 * @param string playerName
	 * @param int score
	 * @param int addition: player performance on addition equasions
	 * @param int substraction: Player performance on substraction
	 * @param int multiplication: Player perforamnce on multiplication equasions
	 * */
	public void UpdateDatabase(string playerName, int score, int addition, int substraction, int multiplication){
		

		WWWForm form = new WWWForm();
		form.AddField ("action", "insertPerformance");
		form.AddField("playerName", ""+playerName);
		form.AddField("score", score);
		form.AddField("addition", addition);
		form.AddField("substraction", substraction);
		form.AddField("multiplication", multiplication);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));

		
	}

	/**
	 * This methos will return top 5 scroes
	 * */
	public string GetTopScores(){

		WWWForm form = new WWWForm();
		form.AddField ("action", "getTopScores");
		WWW www = new WWW(url, form);
		//StartCoroutine (WaitForRequest (www));

		//return StartCoroutine(WaitForRequest(www)).ToString();
		//System.Threading.Thread.Sleep(1000);

		return result;

	}

	/**
	 * This methos will return score for a given player name string value
	 * @param string playerName
	 * */
	public string GetPerformance(string playerName){
		

		WWWForm form = new WWWForm();
		form.AddField ("action", "getPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));

		//return StartCoroutine(WaitForRequest(www)).ToString();

		return result;//www.text;
		//return www.text;
		
	}

	/**
	 * This method will return addition & substraction & multiplication perforamances for a given player name
	 * @param string playerName
	 * */
	public string GetOperationsPerformance(string playerName){
		

		WWWForm form = new WWWForm();
		form.AddField ("action", "getOperationsPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return result;
		//return www.text;
	}

	public string GetAdditionPerformance(string playerName){

		WWWForm form = new WWWForm();
		form.AddField ("action", "getAdditionPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));

		return result;
	}

	public string GetSubstractionPerformance(string playerName){
		
		WWWForm form = new WWWForm();
		form.AddField ("action", "getSubstractionPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return result;
	}

	public string GetMultiplicationPerformance(string playerName){
		
		WWWForm form = new WWWForm();
		form.AddField ("action", "getMultiplicationPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return result;
	}
	/**
	 * This method will insure a return value for www request
	 * */
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null){
			Debug.Log(www.text);

			result = System.Text.Encoding.UTF8.GetString(www.bytes, 0, www.bytes.Length);
	

		} else {
			Debug.Log("WWW Error: "+ www.error);
			
		}    
	}  
	void Start(){
		//updateDatabase ("Omar", 10,11,12,13);
		//GetPerformance ("Omar");
		//print(getTopScores ());
		//getPerformance
	}
}
