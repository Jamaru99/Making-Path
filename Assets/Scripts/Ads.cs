using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using TMPro;

public class Ads : MonoBehaviour {

	public static BannerView banner;
	RewardBasedVideoAd rbva;
	TextMeshPro txtPlus;
	TextMeshPro txtLives;

	void Start () {
		txtPlus = GameObject.Find("txt_ads").GetComponent<TextMeshPro>();
		txtLives = GameObject.Find("txt_lives").GetComponent<TextMeshPro>();
		RequestBanner ();
		rbva = RewardBasedVideoAd.Instance;
		rbva.OnAdRewarded += HandleRewardedBasedVideoRewarded;
		rbva.OnAdFailedToLoad += HandleAdFailedToLoad;
		rbva.LoadAd (new AdRequest.Builder ().Build (), "ca-app-pub-1541045839364233/4372423697");
	}

	void Update(){
		if (rbva.IsLoaded () && Cego.lives < 25) {
			txtPlus.text = "+";
			GetComponent<SpriteRenderer>().color = new Vector4(0,0,0,1f);
		} else {
			txtPlus.text = "";
			GetComponent<SpriteRenderer>().color = new Vector4(0,0,0,0.4f);
		}
	}

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		if(rbva.IsLoaded() && Cego.lives < 25) rbva.Show ();
		transform.localScale /= 0.9f;
	}

	public void HandleRewardedBasedVideoRewarded(object sender, Reward args){
		Cego.lives = 25;
		txtLives.text = "X25";
		PlayerPrefs.SetInt ("lives", Cego.lives);
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args){
		rbva.LoadAd (new AdRequest.Builder ().Build (), "ca-app-pub-1541045839364233/4372423697");
	}
		
	public static void RequestBanner(){
		banner = new BannerView ("ca-app-pub-1541045839364233/8888940129", AdSize.Banner, AdPosition.Bottom);
		banner.LoadAd(new AdRequest.Builder().Build());
		banner.Show ();
		banner.Hide ();
	}

}
