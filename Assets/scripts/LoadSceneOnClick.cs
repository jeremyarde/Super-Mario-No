using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) {
		if (sceneIndex == -1) {
			Application.Quit();
		} 
		else {
			SceneManager.LoadScene(sceneIndex);
		}
	}
}
