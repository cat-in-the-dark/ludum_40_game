using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform projectile;
	private Camera camera;
	public float maxCameraSizeMultiplier;
	public float padding;
	
	private float defaultCameraSize;
	private float maxCameraSize;
	private Vector3 defaultPosition;
	private float initProjectileY;

	private void Start()
	{
		camera = GetComponent<Camera>();
		defaultCameraSize = camera.orthographicSize;
		maxCameraSize = defaultCameraSize * maxCameraSizeMultiplier;
		defaultPosition = transform.position;
		initProjectileY = projectile.transform.position.y;
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
		var y = projectile.position.y - initProjectileY - transform.position.y - padding;
		if (y <= defaultCameraSize)
		{
			camera.orthographicSize = defaultCameraSize;
		}
		else if (y <= maxCameraSize)
		{
			camera.orthographicSize = (projectile.position.y - initProjectileY) * maxCameraSizeMultiplier;
		}
		else
		{
			// Do Nothing!
		}
	}

	public void Reset()
	{
		camera.orthographicSize = defaultCameraSize;
		transform.position = defaultPosition;
	}
}
