using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public GameObject followObject; // The character object for the camera to follow
	Vector3 relativePosition; // The intended relative position of the camera from the character - Set on start

    void Start()
    {
		relativePosition = transform.position;
    }

    void Update()
    {
		transform.position = followObject.transform.position + relativePosition;
    }
}
