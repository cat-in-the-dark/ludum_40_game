﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform projectile;
	private Camera camera;
	private float defaultCameraSize;
	private float maxCameraSize;

	private void Start()
	{
		camera = GetComponent<Camera>();
		defaultCameraSize = camera.orthographicSize;
		maxCameraSize = defaultCameraSize * 4;
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
		if (projectile.position.y <= defaultCameraSize)
		{
			camera.orthographicSize = defaultCameraSize;
		}
		else if (projectile.position.y <= maxCameraSize)
		{
			camera.orthographicSize = projectile.position.y * 1.2f;
		}
		else
		{
			Vector3 newPosition = transform.position;
			newPosition.y = projectile.position.y - maxCameraSize;
			transform.position = newPosition;
		}
	}
}
