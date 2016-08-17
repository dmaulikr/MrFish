



using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject ring;
	public GameObject enemy;
	public GameObject whale;
	public int score;
	public int missed;
	public GUIText scoreText;
	public GUIText missedText;
	public GUIText highScoreText;
	public GUIText deathText;
	float spawnWait;
	public float jellyfishWait;
	public float whaleWait;
	private PlayerController pc;

	void Start () 
	{
		score = 0;
		missed = 0;
		GameObject playerObject = GameObject.FindWithTag ("Player");
		pc = playerObject.GetComponent<PlayerController> ();
		deathText.text = "";
		UpdateScoreText ();
		UpdateHighScoreText ();
		StartCoroutine (SpawnRings ());
		StartCoroutine (SpawnJellyfish());
		StartCoroutine (SpawnBackground ());
	}

	void StoreHighScore(int score)
	{
		int oldHighScore = PlayerPrefs.GetInt ("highscore", 0);
		if (score > oldHighScore)
		{
			PlayerPrefs.SetInt ("highscore", score);
		} 
	}

	void UpdateHighScoreText()
	{
		highScoreText.text = "HighScore: " + PlayerPrefs.GetInt ("highscore", 0);
	}

	void UpdateScoreText()
	{
		scoreText.text = "Score: " + score;
		missedText.text = "Missed: " + missed;
	}

	public void AddMiss()
	{
		missed++;
		UpdateScoreText ();
	}

	public void AddScore()
	{
		score++;
		UpdateScoreText ();
		StoreHighScore (score);
		UpdateHighScoreText ();
	}

	public void SubScore()
	{
		score -= 1;
		UpdateScoreText ();
	}
	
	IEnumerator SpawnRings()
	{
		while (true) 
		{
			float spawnWait = Random.Range(.5f, 3f);
			Vector3 spawnPosition = new Vector3(17f, Random.Range(-2f, 2f), -3);
			Quaternion spawnRotation = Quaternion.identity;
			if (pc.alive)
			{
				Instantiate (ring, spawnPosition, spawnRotation);
			}
			yield return new WaitForSeconds(spawnWait);
		}
	}

	IEnumerator SpawnJellyfish()
	{
		yield return new WaitForSeconds(1);
		while (true) 
		{
			jellyfishWait = Random.Range(1f, 4f);
			Vector3 spawnPosition = new Vector3(17f, Random.Range(-3f, 3f), -2);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(jellyfishWait);
		}
	}

	IEnumerator SpawnBackground()
	{
		yield return new WaitForSeconds (5);
		while (true) 
		{
			whaleWait = Random.Range (30.0f, 50.0f);
			Vector3 spawnPosition = new Vector3(17f, Random.Range(-1.75f, 3.0f), 3.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (whale, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(whaleWait);
		}
	}
}
