using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

	public int nextScreen;
	public int initScene = 0;
	
	// Use this for initialization
	void Start () {
		
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
