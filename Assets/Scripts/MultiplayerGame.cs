using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class MultiplayerGame : MonoBehaviour {

    /// <summary>
    /// Game object to hold field name for second nickname
    /// </summary>
    public GameObject nicknameField2GO;

    /// <summary>
    /// Boolean to check if the multiplayer mode is on or off
    /// </summary>
    private bool multi = false;
    //public InputField secondNickname;

    /// <summary>
    /// method to set the mode game
    /// </summary>
    /// <param name="multiplayer"></param>
    public void setGameMode(Toggle multiplayer)
    {
        multi = multiplayer.isOn;
        nicknameField2GO.SetActive(multi);
    }
   
    /// <summary>
    /// method to get the mode game
    /// </summary>
    /// <returns></returns>
    public bool getGameMode()
    {
        return multi;
    }
}
