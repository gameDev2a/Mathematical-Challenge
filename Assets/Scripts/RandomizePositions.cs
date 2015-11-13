using UnityEngine;
using System.Collections;

public class RandomizePositions : MonoBehaviour {

	public GameObject Spawns;

	// Use this for initialization
	void Start () {

		Transform[] spawnedObjects = Spawns.GetComponentsInChildren<Transform>();

		foreach (Transform child in spawnedObjects) {
			float Yposition = child.gameObject.transform.position.y;
			Vector3 rndPosition = new Vector3(Random.Range(10,30), Yposition, Random.Range(10,30));

			if (child.name.Equals("Number") || child.name.Equals("Operator")) {
				child.gameObject.transform.position = rndPosition;
			}
		}
	}

}
