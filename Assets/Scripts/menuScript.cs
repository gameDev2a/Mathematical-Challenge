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
	public LearnerModule learnerModule;
	public static bool isWindows;

	private string multiString;
	/// <summary>
	/// Awake this instance.
	/// </summary>
    void Awake(){
  		if (Application.platform == RuntimePlatform.WindowsEditor) {
			mulitplayerToggle.SetActive(true);
			isWindows = true;
			print ("windows editor");
  		} else if (Application.platform == RuntimePlatform.Android) {
			isWindows = false;
			mulitplayerToggle.SetActive(false);
			startGame.image.rectTransform.sizeDelta = new Vector2(100,100);
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

			multiString = "True";
			Save (multiString);
            //check if both fields are not empty
            print("Multiplayer mode");
            if (string.IsNullOrEmpty(inputName1.getNickName1()) || string.IsNullOrEmpty(inputName2.getNickName2()))
            {
                print("You haven't type your nicknames 1:" + inputName1.getNickName1()+" 2:"+ inputName2.getNickName2());
				pop_up_message.SetActive(true);
            }
            else
            {

                Application.LoadLevel(sceneName);
				PlayerPrefs.SetString("player1Name",inputName1.getNickName1());
				PlayerPrefs.SetString("player2Name",inputName2.getNickName2());
				PlayerPrefs.Save();
				pop_up_message.SetActive(false);
            }/**/
        }
        else
		{
			multiString = "False";
			Save (multiString);

            print("Single mode");
            if (string.IsNullOrEmpty(inputName1.getNickName1()))
            { 
                print("You haven't type your nickname "+inputName1.getNickName1());

				pop_up_message.SetActive(true);
            }
            else
            {
                Application.LoadLevel(sceneName);
				PlayerPrefs.SetString("player1Name",inputName1.getNickName1());
				PlayerPrefs.Save();
				pop_up_message.SetActive(false);
                print("NickName: " + inputName1.getNickName1());
            }/**/
        }
    }

	public static void Save(string multiString){
		PlayerPrefs.SetString ("MultiBool",multiString);
		print (multiString);
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