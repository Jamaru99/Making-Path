using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    TextMeshPro tm;
    Camera cam;
    Color color1 = Color.white;
    Color color2 = Color.black;
    float duration = 3.0f;
    void Start()
    {
        tm = GetComponent<TextMeshPro>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update() {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
        tm.color = Color.Lerp(color2, color1, t);
    }
}
