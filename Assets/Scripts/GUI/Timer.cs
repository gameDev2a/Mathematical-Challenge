using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public Texture2D time0;
    public Texture2D time1;
    public Texture2D time2;
    public Texture2D time3;
    public Texture2D time4;
    public Texture2D time5;
    public Texture2D time6;
    public Texture2D time7;
    public Texture2D time8;
    public Texture2D time9;
    public Texture2D time10;

    private int P1labelY = (Screen.width * 75) / 100;

    private int labelX = (Screen.height * 5) / 100;
    private int labelWidth = 500;
    private int labelHeight = 50;

    private float timeStart;
    private int timeDur = 360;
    private int timeLeft;

	string multiString;
	bool multi;

    // Use this for initialization
    private void Start () {

		multiString = PlayerPrefs.GetString ("MultiBool");
		
		if (multiString.Equals ("True")) {
			multi = true;
		} else {
			multi = false;
		}
		
		if (multi == true) {
			P1labelY = (Screen.width / 2) - 200;
		}

        ResetTimer(timeDur);
	}

    private void OnGUI()
    {
        DisplayTime(GetTimeLeft());

        if(GetTimeLeft() == 0)
        {
            int GameOver = 2;
            Application.LoadLevel(GameOver);
        }

    }

    private void DisplayTime(int i)
    {
        GUI.Label(new Rect(P1labelY, labelX, labelWidth, labelHeight), DoGetImage(i));
    }

    private Texture2D DoGetImage(int i)
    {
        if (GetPercent(i, 0)) { return time0; }
        else if (GetPercent(i, 10)) { return time1; }
        else if (GetPercent(i, 20)) { return time2; }
        else if (GetPercent(i, 30)) { return time3; }
        else if (GetPercent(i, 40)) { return time4; }
        else if (GetPercent(i, 50)) { return time5; }
        else if (GetPercent(i, 60)) { return time6; }
        else if (GetPercent(i, 70)) { return time7; }
        else if (GetPercent(i, 80)) { return time8; }
        else if (GetPercent(i, 90)) { return time9; }
        else if (GetPercent(i, 100)) { return time10; }
        else { return null; }
    }

    private bool GetPercent(int i, int Percentage)
    {
        int XYZ = (i * 100) / timeDur;
        if (XYZ <= Percentage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /** return total seconds  */
    public int GetTotalSeconds()
    {
        return timeDur;
    }
    /** This method is used to reset the value of the timer in case of level win! */
    public void ResetTimer(int seconds)
    {
        timeStart = Time.time;
        timeDur = seconds;
    }
    /** return remaining seconds */
    public int GetTimeLeft()
    {
        int elapsedSeconds = (int)(Time.time - timeStart);
        int secondsLeft = (timeDur - elapsedSeconds);
        return secondsLeft;
    }
    /** return remaining seconds float value */
    public float GetProportionTimeRemaining()
    {
        float proportionLeft = (float)GetTimeLeft() / (float)GetTotalSeconds();
        return proportionLeft;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
