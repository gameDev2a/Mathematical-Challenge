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
		ran = 1;

		if (ran == 1) {
			playerObject1.layer = LayerMask.NameToLayer( "Default" );
			playerObject2.layer = LayerMask.NameToLayer( "Default" );
		}else if(ran == 2){
			playerObject1.layer = LayerMask.NameToLayer( "Player1" );
			playerObject2.layer = LayerMask.NameToLayer( "Player2" );
		}
	}

	public void setMode(int value){ran = value;}
	public int getMode(){return ran;}
	
	// Update is called once per frame
	void Update () {
	
	}
}
