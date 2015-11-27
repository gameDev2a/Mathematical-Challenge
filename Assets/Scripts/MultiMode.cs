using UnityEngine;
using System.Collections;

public class MultiMode : MonoBehaviour {
	
	public GameObject playerObject1;
	public GameObject playerObject2;
	public GameObject playerSingle;
	public int diffNum = 80, mode;
	private string multiString;
	private bool multi;

	// Use this for initialization
	void Start () {

		multiString = PlayerPrefs.GetString ("MultiBool");
		
		if (multiString.Equals ("True")) {
			multi = true;
		} else {
			multi = false;
		}
		
		if (multi == true) {
			playerObject1.SetActive(true);
			playerObject2.SetActive(true);
			playerSingle.SetActive(false);
		}else {
			playerObject1.SetActive(false);
			playerObject2.SetActive(false);
			playerSingle.SetActive(true);
		}

		if (diffNum <= 40 && multi == true) {

			mode = 1;
			Save (mode);

			foreach (Transform child in playerObject1.transform)
			{
				if (null == child)
				{
					continue;
				}
				SetLayerRecursively(child.gameObject, 0);
			}

			foreach (Transform child in playerObject2.transform)
			{
				if (null == child)
				{
					continue;
				}
				SetLayerRecursively(child.gameObject, 0);
			}

		}else if(diffNum > 40 && multi == true){

			mode = 2;
			Save (mode);

			foreach (Transform child in playerObject1.transform)
			{
				if (null == child)
				{
					continue;
				}
				SetLayerRecursively(child.gameObject, 8);
			}

			foreach (Transform child in playerObject2.transform)
			{
				if (null == child)
				{
					continue;
				}
				SetLayerRecursively(child.gameObject, 9);
			}
		}
	}

	void difference(){
		/*
		 * if(num1 >= num2){
		 * int diffNum = num1 - num2;
		 * }else {
		 * diffNum = num2 - num1;
		 * }
		 * 
		 * */
	}

	void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
	}

	public static void Save(int multiMode){
		PlayerPrefs.SetInt ("MultiMode",multiMode);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
