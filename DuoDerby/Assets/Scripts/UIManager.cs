﻿using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public Animator startButton;
	public Animator settingsButton;
	public Animator dialog;
	public string mainLevel;
	public string howToPage;

	public void StartGame() {
		Application.LoadLevel(mainLevel);
	}

	public void HowTo() {
		Application.LoadLevel (howToPage);
	}

	public void OpenSettings() {
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		dialog.enabled = true;
		dialog.SetBool("isHidden", false);
	}

	public void CloseSettings() {
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);
		dialog.SetBool("isHidden", true);
	}
}
