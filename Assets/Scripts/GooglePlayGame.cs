 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using GooglePlayGames;
 using UnityEngine.SocialPlatforms;
 using GooglePlayGames.BasicApi;
 using System;

 public class GooglePlayGame : MonoBehaviour {

	public static bool hasTriedToLogin = false;

	void Start(){
		if(!hasTriedToLogin) {
			Init();
			Login(success => {});
			hasTriedToLogin = true;
		}
	}

	void Update() {
		if(GooglePlayGame.IsAuthenticated()) {
			GetComponent<SpriteRenderer>().color = new Vector4(0,0,0,1f);
		} else {
			GetComponent<SpriteRenderer>().color = new Vector4(0,0,0,0.4f);
		}
	}
 	public static void Init(){
 		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
 		PlayGamesPlatform.InitializeInstance (config);
 		PlayGamesPlatform.DebugLogEnabled = true;
 		PlayGamesPlatform.Activate ();
 	}

 	public static void Login(Action<bool> onLogin)
 	{

 		if(Social.Active == null)
 		{
 			return;
 		}

 		if (IsAuthenticated())
 		{
 			return;
 		}
		PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
			onLogin(true);
		});
 	}
 	public static bool IsAuthenticated()
 	{
 		return Social.localUser.authenticated;
 	}

 	/// <summary>

 /// Incrementa as etapas da conquista

 /// </summary>

 /// <param name=”achievement”></param>

 /// <param name=”points”></param>

 /// <param name=”onIncrementAchievement”></param>

 	public static void IncrementAchievement(string achievement, int points, Action<bool> onIncrementAchievement)
 	{

 		PlayGamesPlatform.Instance.IncrementAchievement(achievement, points, (bool success) => {
 			if(onIncrementAchievement != null)
 			{
 				onIncrementAchievement(success);
 			}

 		});

 	}

 		/// <summary>

 		/// Reporta o progresso da conquista

 		/// </summary>

 		/// <param name=”achievementID”></param>

 		/// <param name=”progress”></param>

 		/// <param name=”onIncrementAchievement”></param>

 	public static void ReportAchievementProgress(string achievementID, float progress, Action<bool> onIncrementAchievement)
 	{

 		Social.ReportProgress(achievementID, progress, (bool success) => {

 		if(onIncrementAchievement != null)
 		{
 			onIncrementAchievement(success);
 		}

 		});

 	}

	private void ShowAchievementsUI(){
		Login(success => {});
		Social.ShowAchievementsUI();
	}

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		transform.localScale /= 0.9f;
		ShowAchievementsUI();
	}

 }

