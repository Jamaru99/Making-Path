using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cego : MonoBehaviour {

	private float speed = 0.05f;
	public static byte level;
	public static sbyte lives = 25;
	sbyte turn = 1;
	Scene scene;
	public TextMeshPro lifeCounter;
	Animator animator;
	Rigidbody rb;
	bool lifeLost;

	void Start () {
		scene = SceneManager.GetActiveScene();
		lifeCounter.text = "X" + lives;
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
		lifeLost = false;
	}

	void Update () {
		if (!Pause.isPaused) {
			rb.isKinematic = false;
			transform.position = new Vector2 (transform.position.x + speed * turn, transform.position.y);
		} else {
			rb.isKinematic = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Object") {
			if(scene.name != "Special") {
				if(lifeLost == false) lives -= 1;
				lifeLost = true;
				lifeCounter.text = "X" + lives;
				PlayerPrefs.SetInt ("lives", lives);
			}
			if (lives == 0)
				SceneManager.LoadScene (0);
			else
				SceneManager.LoadScene (scene.name);
		}
		if (other.name == "Portal") {
			
			if (scene.name == "Special") {
				SceneManager.LoadScene (8);
			} else {
				if (scene.buildIndex == level) {
					level += 1;
					PlayerPrefs.SetInt ("level", level);
				}
				SceneManager.LoadScene (scene.buildIndex + 1);
			}
		}
		if (other.name == "PortalSpecial") {
			GooglePlayGame.ReportAchievementProgress("CgkI_4jvyJYYEAIQAw", 100.0f, success => {});
			if (scene.buildIndex == level) {
				level += 1;
				PlayerPrefs.SetInt ("level", level);
			}
			SceneManager.LoadScene ("Special");
		}

		if (other.name == "Edge") {
			if(turn == 1){
				turn = -1;
				transform.rotation = new Quaternion (0, 180, 0, 0);
			}
			else {
				turn = 1;
				transform.rotation = new Quaternion (0, 0, 0, 0);
			}
		}

		if(other.name == "Espinhos") {
			GooglePlayGame.ReportAchievementProgress("CgkI_4jvyJYYEAIQAg", 100.0f, success => {});
			SceneManager.LoadScene("GameOver");
		}
		
		if(other.tag == "ObjectRigid") speed = 0;
	}

}
