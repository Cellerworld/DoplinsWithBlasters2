using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}


	public void LoadScene(string pSceneName)
	{
		SceneManager.LoadScene (pSceneName);;
	}

	public void EndGame()
	{
		//Are you sure popup
		Application.Quit();
	}
}
