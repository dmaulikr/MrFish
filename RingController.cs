using UnityEngine;
using System.Collections;

public class RingController : MonoBehaviour 
{
	public float moveSpeed;
	private GameController gc;
	private PlayerController pc;
	public bool gotten;
	void Start()
	{
		gotten = false;
		GameObject gameObject = GameObject.FindWithTag ("GameController");
		gc = gameObject.GetComponent<GameController> ();
		GameObject playerObject = GameObject.FindWithTag ("Player");
		pc = playerObject.GetComponent<PlayerController> ();
	}
	
	void Update () 
	{
		if (pc.alive) 
		{
			transform.Translate (-moveSpeed, 0.0f, 0.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && gotten == false) 
		{
			GetComponent<AudioSource>().Play();
			gc.AddScore();
			gotten = true;

			GameObject[] children = new GameObject[2];
			int i = 0;

			foreach (Transform child in transform)
			{
				if (child.tag == "MissBox")
				{
					children[i] = child.gameObject;
					i++;
				}
			}
			for (i = 0; i < 2; i++)
			{
				Destroy(children[i]);
			}
		}
	}
}
