using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnHit : MonoBehaviour {

    public int sceneToLoad;

    void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.tag == "Player") {
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Loading next level");
        }
	}
}
