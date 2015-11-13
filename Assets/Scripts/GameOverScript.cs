using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Button reply;
    public Button exitGame;
    
    public void  PlayAgain(string sceneName) {
        Application.LoadLevel(sceneName);
    }
	

	public void ExitGame () {
        Application.Quit();
        print("Game Exit");
    }
}
