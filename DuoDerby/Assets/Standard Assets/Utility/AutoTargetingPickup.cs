using UnityEngine;
using System.Collections;

public class AutoTargetingPickup : MonoBehaviour {
	private bool active;
	IEnumerator ActivateTimer()
	{
		active = true;
		yield return new WaitForSeconds (30);
		active = false;
	}
	// Use this for initialization
	void Start () 
	{
		active = false;
	}
	
	// Update is called once per frame

}
