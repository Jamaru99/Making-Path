using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public Transform cego;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Clamp(cego.position.x + 2, minX, maxX), Mathf.Clamp(cego.position.y, minY, maxY), -10);
	}
}
