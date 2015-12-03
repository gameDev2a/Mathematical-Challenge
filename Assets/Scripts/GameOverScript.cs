using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Button reply;
    public Button exitGame;
	public Text nickLabel2;
	public Text nickname1;
	public Text score1;
	public Text score2;
	public LearnerModule lm;
   
	/// <summary>
	/// /set the name and score
	/// </summary>
	void Start(){
		nickname1.text = PlayerPrefs.GetString ("nick1");
		score1.text = lm.GetP1Score ().ToString();
		if (PlayerPrefs.GetString ("MultiBool").Equals ("True")) {
			nickLabel2.text = PlayerPrefs.GetString ("nick2");
			//score2.text = lm.getP2
		}
	}
	/// <summary>
	/// Play the game again.
	/// </summary>
	/// <param name="sceneName">Scene name.</param>
	public void  PlayAgain(string sceneName) {
        Application.LoadLevel(sceneName);
    }
	
	/// <summary>
	/// Exits the game.
	/// </summary>
	public void ExitGame () {
        Application.Quit();
        print("Game Exit");
    }
}
