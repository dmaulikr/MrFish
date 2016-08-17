using UnityEngine;
using System.Collections;

public class HowToPlayController : MonoBehaviour 
{
	public GUIText howToPlayText;
	int counter = 0;

	// Use this for initialization
	void Start () 
	{
		howToPlayText.text = "Touch the screen to swim up.\nLet go to swim down.\nSwim through the rings for points.\n";
		howToPlayText.text += "Avoid being stung by a jellyfish.\nDon't swim out of bounds.\nTap to Play!";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (counter < 100)
		{
			counter++;
		}
		if ((Input.GetButtonDown ("Fire1") || Input.touchCount > 0) && counter > 10) 
		{
			Application.LoadLevel ("Scene1");
		}
	}
}
