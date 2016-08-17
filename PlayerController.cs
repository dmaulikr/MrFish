using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float yMin, yMax;
	Rigidbody2D rigidBody;
	public bool alive;
	public GUIText deathText;
	public GameObject deathMenu;
	public bool shownMenu = false;
	public bool restart = false;

	// Use this for initialization
	void Start () 
	{
		alive = true;
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void Die(string death)
	{
		if (alive) 
		{
			if (death == "Jellyfish") {
				Vector3 scale = new Vector3 (2.0f, -2.0f, 1.0f);
				transform.localScale = scale;
				transform.Translate (0.0f, moveSpeed * Time.deltaTime, 0.0f);
				alive = false;	
				deathText.text = "You were stung\nby a jellyfish.";
			} else if (death == "Ring") {
				alive = false;
				deathText.text = "You were disqualified for missing a ring";
			} else if (death == "Bounds") {
				alive = false;
				deathText.text = "You swam out of bounds.\n";
			} else if (death == "Eel") {
				alive = false;
				deathText.text = "You were stung\nby an eel.";
			} else if (death == "Asteroid") {
				alive = false;
				deathText.text = "You were struck\nby an asteroid.";
			} else if (death == "Barracuda") 
			{
				alive = false;
				deathText.text = "You were bit by\na barracuda.";
			}
			deathText.text += " Tap to restart.";

			deathText.text += "\nScore: " + GameObject.FindWithTag ("GameController").GetComponent<GameController> ().score;
			deathText.text += " Missed: " + GameObject.FindWithTag ("GameController").GetComponent<GameController> ().missed; 		
		}
	}

	void Update()
	{
		if (alive) {
			if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0) {   // Input.GetKey(KeyCode.Space)
				transform.Translate (0.0f, moveSpeed * Time.deltaTime, 0.0f);
				//rigidBody.velocity = new Vector3(0.0f, moveSpeed, 0.0f);
			} else {
				transform.Translate (0.0f, -moveSpeed * Time.deltaTime, 0.0f);
				//rigidBody.AddForce(new Vector2(0.0f, -moveSpeed));
				//rigidBody.velocity = new Vector3(0.0f, -moveSpeed, 0.0f);
			}

			if (transform.position.y > yMax || transform.position.y < yMin) {
				Die ("Bounds");
			}

			rigidBody.position = new Vector3
			(
					0.0f,
					Mathf.Clamp (rigidBody.position.y, yMin, yMax),
					0.0f
			);
		} 
		else 
		{
			
			if (!shownMenu)
			{
				StartCoroutine(DeathMenu ());
			}
			if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && restart)
			{
				print ("Restarting");
				int control = Random.Range (1, 23);

				if (control >= 1 && control <= 10) {
					Application.LoadLevel ("Scene1");
				} else if (control >= 11 && control <= 15) {
					Application.LoadLevel ("Scene2");
				} else if (control >= 20 && control <= 22) {
					Application.LoadLevel ("Scene3");
				} else if (control >= 16 && control <= 19) {
					Application.LoadLevel ("Scene4");
				} else 
				{
					Application.LoadLevel ("Scene1");
				}
			}
		}
	}


	IEnumerator DeathMenu()
	{
		Vector3 spawnPosition = new Vector3(4.17f, 0.0f, -5.0f);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (deathMenu, spawnPosition, spawnRotation);
		shownMenu = true;
		yield return new WaitForSeconds (1);
		restart = true;
	}
}
