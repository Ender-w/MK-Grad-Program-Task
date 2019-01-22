using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

	public float speed = 10;
	public float despawnTime = 20.0f;

	private float timeAlive;

    void Update()
    {
		// Move the cannon shell forward simply
		// Using a rigidbody with forces would make for a more realistic shell effect
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		timeAlive += Time.deltaTime;
		if (timeAlive > despawnTime)// Destroy the object after a period of time
		{
			Destroy(gameObject);
		}
    }

	void OnCollisionEnter(Collision collision)
	{
		// When the shell hits a wall destroy itself.
		// Here would be a good place to spawn an explosion prefab.
		Destroy(gameObject);
	}

}
