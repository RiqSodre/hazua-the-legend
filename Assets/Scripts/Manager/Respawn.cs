using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	void Awake () {
	}

    void OnCollisionEnter2D(Collision2D colidir)
    {
        if (colidir.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("Game");
        }
    }

    void Update () {
		
	}
}
