using UnityEngine;
using System.Collections;

public class WebRequests : MonoBehaviour {
	
	private string result = "";
	public void updateDatabase(string playerName, int score, int addition, int substraction, int multiplication){
		
		string url = "http://localhost:8888/dbFunctions.php";
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

	public string getTopScores(){
		string url = "http://localhost:8888/dbFunctions.php";
		WWWForm form = new WWWForm();
		form.AddField ("action", "getTopScores");
		WWW www = new WWW(url, form);
		StartCoroutine (WaitForRequest (www));

		//return StartCoroutine(WaitForRequest(www)).ToString();
		//System.Threading.Thread.Sleep(1000);

		return result;

	}
	public string getPerformance(string playerName){
		
		string url = "http://localhost:8888/dbFunctions.php";
		WWWForm form = new WWWForm();
		form.AddField ("action", "getPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));

		//return StartCoroutine(WaitForRequest(www)).ToString();

		return result;//www.text;
		//return www.text;
		
	}

	public string getOperationsPerformance(string playerName){
		
		string url = "http://localhost:8888/dbFunctions.php";
		WWWForm form = new WWWForm();
		form.AddField ("action", "getOperationsPerformance");
		form.AddField("playerName", playerName);
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return result;
		//return www.text;
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null){
			Debug.Log(www.text);
			result = www.text;
		} else {
			Debug.Log("WWW Error: "+ www.error);
			
		}    
	}  
	void Start(){
		//updateDatabase ("Omar", 10,11,12,13);
		getPerformance ("Omar");
		//print(getTopScores ());
		//getPerformance
	}
}
