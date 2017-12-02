using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControls : MonoBehaviour
{

	public float thrust;
	private Rigidbody2D rb;
	private bool running = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		ComputeVelocity();
	}

	// Update phisics world
	void FixedUpdate()
	{
		if (running)
		{
			rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);  // Do we really need Impulse? Maybe Force?
		}
	}

	private void ComputeVelocity()
	{
		if (Input.GetButton("Jump"))
		{
			running = true;
		}
		else
		{
			running = false;
		}
	}
}
