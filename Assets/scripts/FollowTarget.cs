using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform projectile;
	private Camera camera;
	public float maxCameraSizeMultiplier = 4;
	public float padding = 1.5f;
	
	private float defaultCameraSize;
	private float maxCameraSize;

	private void Start()
	{
		camera = GetComponent<Camera>();
		defaultCameraSize = camera.orthographicSize;
		maxCameraSize = defaultCameraSize * maxCameraSizeMultiplier;
	}

	// Update is called once per frame
	void Update ()
	{	
		FitY();
		FollowX();
	}

	private void FollowX()
	{
		Vector3 newPosition = transform.position;
		newPosition.x = projectile.position.x;
		// some checks whether we move out of the screen
		transform.position = newPosition;
	}

	private void FitY()
	{	
		if (projectile.position.y * padding <= defaultCameraSize)
		{
			camera.orthographicSize = defaultCameraSize;
		}
		else if (projectile.position.y <= maxCameraSize)
		{
			camera.orthographicSize = projectile.position.y * padding;
		}
		else
		{
			Vector3 newPosition = transform.position;
			newPosition.y = projectile.position.y - maxCameraSize;
			transform.position = newPosition;
		}
	}
}
