using UnityEngine;
using System.Collections;

public class JellyfishController : MonoBehaviour 
{
	public float moveSpeed;
	bool moveUp;
	int moveCounter;
	public float bounceSpeed;
	public int framesToMove;

	// Use this for initialization
	void Start () 
	{
		moveUp = true;
		moveCounter = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
		if (moveUp) 
		{
			transform.Translate (0.0f, bounceSpeed * Time.deltaTime, 0.0f);
			moveCounter++;
			if (moveCounter == framesToMove)
			{
				moveCounter = 0;
				moveUp = false;
			}
		}
		else
		{
			transform.Translate (0.0f, -bounceSpeed * Time.deltaTime, 0.0f);
			moveCounter++;
			if (moveCounter == framesToMove)
			{
				moveCounter = 0;
				moveUp = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			GetComponent<AudioSource>().Play();
			GameObject player = GameObject.FindWithTag("Player");
			PlayerController pc = player.GetComponent<PlayerController>();
			pc.Die("Jellyfish");
		}
	}
}
