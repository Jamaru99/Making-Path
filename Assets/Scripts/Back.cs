using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		Ads.banner.Destroy ();
		GameObject music = GameObject.Find("Music");
		Destroy(music);
		SceneManager.LoadScene (0);
	}
}
