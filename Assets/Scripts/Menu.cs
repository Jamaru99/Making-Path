using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using TMPro;

public class Menu : MonoBehaviour {

	MeshRenderer mr;
	byte lvl;

	void Start(){
		TextMeshPro txtLives = GameObject.Find("txt_lives").GetComponent<TextMeshPro>();
		TextMeshPro txtCoins = GameObject.Find("txt_coins").GetComponent<TextMeshPro>();
		
		mr = GetComponent<MeshRenderer> ();
		if(PlayerPrefs.HasKey("totalCoins")) {
            Coin.totalCoins = PlayerPrefs.GetInt("totalCoins");
        }
		if (PlayerPrefs.HasKey ("lives"))
			Cego.lives = (sbyte) PlayerPrefs.GetInt ("lives");
		else
			Cego.lives = 25;
		txtLives.text = "X" + Cego.lives;
		txtCoins.text = Coin.totalCoins + "/30";
		try {
			lvl = byte.Parse (gameObject.name);
		} catch{}  //a variável lvl guarda o numero do nivel da respectiva esfera no menu
		if (PlayerPrefs.HasKey ("level")) 
			Cego.level = (byte)PlayerPrefs.GetInt ("level");
		else 
			Cego.level = 1;
		if(Cego.level >= lvl)
			mr.material.SetColor ("_Color", Color.black); 
		
	}

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		transform.localScale /= 0.9f;
		if(Cego.level >= lvl && Cego.lives > 0)
			SceneManager.LoadScene (gameObject.name);
		Ads.banner.Hide ();
	}

}
