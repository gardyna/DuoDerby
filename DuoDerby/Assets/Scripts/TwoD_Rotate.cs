﻿using UnityEngine;
using System.Collections;

public class TwoD_Rotate : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, -50) * Time.deltaTime);
	}
}
