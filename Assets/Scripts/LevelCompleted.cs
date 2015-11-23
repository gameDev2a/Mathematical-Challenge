using UnityEngine;
using System.Collections;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script

public class LevelCompleted : MonoBehaviour {

	public Button PlayAgain;
	public Button NextLevel;
	public GameObject levelCompletedCanvas;

	public void PlayAgainScene(){
		int currentLevel = Application.loadedLevel;
		Application.LoadLevel(currentLevel);
		levelCompletedCanvas.SetActive (false);
	}
	public void GoToScene(){
		int currentLevel = Application.loadedLevel;
		if (currentLevel < 4) {
			Application.LoadLevel (currentLevel + 1);
		} else {
			Application.LoadLevel (4);
		}

	}
}