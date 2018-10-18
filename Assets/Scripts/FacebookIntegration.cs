using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebookIntegration : MonoBehaviour {

	//Get the Username reference
	public Text username;
	// get the image reference
	public Image userprof;



	void Awake(){
		FB.Init (SetInit,OnLoginUnity);
	}

	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged In");
		} else {
			FB.LogOut ();
			Debug.Log ("FB is not logged In");
		}
	}

	void OnLoginUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;   //pause the scene
		} else {
			Time.timeScale = 1;    //resume the scene
		}
	}

	public void FBLogin(){
		//Storing permisions in a list
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		FB.LogInWithReadPermissions (permissions,AuthCallback);
	}

	 void AuthCallback(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged In");
				//getting username of username from GraphApi
				FB.API ("/me?fields=first_name",HttpMethod.GET, DisplayUsername);
				//Getting image of user from GraphApi
				FB.API ("/me/picture?type=square&height=128&width=128",HttpMethod.GET,Showprofilepic);
				Debug.Log (result.Error);
			} else {
				Debug.Log ("FB is not logged In");
			}
		}
	}
	//Displaying the username on the screen
	void DisplayUsername(IResult result){
			Text UserName = username.GetComponent<Text> ();
		if (result.Error == null) {
			UserName.text = result.ResultDictionary ["first_name"].ToString ();
		} else {
			Debug.Log (result.Error);
		}
	}
	//Displaying the image on the screen
	void Showprofilepic(IGraphResult result){
		if (result.Texture != null) {
			Debug.Log (result.RawResult);
			userprof.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}

	//Share the highscore to facebook
	public void ShareHighscore(){
		int score = PlayerPrefs.GetInt ("highScore");
		if (FB.IsLoggedIn) {
			FB.ShareLink (
				contentTitle: "Flappy Bird, HighScore-"+score,
				contentURL: new System.Uri ("https://weavebytes.com"),
				contentDescription: "Beat my HighScore:"+score);
		}
	}

	public void InviteFriends(){
		FB.AppRequest (
			"Come play this great game!",
			null,null,null,null,null,null,
			delegate(IAppRequestResult result) {
				Debug.Log (result.RawResult);	
			});
	}
}
