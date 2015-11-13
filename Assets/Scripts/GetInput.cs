using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetInput : MonoBehaviour {

    private InputField input1;
    private InputField input2;
    private string nickname1;
    private string nickname2;
	
    //settter and getter
	public void setNickName1 (InputField name) {
        nickname1 = name.text;
        print("new nickname1: " + name.text);
	}
    public string getNickName1()
    {
        return nickname1;
    }
    public void setNickName2(InputField name)
    {
        nickname2 = name.text;
        print("new nickname2: " + name.text);
    }
    public string getNickName2()
    {
        return nickname2;
    }
}
