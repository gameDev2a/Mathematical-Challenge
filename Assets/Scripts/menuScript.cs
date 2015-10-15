using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using UnityEngine.Events;

public class menuScript : MonoBehaviour
{
 
    public Button startGame;
    public Button exitGame;
 
    public GetInput inputNames; 
    public MultiplayerGame mode;
  

    public void MENU_ACTION_GoToPage(string sceneName)
    {
        if (mode.getGameMode())
        {
            //check if both fields are not empty
            print("Multiplayer mode names: " + inputNames.getNickName1() + " second nickname: " + inputNames.getNickName2());
        }
        else
        {
            if (string.IsNullOrEmpty(inputNames.getNickName1()))
            { 
                print("You haven't type your nickname "+inputNames.getNickName2());
            }
            else
            {
                Application.LoadLevel(sceneName);
                print("NickName: " + inputNames.getNickName1());
            }
        }
        
        
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Game Exit");
    }

}