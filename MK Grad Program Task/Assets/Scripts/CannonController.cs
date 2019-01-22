using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CannonController : MonoBehaviour
{

	public GameObject shellSpawnLocation;
	public GameObject shellPrefab; // Cannon Shell to spawn

	public float shotCooldown = 0.8f; // Time in seconds until the cannon will fire again
	private float shotTime = 0; // Time since last cannon shot fired

	// Run in LateUpdate to ensure that the turret has rotated before the shot is spawned
    void LateUpdate()
    {
        if(shotTime < shotCooldown)//Only allow the cannon to fire after a short cooldown
		{
			shotTime += Time.deltaTime;
		}
		else
		{
			Vector3 lookInput = new Vector3(CrossPlatformInputManager.GetAxis("HorizontalTurning"), 0, CrossPlatformInputManager.GetAxis("VerticalTurning"));
			if (lookInput.magnitude > 0.2)//Only fire the cannon if there is an input on the right stick
			{
				GameObject.Instantiate(shellPrefab, shellSpawnLocation.transform.position, shellSpawnLocation.transform.rotation);
				shotTime = 0.0f;
			}
		}
    }
}
