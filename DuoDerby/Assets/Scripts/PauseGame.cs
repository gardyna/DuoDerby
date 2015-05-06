using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {


	public int buttonHeight = 30;
	public int buttonSpace = 10;
	public int menuWidth = 150;
	public int menuHeight = 150;

	public Font MyFont;

	private int wonders;
	private GameObject god;	//God is watching//

	void Start (){
		wonders = 0;
		god = GameObject.Find ("hope");
		god.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown("p")){

			if (Time.timeScale == 1){
				Time.timeScale =0;
				this.GetComponent<AudioListener>().enabled = false;
				wonders++;
				if (wonders >= 10)
					god.SetActive(true);
			}
			else{
				Time.timeScale =1;
				this.GetComponent<AudioListener>().enabled = true;
			}

		}

	}
	

	void OnGUI (){
		GUI.skin.font = MyFont;
		GUI.backgroundColor = Color.green;
		if (Time.timeScale == 0) {
			GUILayout.BeginArea (new Rect(Screen.width / 2 - menuWidth / 2, Screen.height / 2 - menuHeight / 2, menuWidth, menuHeight));
			if (GUILayout.Button ("Resume", GUILayout.Height (buttonHeight))) {
				Time.timeScale = 1;
				this.GetComponent<AudioListener>().enabled = true;
			}
		
			GUILayout.Space (buttonSpace);
			if (GUILayout.Button ("Main Menu", GUILayout.Height (buttonHeight))) {
				Time.timeScale = 1;
				Application.LoadLevel ("MainMenu");
			}
			GUILayout.Space (buttonSpace);
			if (GUILayout.Button ("Quit Game", GUILayout.Height (buttonHeight))) {
				Application.Quit ();
			}
			GUILayout.EndArea();
		}
	}
}
