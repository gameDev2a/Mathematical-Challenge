using UnityEngine;
using System.Collections;

public class MultiMode : MonoBehaviour {
	
	public GameObject playerObject1;
	public GameObject playerObject2;
	int ran;

	// Use this for initialization
	void Start () {

		Random rnd = new Random();
		//ran = rnd.Next(1, 3);
		ran = 2;

		if (ran == 1) {
			//playerObject1.layer = 0;

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

		}else if(ran == 2){

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

	void SetLayerRecursively(GameObject obj, int newLayer)
	{
		
		obj.layer = newLayer;
		

	}

	public void setMode(int value){ran = value;}
	public int getMode(){return ran;}
	
	// Update is called once per frame
	void Update () {
	
	}
}
