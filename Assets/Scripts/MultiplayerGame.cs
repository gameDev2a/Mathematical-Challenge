using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiplayerGame : MonoBehaviour {

    private bool multi = false;
	// Use this for initialization
	
    public void setGameMode(Toggle multiplayer)
    {
        if (multiplayer.isOn)
        {
            multi = true;
            print("Multiplayer");
        }
        else
        {
            multi = false;
            print("Single player");
        }
    }
   
    public bool getGameMode()
    {
        return multi;
    }
}
