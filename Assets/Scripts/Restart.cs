using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
        Ads.banner.Hide ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
