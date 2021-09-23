using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour {

	GameObject mainCamera;
	public GameObject surface;
	BoxCollider bc, bcs; 
	Camera cam;
	MeshRenderer mr;
	Vector3 mousePos;

	void Start(){
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cam = mainCamera.GetComponent<Camera> ();
		bc = GetComponent<BoxCollider> ();
		mr = GetComponent<MeshRenderer>();
		if(gameObject.tag == "Object")bcs = surface.GetComponent<BoxCollider> ();
	}

	void OnMouseDown(){
		bc.enabled = false;
		if(gameObject.tag == "Object") {
			bcs.enabled = false;
			mr.material.color = new Vector4(0.26f, 0.3f, 0.95f);
		}
	}

	void OnMouseDrag(){
		if (!Pause.isPaused) {
			mousePos = cam.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
			mousePos.z = 0;
			transform.position = mousePos;
		}
	}

	void OnMouseUp(){
		bc.enabled = true;
		if(gameObject.tag == "Object") {
			bcs.enabled = true;
			mr.material.color = new Vector4(0, 0, 1);
		}
	}
}
