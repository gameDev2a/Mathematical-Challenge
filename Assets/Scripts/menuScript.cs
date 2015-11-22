using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using UnityEngine.Events;

public class menuScript : MonoBehaviour
{
    public Button startGame;
    public Button exitGame;
    public GetInput inputName1;
    public GetInput inputName2;
    public MultiplayerGame mode;
    public GameObject pop_up_message;
    public GameObject mulitplayerToggle;
	public static bool isWindows;
	/// <summary>
	/// Awake this instance to chack on which platform is game and display the multiplayer toggle if windows
	/// </summary>
    void Awake(){
  		if (Application.platform == RuntimePlatform.WindowsEditor) {
			isWindows = true;
			mulitplayerToggle.SetActive(true);
			print ("windows editor");
  		} else if (Application.platform == RuntimePlatform.Android) {
			isWindows = false;
			mulitplayerToggle.SetActive(false);
			print ("Android");

  		} else {
  			print ("Other");
  		}
  	}
  /// <summary>
  /// MENs the u_ ACTIO n_ go to page.
  /// </summary>
  /// <param name="sceneName">Scene name.</param>
    public void MENU_ACTION_GoToPage(string sceneName)
    {
        if (mode.getGameMode())//if multiplayer is true
        {
            //check if both fields are not empty
            print("Multiplayer mode");
            if (string.IsNullOrEmpty(inputName1.getNickName1()) || string.IsNullOrEmpty(inputName2.getNickName2()))
            {
                print("You haven't type your nicknames 1:" + inputName1.getNickName1()+" 2:"+ inputName2.getNickName2());
				pop_up_message.SetActive(true);
            }
            else
            {
				sceneName = "SceneMult";
                Application.LoadLevel(sceneName);
				pop_up_message.SetActive(false);
            }/**/
        }
        else
        {
            print("Single mode");
            if (string.IsNullOrEmpty(inputName1.getNickName1()))
            { 
                print("You haven't type your nickname "+inputName1.getNickName1());
				pop_up_message.SetActive(true);
            }
            else
            {
                Application.LoadLevel(sceneName);
				pop_up_message.SetActive(false);
                print("NickName: " + inputName1.getNickName1());
            }/**/
        }
        
        
    }
/// <summary>
/// Exits the game.
/// </summary>
    public void ExitGame()
    {
        Application.Quit();
        print("Game Exit");
    }
    
}