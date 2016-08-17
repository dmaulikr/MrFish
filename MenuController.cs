using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	public GUIText titleText;
	public GUIText startText;
	public GameObject jellyfish1;
	public GameObject jellyfish2;
	public float moveSpeed;
	public int frameLimit;
	int frameCount = 0;
	bool stop = false;
	// Use this for initialization
	void Start () 
	{
		titleText.text = "Mr. Fish";
		startText.text = "Tap to Start";
		//howToPlay = "Touch the screen to swim up.\nLet go to swim down.\nSwim through the rings for points.\n";
		//howToPlay += "Avoid being stung by a jellyfish.\nDon't swim out of bounds.\nTap to Start";
	}
	
	// Update is called once per frame
	void Update ()
	{
		frameCount++;
		jellyfish1.transform.Translate (0.0f, moveSpeed * Time.deltaTime, 0.0f);
		jellyfish2.transform.Translate (0.0f, -moveSpeed * Time.deltaTime, 0.0f);

		if (frameCount == frameLimit) 
		{
			moveSpeed *= -1;
			frameCount = 0;
			// used to set the moving components to alternate correctly
			if (stop == false) 
			{
				frameCounter *= 2;
			}
			stop = true;
		}

		if (Input.GetButtonDown ("Fire1") || Input.touchCount > 0)
		{
			Application.LoadLevel ("HowToPlay");
		}
	}


}
