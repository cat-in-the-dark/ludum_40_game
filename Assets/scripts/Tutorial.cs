using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
	public int nextScreen;
	
	private int initScene = 1;
	
	// Use this for initialization
	void Start ()
	{
		if (nextScreen == 0)
		{
			nextScreen = Mathf.Clamp(
				SceneManager.GetActiveScene().buildIndex + 1, initScene, SceneManager.sceneCountInBuildSettings - 1);
		}
		Debug.Log(string.Format("Next screen is {0}", nextScreen));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Submit"))
		{
			SceneManager.LoadScene(nextScreen);
			return;
		}
		
		if (Input.GetButtonDown("Cancel"))
		{
			SceneManager.LoadScene(initScene);
			return;
		}
	}
}
