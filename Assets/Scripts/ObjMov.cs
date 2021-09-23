using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMov : MonoBehaviour {

	GameObject mainCamera;
	BoxCollider[] bc; 
	Camera cam;
	Vector3 mousePos;
	float yi;
	public float delta;
	float yf;
	public float speed;
	bool mouseDown = false;
	bool touched = false;

	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cam = mainCamera.GetComponent<Camera> ();
		bc = GetComponents<BoxCollider> ();
		yi = transform.position.y;
		yf = delta + yi;
	}

	void Update () {
		if (mouseDown == false && Pause.isPaused == false) {
			if (transform.position.y > yf || transform.position.y < yi) speed = -speed;
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed);
		}
	}

	void OnMouseDown(){
		mouseDown = true;
		bc[0].enabled = false;
		bc[1].enabled = false;
		GetComponent<MeshRenderer>().material.color = new Vector4(1,1,0.7f);
	}

	void OnMouseDrag(){
		if (!Pause.isPaused) {
			mousePos = cam.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
			mousePos.z = 0;
			transform.position = mousePos;
		}
	}

	void OnMouseUp(){
		if (touched) {
			Destroy(gameObject);
		}
		mouseDown = false;
		bc[0].enabled = true;
		bc[1].enabled = true;
		yi = transform.position.y;
		yf = delta + yi;
		GetComponent<MeshRenderer>().material.color = new Vector4(1,1,0);
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Cego") {
			touched = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Cego") {
			Destroy (gameObject);
		}
	}
}
