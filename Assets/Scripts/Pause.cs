using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public Sprite play;
	public Sprite pause;
	public GameObject menu;
	public GameObject restart;
	public static bool isPaused;

	void Start(){
		isPaused = false;
	}

	void OnMouseDown(){
		isPaused = !isPaused;
		if (isPaused) {
			GetComponent<SpriteRenderer> ().sprite = play;
			menu.SetActive (true);
			restart.SetActive (true);
			Ads.banner.Show ();
		} else {
			GetComponent<SpriteRenderer> ().sprite = pause;
			menu.SetActive (false);
			restart.SetActive (false);
			Ads.banner.Hide ();
		}

	}
}
