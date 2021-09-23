using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int totalCoins = 0;

    void Start() {
        if(PlayerPrefs.HasKey(gameObject.name)) {
            Destroy(gameObject);
        }
    }

    void Update() {
        GameObject g = GameObject.Find("Cego");
        float dist = Vector3.Distance(g.transform.position, transform.position);
        if(dist < 1.3f) {
            Destroy(gameObject);
            totalCoins += 1;
            if(totalCoins == 30) {
                GooglePlayGame.ReportAchievementProgress("CgkI_4jvyJYYEAIQAA", 100.0f, success => {});
            }
            PlayerPrefs.SetInt(gameObject.name, 1);
            PlayerPrefs.SetInt("totalCoins", totalCoins);
        }
    }
}
