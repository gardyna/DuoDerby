using UnityEngine;
using System.Collections;

public class HowTo_return : MonoBehaviour {
	public string menu;
	
	public void MenuReturn() {
		Application.LoadLevel(menu);
	}
}
