using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {


	public int buttonHeight = 30;
	public int buttonSpace = 10;
	public int menuWidth = 150;
	public int menuHeight = 150;

	public Font MyFont;


	void Update () {
		if (Input.GetKeyDown("p")){

			if (Time.timeScale == 1){
				Time.timeScale =0;
			}
			else{
				Time.timeScale =1;
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
