using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

    public Texture2D health1;
    public Texture2D health2;
    public Texture2D health3;

	//!!!Player 1 uses P2LabelY in Single Player
    private int P2labelY = (Screen.width * 80) / 100;
    private int P1labelY = (Screen.width * 5) / 100;

	private int labelX = ((Screen.height * 5) / 100) + 50;
    private int labelWidth = 200;
    private int labelHeight = 50;

    public int startingHealth = 3;
    public int currentHealth1;        
	public int currentHealth2;

    bool isDead;

	string scene;

    void Start()
    {
        // Set the initial health of the player.
        currentHealth1 = startingHealth;
		currentHealth2 = startingHealth;

		scene = Application.loadedLevelName;

		if (scene.Equals ("SceneMult")) {
			labelX = ((Screen.height * 5) / 100) + 25;
			P2labelY = (Screen.width * 85) / 100;
		}

    }


    private void OnGUI()
    {
        DisplayHealthBar1(currentHealth1);

		if(scene.Equals("SceneMult")){
			DisplayHealthBar2(currentHealth2);
		}

        if (currentHealth1 <= 0 || currentHealth2 <= 0)
        {
            int GameOver = 0;
            //int Game_Over_Level = 2;
            Application.LoadLevel(GameOver);
        }
    }


    public void WrongAnswer()
    {

        // Reduce the current health.
        currentHealth1 --;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth1 <= 0 && !isDead)
        {
            // ... it should die.
            Death();

        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
    }

    private void DisplayHealthBar1(int i)
    {
		if (!scene.Equals ("SceneMult")) {
			GUI.Label (new Rect (P2labelY, labelX, labelWidth, labelHeight), getImage1 (i));
		} else {
			GUI.Label (new Rect (P1labelY, labelX, labelWidth, labelHeight), getImage1 (i));
		}
    }

	private void DisplayHealthBar2(int i)
	{
		GUI.Label(new Rect(P2labelY, labelX, labelWidth, labelHeight), getImage2(i));
	}

    private Texture2D getImage1(int i)
    {
        if (currentHealth1 == 3) { return health3; }
        else if (currentHealth1 == 2) { return health2; }
        else if (currentHealth1 == 1) { return health1; }
        else { return null; }
    }

	private Texture2D getImage2(int i)
	{
		if (currentHealth2 == 3) { return health3; }
		else if (currentHealth2 == 2) { return health2; }
		else if (currentHealth2 == 1) { return health1; }
		else { return null; }
	}

}