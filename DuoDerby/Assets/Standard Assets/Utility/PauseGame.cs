using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")){
			if (Time.timeScale == 1)
				Time.timeScale =0;
			else
				Time.timeScale =1;
		}
	}
}
