using UnityEngine;
using System.Collections;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script

public class LevelCompleted : MonoBehaviour {

	public LearnerModule lm; 
	public Button PlayAgain;
	public Button NextLevel;
	public GameObject levelCompletedCanvas;
	public Text nickLabel2;
	public Text nickname1;
	public Text score1;
	public Text score2;
	private int Player1Score;
	private int Player2Score;
	/// <summary>
	/// Start this instance and set menu score with nickname and score

	/// <summary>
	/// Start this instance and set nicknames.
	/// </summary>
	void Start(){
		nickname1.text = PlayerPrefs.GetString ("nick1");
		if (PlayerPrefs.GetString ("MultiBool").Equals ("True")) {  
			nickLabel2.text = PlayerPrefs.GetString ("nick2");

		}
	}
	/// <summary>
	/// Play the scene again.
	/// Plaies the again scene.
	/// </summary>
	public void PlayAgainScene(){
		int currentLevel = Application.loadedLevel;
		Application.LoadLevel(currentLevel);
		levelCompletedCanvas.SetActive (false);
	}
	/// <summary>
	/// Gos to scene.
	/// </summary>
	public void GoToScene(){
		int currentLevel = Application.loadedLevel;
		if (currentLevel < 4) {
			Application.LoadLevel (currentLevel + 1);
		} else {
			Application.LoadLevel (4);
		}
	}

	void Update(){
		score1.text = lm.GetP1Score().ToString();
		//score2.text = score2.ToString();
	}

}