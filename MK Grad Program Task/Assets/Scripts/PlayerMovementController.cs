using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour
{

	public float speed = 5.0f;
	public float gravity = 10.0f;

	CharacterController controller;
	Vector3 moveDirection = Vector3.zero;

	// Initialise the character controller
	void Start()
    {
		controller = GetComponent<CharacterController>();
    }

    // Movement update
    void Update()
    {
		// Get the current input from the movement joystick
		Vector2 movementInput = new Vector2(CrossPlatformInputManager.GetAxis("HorizontalMovement"), CrossPlatformInputManager.GetAxis("VerticalMovement"));

		// Simple character controller controls
		if (controller.isGrounded)// Only apply new movement when the character is on the ground
		{
			moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
			moveDirection = moveDirection * speed;
		}
		moveDirection.y -= gravity * Time.deltaTime; // Simple acceleration down

		// Turn tanks body in direction of movement
		if (movementInput.magnitude > 0)
		{
			transform.rotation = Quaternion.LookRotation(new Vector3(movementInput.x, 0 , movementInput.y));
		}

		// Move the character
		controller.Move(moveDirection * Time.deltaTime);
    }
}
