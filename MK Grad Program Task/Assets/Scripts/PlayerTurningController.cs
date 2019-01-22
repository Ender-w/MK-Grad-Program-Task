using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerTurningController : MonoBehaviour
{


    void Update()
    {
		// Turn the player to face the input direction
		Vector3 lookAt = new Vector3(CrossPlatformInputManager.GetAxis("HorizontalTurning"), 0, CrossPlatformInputManager.GetAxis("VerticalTurning"));
		if (lookAt.magnitude > 0)//If there is an input on the right joystick turn the turret in the direction of input
		{
			transform.rotation = Quaternion.LookRotation(lookAt);
		}
		else // If there is no input on the turn joystick have the turret face the direction of movement
		{
			Vector3 movementDirection = new Vector3(CrossPlatformInputManager.GetAxis("HorizontalMovement"), 0, CrossPlatformInputManager.GetAxis("VerticalMovement"));
			if(movementDirection.magnitude > 0)//Only turn turret when there is a movement input
			{
				transform.rotation = Quaternion.LookRotation(movementDirection);
			}
		}

	}
}
