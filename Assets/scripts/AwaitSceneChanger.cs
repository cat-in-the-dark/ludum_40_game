using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AwaitSceneChanger : MonoBehaviour {
	public float time;
	public int nextScreen = 0;

	// Use this for initialization
	IEnumerator Start () {
		if (nextScreen == 0)
		{
			nextScreen = SceneManager.GetActiveScene().buildIndex + 1;
		}
		Debug.Log(string.Format("Next screen is {0}", nextScreen));
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(nextScreen);
	}
}