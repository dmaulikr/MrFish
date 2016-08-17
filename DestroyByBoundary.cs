using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void Update()
	{
		if (transform.position.x <= -4) 
		{
			Destroy(this.gameObject);
		}
	}
}
