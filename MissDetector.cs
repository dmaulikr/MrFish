using UnityEngine;
using System.Collections;

public class MissDetector : MonoBehaviour 
{
	GameController gc;
	bool missed = false;
	void Start()
	{
		GameObject controllerObject = GameObject.FindWithTag ("GameController");
		gc = controllerObject.GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !missed) 
		{
			gc.SubScore();
			gc.AddMiss ();
			GetComponent<AudioSource>().Play();
			Transform ring = transform.parent;
			RingController rc = ring.GetComponent<RingController>();

			missed = true;
			rc.gotten = true;
		}
	}
}
