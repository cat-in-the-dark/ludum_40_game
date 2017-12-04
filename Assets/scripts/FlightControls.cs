using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControls : MonoBehaviour
{

	public AudioClip runAudio;
	public AudioClip idleAudio;
	public FollowTarget followTarget;
	public ParticleSystem strongFire;
	public ParticleSystem weakFire;
	public float thrust;
	
	private AudioSource source;
	private Rigidbody2D rb;
	private bool running = false;
	private Vector3 initialPosition;
	private Quaternion initialRotation;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
		initialPosition = transform.position;
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		ComputeVelocity();
	}

	// Update phisics world
	void FixedUpdate()
	{
		if (Input.GetButtonDown("Submit"))
		{
			Reset();
		}
		
		if (running)
		{
			rb.AddForce(transform.up * thrust, ForceMode2D.Impulse); // Do we really need Impulse? Maybe Force?
			if (strongFire.isStopped) strongFire.Play();
			if (weakFire.isPlaying) weakFire.Stop();
			playRun();
		}
		else
		{
			if (strongFire.isPlaying) strongFire.Stop();
			if (weakFire.isStopped) weakFire.Play();
			playIdle();
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

	private void playRun()
	{
		if (!source.isPlaying)
		{
			source.Play();
		}
		if (source.clip != runAudio)
		{
			source.clip = runAudio;
		}
	}

	private void playIdle()
	{
		if (!source.isPlaying)
		{
			source.Play();
		}
		if (source.clip != idleAudio)
		{
			source.clip = idleAudio;
		}
	}

	private void Reset()
	{
		transform.position = initialPosition;
		transform.rotation = initialRotation;
		running = false;
		rb.velocity = Vector2.zero;
		followTarget.Reset();
	}
}
