using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour 
{

	public float moveSpeed;

	void Update()
	{
		transform.Translate (-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
	}
}
